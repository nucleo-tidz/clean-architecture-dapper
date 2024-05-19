using Api.Startup;
using System.Runtime.CompilerServices;

namespace Api.StartupTask
{
    public static class Boostraper
    {
        public static async Task Bootstrap(this WebApplication app)
        {
            var startups = app.Services.GetServices<IStartupTask>();
            foreach (var task in startups)
            {
                await task.Execute();
            }
            await app.RunAsync();
        }
    }
}
