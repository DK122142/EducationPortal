using System.Runtime.InteropServices.ComTypes;
using EducationPortal.Storage;
using EducationPortal.UI.Pages;

namespace EducationPortal.UI
{
    public class App
    {

        public App()
        {
            var tableManager = new TableManager(new StorageController(new Storage.Storage()));

            Home.Show(tableManager);
        }
    }
}
