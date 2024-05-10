namespace Api.Startup
{
    public class Inform : IStartupTask
    {
        public async Task Execute()
        {
            await Task.CompletedTask;
        }
    }
}
