using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;

namespace RetailCore.SourceGenerator
{
	[Generator]
	public class RepositoryGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
			// Initialization logic, if needed
		}

		public void Execute(GeneratorExecutionContext context)
		{
			System.Diagnostics.Debug.WriteLine("Source generator execution started.");

			// Get all the classes (entities) from the compilation
			var syntaxTrees = context.Compilation.SyntaxTrees;
			foreach (var syntaxTree in syntaxTrees)
			{
				var root = syntaxTree.GetRoot();
				var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

				// Generate the repository interface and class for this entity
				string repositoryInterface = GenerateRepositoryInterface("className");
				string repositoryClass = GenerateRepositoryClass("className");

				// Add the generated code to the compilation
				context.AddSource($"{"className"}RepositoryInterface.g.cs", SourceText.From(repositoryInterface, Encoding.UTF8));
				context.AddSource($"{"className"}RepositoryClass.g.cs", SourceText.From(repositoryClass, Encoding.UTF8));

				//foreach (var classDeclaration in classes)
				//{
				//	var namespaceDeclaration = classDeclaration.Ancestors().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
				//	if (namespaceDeclaration != null && namespaceDeclaration.Name.ToString() == "RetailCore.Entities.EntityModels")
				//	{
				//		string className = classDeclaration.Identifier.Text;

				//		// Generate the repository interface and class for this entity
				//		string repositoryInterface = GenerateRepositoryInterface(className);
				//		string repositoryClass = GenerateRepositoryClass(className);

				//		// Add the generated code to the compilation
				//		context.AddSource($"{className}RepositoryInterface.g.cs", SourceText.From(repositoryInterface, Encoding.UTF8));
				//		context.AddSource($"{className}RepositoryClass.g.cs", SourceText.From(repositoryClass, Encoding.UTF8));
				//	}
				//}
			}
		}

		private string GenerateRepositoryInterface(string className)
		{
			return $@"
using RetailCore.Interfaces.DataAccess;

namespace RetailCore.Interfaces.Repository
{{
    public interface I{className}Repository : IRepository<{className}>
    {{
        // Add custom methods here if needed
    }}
}}";
		}

		private string GenerateRepositoryClass(string className)
		{
			return $@"
using RetailCore.Interfaces.DataAccess;
using RetailCore.Persistance.DataAccess;

namespace RetailCore.Repository
{{
    public class {className}Repository : Repository<{className}>, I{className}Repository
    {{
        public {className}Repository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {{
        }}

        // Add custom methods implementation here if needed
    }}
}}";
		}
	}
}
