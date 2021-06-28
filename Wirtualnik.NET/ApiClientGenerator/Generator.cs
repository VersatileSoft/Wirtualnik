using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ApiClientGenerator
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }
        public void Execute(GeneratorExecutionContext context)
        {
            var dest = Path.GetFullPath(Path.Combine(context.Compilation.SyntaxTrees.FirstOrDefault(f => Path.GetFileName(f.FilePath) == "Program.cs").FilePath, @"..\..\Wirtualnik.Shared\ApiClient\Generated"));

            Directory.CreateDirectory(dest);
            foreach (var controller in context.Compilation.SyntaxTrees.GetControllers())
            {
                string code = GenerateInterface(controller);
                File.WriteAllText(dest + $"\\I{controller.Identifier.Text.Replace("Controller", "Client")}.cs", code);
                code = GenerateImplementation(controller);
                File.WriteAllText(dest + $"\\{controller.Identifier.Text.Replace("Controller", "Client")}.cs", code);
            }
        }

        private static string GenerateInterface(ClassDeclarationSyntax controller)
        {
            var code = new CodeWriter();
            code.Using("System");
            code.Using("System.Collections.Generic");
            code.Using("System.Net.Http");
            code.Using("System.Text");
            code.Using("System.Threading.Tasks");
            code.Using("Newtonsoft.Json");
            code.Using("Wirtualnik.Shared.ApiClient");
            code.Using("Wirtualnik.Shared.Models");
            code.AppendLine();
            using (code.Namespace("Wirtualnik.Shared.ApiClient.Generated"))
            {
                using (code.Interface($"{controller.InterfaceName()} : IAbstractClient<{controller.GetModelType()}>"))
                {
                    foreach (MethodDeclarationSyntax method in controller.GetMethods())
                    {
                        code.AppendLine($"{method.ReturnType} {method.Identifier.Text}{Regex.Replace(method.ParameterList.ToString(), @"\[(.*?)\]", "")};");
                    }
                }
            }

            return code.ToString();
        }

        private string GenerateImplementation(ClassDeclarationSyntax controller)
        {
            string controllerPath = "";
            foreach (var t in controller.AttributeLists)
            {
                var route = t.Attributes.FirstOrDefault(a => a.Name.ToString() == "Route");
                if (route is not null)
                {
                    controllerPath = route.ArgumentList.Arguments.FirstOrDefault().ToString();
                    break;
                }
            }

            var code = new CodeWriter();
            code.Using("System");
            code.Using("System.Collections.Generic");
            code.Using("System.Net.Http");
            code.Using("System.Text");
            code.Using("System.Threading.Tasks");
            code.Using("Newtonsoft.Json");
            code.Using("Wirtualnik.Shared.Models");
            code.AppendLine();
            using (code.Namespace("Wirtualnik.Shared.ApiClient.Generated"))
            {
                using (code.Class($"{controller.ClassName()} : AbstractClient<{controller.GetModelType()}>, {controller.InterfaceName()}"))
                {
                    code.AppendLine($"protected override string ControllerPath => {controllerPath};");

                    using (code.BeginScope($"public {controller.ClassName()}(HttpClient client) : base(client)"))
                    {

                    }

                    code.AppendLine();

                    foreach (MethodDeclarationSyntax method in controller.GetMethods())
                    {
                        using (code.BeginScope($"public async {method.ReturnType} {method.Identifier.Text}{Regex.Replace(method.ParameterList.ToString(), @"\[(.*?)\]", "")}"))
                        {
                            code.AppendLine("throw new NotImplementedException();");
                        }
                    }
                }
            }

            return code.ToString();
        }
    }
}
