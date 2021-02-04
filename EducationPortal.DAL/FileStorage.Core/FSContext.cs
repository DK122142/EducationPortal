using System;
using System.Collections.Generic;
using EducationPortal.DAL.FileStorage.Core.Infrastructure;
using EducationPortal.DAL.FileStorage.Core.Internal;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FileStorage.Core
{
    public class FSContext
    {
        private IEnumerable<Type> sets; 
        private Storage storage;
        private IFileStorageSetInitializer setInitializer;

        public Storage Storage
        {
            get
            {
                return this.storage ??= new Storage(this);
            }
        }

        public FSContext(IFileStorageSetInitializer fileStorageSetInitializer = null)
        {
            this.setInitializer = new FileStorageSetInitializer();

            this.setInitializer.InitializeSets(this);

            this.Storage.EnsureCreated();
        }
    }
}
