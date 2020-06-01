using MediatR;
using OmniSharp.Extensions.LanguageServer.Protocol;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Server;
using OmniSharp.Extensions.LanguageServer.Protocol.Server.Capabilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLanguageServer.Handlers
{
    public class TextDocumentHandler : TextDocumentSyncHandler
    {
        private readonly ILanguageServer _server;

        public TextDocumentHandler(ILanguageServer server) : 
            base(TextDocumentSyncKind.Full, new TextDocumentSaveRegistrationOptions()
            {
                DocumentSelector = new DocumentSelector(
                    new DocumentFilter()
                    {
                        Pattern = "**/*.demo"
                    }),
                IncludeText = true
            })
        {
            _server = server;

            _server.Window.LogMessage(new LogMessageParams
            {
                Message = "Handler created",
                Type = MessageType.Info
            });
        }

        //public override TextDocumentAttributes GetTextDocumentAttributes(DocumentUri uri)
        //{
        //    return new TextDocumentAttributes(uri, "demo");
        //}

        public override TextDocumentAttributes GetTextDocumentAttributes(Uri uri)
        {
            return new TextDocumentAttributes(uri, "demo");
        }

        public override Task<Unit> Handle(DidOpenTextDocumentParams request, CancellationToken cancellationToken)
        {
            var message = "Opened demo file!";

            _server.Window.ShowMessage(new ShowMessageParams
            {
                Message = message,
                Type = MessageType.Info
            });

            return Task.FromResult(Unit.Value);
        }

        public override Task<Unit> Handle(DidChangeTextDocumentParams request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }

        public override Task<Unit> Handle(DidSaveTextDocumentParams request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }

        public override Task<Unit> Handle(DidCloseTextDocumentParams request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Unit.Value);
        }
    }
}
