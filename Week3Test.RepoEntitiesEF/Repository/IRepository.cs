using System;
using System.Collections.Generic;
using System.Text;

namespace Week3Test.RepoEntitiesEF.Repository
{
    public interface IRepository<T> where T : class
    {
        public bool Create(T item);
        public bool Delete(int id);
        public T GetById(int id);
        public bool Update(T item);
    }
}
