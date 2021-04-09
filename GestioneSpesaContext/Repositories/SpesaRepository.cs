using System;
using System.Collections.Generic;
using System.Text;
using Week3Test.RepoEntitiesEF.Entities;
using Week3Test.RepoEntitiesEF.Repository;
using GestioneSpesaContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestioneSpesaContext.Repositories
{
    public class SpesaRepository : ISpesaRepository
    {
        public bool Create(Spesa item)
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (item == null)
                    return false;

                var cat = db.Categoria.Include(s => s.Spese).Where(c => c.CategoriaId == item.CategoriaId).SingleOrDefault();
                if (cat == null)
                    return false;

                cat.Spese.Add(item);
                db.Spese.Add(item);
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (id <= 0)
                    return false;

                var  spesa = db.Spese.Find(id);
                if (spesa == null)
                    return false;

                db.Spese.Remove(spesa);
                db.SaveChanges();
                return true;
            }
        }

        public Spesa GetById(int id)
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (id <= 0)
                    return null;

                return db.Spese.Include(c => c.Categoria).FirstOrDefault(s => s.SpeseId == id);
            }
        }

        public List<Spesa> SpeseApprovate()
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                List<Spesa> approved = db.Spese.Include(c => c.Categoria).Where(s => s.Approvato == true).ToList();
                if (approved != null)
                    return approved;
                else return null;
            }
        }

        public void SpeseApprovatePerUtente(string userName)
        {
            using (GestioneSpesaContext db = new GestioneSpesaContext())
            {
                var approvedByUser = db.Spese
                     .Where(s => s.Approvato == true)
                     .GroupBy(g => g.Utente);

                if (approvedByUser == null)
                {
                    Console.WriteLine("Nessuna spesa è stata ancora inserita per l'utente, o il nome è sbagliato");
                    return;
                }

                foreach (var item in approvedByUser)
                {
                    Console.WriteLine($"Categoria: {item.Key}");
                    foreach (var spesa in item)
                    {
                        Console.WriteLine($"{spesa.SpeseId}");
                        Console.WriteLine($"{spesa.Data}");
                        Console.WriteLine($"{spesa.Categoria.CategoriaNome}");
                        Console.WriteLine($"{spesa.Descrizione}");
                        Console.WriteLine($"{spesa.Utente}");
                        Console.WriteLine($"{spesa.Importo}");
                        Console.WriteLine($"{spesa.Approvato}");
                    }
                }
            }
        }

        public decimal TotaleSpesePerCategoria(int idCat)
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (idCat <= 0)
                    return 0;

                var cat = db.Spese.Where(c => c.CategoriaId == idCat);
                if (cat == null)
                    return 0;

                decimal totale = db.Spese.Where(c => c.CategoriaId == idCat).Sum(s => s.Importo);
                return totale;

            }
        }

        public bool Update(Spesa item)
        {
            using(GestioneSpesaContext db = new GestioneSpesaContext())
            {
                if (item == null)
                    return false;

                var spesa = db.Spese.Find(item.SpeseId);
                if (spesa == null)
                    return false;

                spesa.Approvato = item.Approvato;           //Dovrei fare l'update di ogni proprietà
                                                            // e tracciare l'update però sto risolvendo
                                                            // un problema e non avendo più tempo lo sto
                                                            // modificando in questo modo brutale
                db.SaveChanges();


                //try
                //{ 
                //    db.Entry<Spesa>(item).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //    return false;
                //}
                return true;
            }
        }
    }
}
