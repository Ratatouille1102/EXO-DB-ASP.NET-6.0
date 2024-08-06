using System;
using System.Collections.Generic;
using System.Text;

namespace Common_DBSlide.Repositories
{
    public interface ICRUDRepository<TEntity, TId>
    {
        public IEnumerable<TEntity> Get();
        public TEntity Get(TId id);
        public TId Insert(TEntity entity);
        public void Update(TId id, TEntity entity);
        public void Delete(TId id);
    }
}
