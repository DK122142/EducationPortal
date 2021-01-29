using EducationPortal.BLL.Interfaces;
using EducationPortal.BLL.Services;
using EducationPortal.Prompt.Interfaces;

namespace EducationPortal.Prompt
{
    public class Startup
    {
        private IServiceCreator serviceCreator = new ServiceCreator();

        public Startup(IAppContext app)
        {

        }


        // public IAccountService CreateAccountService()
        // {
        //     return this.serviceCreator.CreateAccountService();
        // }




    }
}
