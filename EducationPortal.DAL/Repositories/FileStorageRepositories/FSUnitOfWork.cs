﻿using EducationPortal.DAL.Entities;
using EducationPortal.DAL.FS.Interfaces;
using EducationPortal.DAL.Infrastructure;
using EducationPortal.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EducationPortal.DAL.Repositories.FileStorageRepositories
{
    public class FSUnitOfWork : IUnitOfWork
    {
        private readonly IEducationPortalContext context;

        public FSUnitOfWork(IEducationPortalContext educationPortalContext)
        {
            this.context = educationPortalContext;
        }
        
        public TRepository GetRepository<TRepository>() where TRepository : IRepository<Entity>
        {
            return RepositoryContainer.ServiceProvider.GetRequiredService<TRepository>();
        }

        public IRepository<TEntity> GetRepositoryOfEntity<TEntity>() where TEntity : Entity
        {
            return RepositoryContainer.ServiceProvider.GetRequiredService<IRepository<TEntity>>();
        }
    }
}
