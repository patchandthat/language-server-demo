using DemoLanguageServer.Handlers;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using OmniSharp.Extensions.LanguageServer.Protocol.Window;
using OmniSharp.Extensions.LanguageServer.Server;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLanguageServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var server = await LanguageServer.From(options =>
                options
                    .WithInput(Console.OpenStandardInput())
                    .WithOutput(Console.OpenStandardOutput())
                    .WithHandler<TextDocumentHandler>()
                    .OnStarted(OnStartedCallback)
                );


            await server.WaitForExit;
        }

        private static Task OnStartedCallback(ILanguageServer server, InitializeResult result, CancellationToken cancellationToken)
        {
            server.Window.ShowMessage(new ShowMessageParams
            {
                Message = $"{result.ServerInfo.Name} server started",
                Type = MessageType.Info
            });

            return Task.CompletedTask;
        }
    }
}
