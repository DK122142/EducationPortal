using EducationPortal.Prompt.Views;

namespace EducationPortal.Prompt
{
    class Program
    {
        static void Main(string[] args)
        {
            // IServiceCollection services = new ServiceCollection();
            //
            // services.AddSingleton<IFileStorageSetInitializer, FileStorageSetInitializer>();
            // services.AddSingleton<FSContext, IdentityContext>();
            // services.AddSingleton<AccountManager>();
            // services.AddSingleton<IAccountService, AccountService>();
            //
            // IServiceProvider serviceProvider = services.BuildServiceProvider();
            //
            // var accountService = serviceProvider.GetService<AccountService>();

            new Start();
        }
    }
}
