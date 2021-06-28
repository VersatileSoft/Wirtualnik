using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace ApiClientGenerator
{
    public static class Extensions
    {
        public static IEnumerable<ClassDeclarationSyntax> GetControllers(this IEnumerable<SyntaxTree> syntaxTrees)
        {
            List<ClassDeclarationSyntax> result = new();

            foreach (var syntaxTree in syntaxTrees)
            {
                var controller = syntaxTree
                    .GetRoot()
                    .DescendantNodes()
                    .FirstOrDefault(s => s is ClassDeclarationSyntax c && (c.AttributeLists.FirstOrDefault()?.Attributes.Any(a => a.Name.ToString().Contains("Controller")) ?? false));

                if (controller is not null)
                {
                    result.Add((ClassDeclarationSyntax)controller);
                }
            }
            return result;
        }

        public static string? GetModelType(this ClassDeclarationSyntax controller) =>
            controller.BaseList?.Types.FirstOrDefault(t => t.ToString().Contains("AbstractControllerBase"))?.ToString().Split('<', '>')[1];

        public static string InterfaceName(this ClassDeclarationSyntax controller) =>
            $"I{controller.Identifier.Text.Replace("Controller", "Client")}";

        public static string ClassName(this ClassDeclarationSyntax controller) =>
            controller.Identifier.Text.Replace("Controller", "Client");

        public static IEnumerable<MethodDeclarationSyntax> GetMethods(this ClassDeclarationSyntax controller) =>
            controller.ChildNodes().Where(m => m.IsKind(SyntaxKind.MethodDeclaration)).Cast<MethodDeclarationSyntax>();
    }
}
