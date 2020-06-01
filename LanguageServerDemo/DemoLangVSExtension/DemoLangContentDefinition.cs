using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace DemoLangVSExtension
{
    public class DemoLangContentDefinition
    {
        [Export]
        [Name("demo")]
        [BaseDefinition(CodeRemoteContentDefinition.CodeRemoteContentTypeName)]
        internal static ContentTypeDefinition BarContentTypeDefinition;

        [Export]
        [FileExtension(".demo")]
        [ContentType("demo")]
        internal static FileExtensionToContentTypeDefinition BarFileExtensionDefinition;
    }
}
