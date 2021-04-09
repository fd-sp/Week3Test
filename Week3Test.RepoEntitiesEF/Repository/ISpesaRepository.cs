using System;
using System.Collections.Generic;
using System.Text;
using Week3Test.RepoEntitiesEF.Entities;

namespace Week3Test.RepoEntitiesEF.Repository
{
    public interface ISpesaRepository : IRepository<Spesa>
    {
        public List<Spesa> SpeseApprovate();
        public void SpeseApprovatePerUtente(string userName);
        public decimal TotaleSpesePerCategoria(int idCat);
    }
}
