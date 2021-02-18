using System;
using System.Collections.Generic;
using EducationPortal.DAL.FileStorage.Core.Infrastructure;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core
{
    public class FSContext
    {
        private IEnumerable<Type> sets;
        private string storageName;
        private Storage storage;
        private IFileStorageSetInitializer setInitializer;

        public Storage Storage
        {
            get
            {
                return this.storage ??= new Storage(this, this.storageName);
            }
        }

        public FSContext(IFileStorageSetInitializer fileStorageSetInitializer, string storageName = null)
        {
            this.setInitializer = fileStorageSetInitializer;
            this.storageName = storageName;

            this.setInitializer.InitializeSets(this);

            this.Storage.EnsureCreated();
        }
    }
}
