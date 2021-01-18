using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationPortal.Entities;
using EducationPortal.Storage;

namespace EducationPortal.Controllers
{
    public class MaterialController : BaseController
    {
        public MaterialController(ITableManager tableManager) : base(tableManager)
        {
        }

        public async Task<object> AddMaterial<T>(T material)
        {
            if (TableManager.AnyEqual<T>("Name", (material as Material).Name))
            {
                // Console.WriteLine($"Material with name {(material as Material).Name} already exists!");
                return null;
            }

            await TableManager.StorageController.InsertInto(material);

            return material;
        }
    }
}
