﻿using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FileStorage.Core;
using EducationPortal.DAL.FileStorage.Core.Internal.Interfaces;

namespace EducationPortal.DAL.FS
{
    public class IdentityContext : FSContext
    {
        public FSSet<Account> Accounts { get; set; }

        public IdentityContext(IFileStorageSetInitializer initializer = null) : base(initializer)
        {
            
        }
    }
}
