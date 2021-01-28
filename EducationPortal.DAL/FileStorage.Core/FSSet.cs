using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace EducationPortal.DAL.FileStorage.Core
{
    public abstract class FSSet<TEntity> : IQueryable<TEntity>, IAsyncEnumerable<TEntity>, IListSource
        where TEntity : class
    {

        public virtual IAsyncEnumerable<TEntity> AsAsyncEnumerable() => this;

        public virtual IQueryable<TEntity> AsQueryable() => this;

        // public virtual TEntity Find(params object[] keyValues) => throw new NotSupportedException();

        public IEnumerator<TEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType { get; }
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
        public IAsyncEnumerator<TEntity> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IList GetList()
        {
            throw new NotImplementedException();
        }

        public bool ContainsListCollection { get; }
    }
}
