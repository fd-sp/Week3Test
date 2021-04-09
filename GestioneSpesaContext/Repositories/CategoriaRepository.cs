using System;
using System.Collections.Generic;
using System.Text;
using Week3Test.RepoEntitiesEF.Entities;
using Week3Test.RepoEntitiesEF.Repository;

namespace GestioneSpesaContext.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public bool Create(Categoria item)
        {
            using (GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (item == null)
                    return false;

                db.Categoria.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Categoria GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Categoria item)
        {
            throw new NotImplementedException();
        }
    }
}
