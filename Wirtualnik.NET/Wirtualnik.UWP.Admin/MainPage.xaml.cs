using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.Shared.Models.Auth;
using Wirtualnik.Shared.Models.Product;
using Wirtualnik.UWP.Admin.Models;

namespace Wirtualnik.UWP.Admin
{
    public sealed partial class MainPage : Page
    {
        public static string Token;
        public List<ImageModel> SelectedFiles { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            SelectedFiles = new List<ImageModel>();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var auth = (IAuthClient)App.Services.GetService(typeof(IAuthClient));

                var tokenModel = await auth.LoginAsync(new LoginModel
                {
                    Email = Login.Text,
                    Password = Password.Password
                });

                Token = tokenModel.Content.Token;
            }
            catch (ApiException ex)
            {
                await ShowContentDialog(ex.Message, ex.StackTrace);
                return;
            }
            catch (Exception ex)
            {
                await ShowContentDialog(ex.Message, ex.StackTrace);
                return;
            }

            if (!string.IsNullOrEmpty(Token))
            {
                InfoLabel.Text = "Zalogowano";
                InfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 75, 245, 66));
            }
            else
            {
                InfoLabel.Text = "Coś poszło nie tak";
                InfoLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 245, 114, 66));
            }

            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));
            var types = await products.GetAllProductTypes();

            if (!types.IsSuccessStatusCode)
            {
                return;
            }

            if (itemTypesList.Items.Any())
            {
                itemTypesList.Items.Clear();
            }

            foreach (var prod in types.Content)
            {
                itemTypesList.Items.Add(prod);
            }
        }

        private async void AddType_Click(object sender, RoutedEventArgs e)
        {
            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));

            List<string> cleanStrings = new List<string>();

            //Remove empty strings, duplicates, trim, replace multiple spaces to one space and split to array by enters
            foreach (var dirtyString in ProductTypeProps.Text.Split('\r').Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                var cleanString = Regex.Replace(dirtyString, @"\s+", " ");
                cleanStrings.Add(cleanString.Trim());
            }
            var test = cleanStrings.Distinct().ToArray();

            try
            {
                await products.CreateProductType(ProductTypeName.Text, test);
            }
            catch (Exception ex)
            {
                await ShowContentDialog(ex.Message, ex.StackTrace).ConfigureAwait(false);
                return;
            }

            var pro = (IProductClient)App.Services.GetService(typeof(IProductClient));
            var types = await products.GetAllProductTypes();
            itemTypesList.Items.Clear();
            if (!types.IsSuccessStatusCode) return;

            foreach (var prod in types.Content)
            {
                itemTypesList.Items.Add(prod);
            }
        }

        private async void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductStatusText.Text = "Wrzuca";

            var products = (IProductClient)App.Services.GetService(typeof(IProductClient));

            List<KeyValuePair<int, string>> props = new List<KeyValuePair<int, string>>();

            foreach (var item in Props.Children)
            {
                var panel = item as TextBox;
                var id = panel.TabIndex;
                var value = panel.Text;
                props.Add(new KeyValuePair<int, string>(id, value));
            }

            CreateModel model = new CreateModel
            {
                Archived = false,
                Description = description.Text,
                EAN = prodEAN.Text,
                Name = prodName.Text,
                ProductTypeId = ((ProductTypeModel)itemTypesList.SelectedItem).Id,
                PublicId = prodIdPubl.Text,
                Properties = props
            };

            try
            {
                await products.Create(model);
            }
            catch (ApiException ex)
            {
                await ShowContentDialog(ex.Message, ex.StackTrace);
                return;
            }

            var filesClient = (IFilesClient)App.Services.GetService(typeof(IFilesClient));

            var files = new List<StreamPart>();

            foreach (var file in SelectedFiles)
            {
                //var stream = await file.OpenStreamForReadAsync();
                files.Add(new StreamPart(file.ImageStream, System.IO.Path.GetFileName(file.Name)));
            }

            try
            {
                await filesClient.Create(model.PublicId, files);
            }
            catch (ApiException ex)
            {
                await ShowContentDialog(ex.Message, ex.StackTrace);
                AddProductStatusText.Text = "Nie działa";
                files.Clear();
                return;
            }

            AddProductStatusText.Text = "Działa";
            files.Clear();
        }

        private void ItemTypesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var model = (ProductTypeModel)itemTypesList.SelectedItem;

            if (model is null)
            {
                return;
            }

            Props.Children.Clear();
            foreach (var prop in model.PropertyTypes)
            {
                Props.Children.Add(new TextBox
                {
                    TabIndex = prop.Id,
                    Header = prop.Name,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Width = 124
                });
            }
        }

        private async void AddFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectedFiles = new List<ImageModel>();

            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            fileOpenPicker.FileTypeFilter.Add(".png"); // Required file extension 

            var pickedFiles = await fileOpenPicker.PickMultipleFilesAsync();

            if (pickedFiles.Count == 0)
            {
                return;
            }

            foreach (var file in pickedFiles)
            {
                BitmapImage image = new BitmapImage();
                BitmapDecoder decoder;
                var fileStream = await file.OpenStreamForReadAsync();
                using (IRandomAccessStream stream = fileStream.AsRandomAccessStream())
                {
                    await image.SetSourceAsync(stream);
                    decoder = await BitmapDecoder.CreateAsync(stream);
                }

                SelectedFiles.Add(new ImageModel(file.Name, file.Path, $"{decoder.PixelHeight}x{image.PixelWidth}", file.OpenStreamForReadAsync().Result, image));
            }

            flipView.ItemsSource = SelectedFiles;
        }

        private async Task ShowContentDialog(string title, string description)
        {
            ContentDialog errorDialog = new ContentDialog()
            {
                Title = title,
                Content = description,
                CloseButtonText = "Ok"
            };

            await errorDialog.ShowAsync();
            return;
        }
    }
}
