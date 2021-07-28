using Microsoft.Win32;
using Refit;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.Shared.Models.Auth;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string? Token;
        public IEnumerable<string> SelectedFiles { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            SelectedFiles = new List<string>();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var auth = (IAuthClient)App.Services.GetService(typeof(IAuthClient));
            var tokenModel = await auth.LoginAsync(new LoginModel
            {
                Email = Login.Text,
                Password = Password.Text
            });

            Token = tokenModel.Token;

            if (!string.IsNullOrEmpty(Token))
            {
                InfoLabel.Content = "Login ok";
            }
            else
            {
                InfoLabel.Content = "Login failed";
            }

            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));
            var types = await products.GetAllProductTypes();

            if (!types.IsSuccessStatusCode) return;

            foreach (var prod in types.Content)
            {
                ItemTypesList.Items.Add(prod);
            }
        }

        private async void AddType_Click(object sender, RoutedEventArgs e)
        {
            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));

            await products.CreateProductType(ProductTypeName.Text, ProductTypeProps.Text.Split(","));

            var pro = (IProductClient)App.Services.GetService(typeof(IProductClient));
            var types = await products.GetAllProductTypes();
            ItemTypesList.Items.Clear();
            if (!types.IsSuccessStatusCode) return;

            foreach (var prod in types.Content)
            {
                ItemTypesList.Items.Add(prod);
            }
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));

            List<KeyValuePair<int, string>> props = new List<KeyValuePair<int, string>>();

            foreach (var item in Props.Children)
            {
                var panel = item as StackPanel;
                var id = int.Parse(panel.Uid);
                var value = (panel.Children[1] as TextBox).Text;
                props.Add(KeyValuePair.Create(id, value));
            }

            CreateModel model = new CreateModel
            {
                Archived = false,
                Description = Description.Text,
                EAN = ProdEAN.Text,
                Name = ProdName.Text,
                ProductTypeId = ((ProductTypeModel)ItemTypesList.SelectedItem).Id,
                PublicId = prodIdPubl.Text,
                Properties = props
            };

            await products.Create(model);

            var filesClient = (IFilesClient)App.Services.GetService(typeof(IFilesClient));

            var files = new List<StreamPart>();

            foreach (var path in SelectedFiles)
            {
                FileStream file = new FileStream(path, FileMode.Open);
                files.Add(new StreamPart(file, System.IO.Path.GetFileName(file.Name)));
            }

            await filesClient.Create(model.PublicId, files);

            foreach (var file in files)
            {
                file.Value.Dispose();
            }
        }

        private void ItemTypesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var model = (ProductTypeModel)ItemTypesList.SelectedItem;
            Props.Children.Clear();
            foreach (var prop in model.PropertyTypes)
            {
                var stack = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Uid = prop.Key.ToString()
                };

                stack.Children.Add(new Label
                {
                    Content = prop.Value,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    Height = 30
                });

                stack.Children.Add(new TextBox
                {
                    HorizontalAlignment = HorizontalAlignment.Right,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Height = 30,
                    Width = 100
                });

                Props.Children.Add(stack);
            }
        }

        private void AddFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectedFiles = new List<string>();

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".png"; // Required file extension 
            fileDialog.Filter = "Images (.png)|*.png";
            fileDialog.Multiselect = true;

            fileDialog.ShowDialog();

            SelectedFiles = fileDialog.FileNames.ToArray();
        }
    }
}
