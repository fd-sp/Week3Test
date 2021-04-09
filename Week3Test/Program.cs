using GestioneSpesaContext.Repositories;
using System;
using Week3Test.RepoEntitiesEF.Entities;
using Week3Test.RepoEntitiesEF.Repository;

namespace Week3Test
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            ICategoriaRepository catRepo = new CategoriaRepository();
            ISpesaRepository spesaRepo = new SpesaRepository();


            Categoria cat1 = new Categoria 
            { 
                CategoriaNome = "Viaggio"
            };

            Categoria cat2 = new Categoria
            {
                CategoriaNome = "Vitto"
            };

            Categoria cat3 = new Categoria
            {
                CategoriaNome = "Cancelleria"
            };

            //catRepo.Create(cat1);
            //catRepo.Create(cat2);
            //catRepo.Create(cat3);

            while (!exit)
            {
                Console.WriteLine("Salve, cosa desideri fare?");
                Console.WriteLine("-1 Inserire una nuova spesa\n" +
                    "-2 Approvare una spesa già esistente\n" +
                    "-3 Cancellare una spesa già esistente\n" +
                    "-4 Mostrare Elenco spese approvate\n" +
                    "-5 Mostrare Elenco spese per uno specifico utente\n" +
                    "-6 Mostrare il totale spese per una categoria");
                string resp = Console.ReadLine().Trim();

                switch (resp)
                {
                    case "1":
                        Console.WriteLine("Inserisci i dati (Data, CategoriaId, Descrizione, Utente, Importo");
                        DateTime data = DateTime.Parse(Console.ReadLine());
                        int catId = int.Parse(Console.ReadLine());
                        string desc = Console.ReadLine();
                        string utente = Console.ReadLine();
                        decimal importo = decimal.Parse(Console.ReadLine());
                        Spesa newSpesa = new Spesa
                        {
                            Data = data,
                            CategoriaId = catId,
                            Descrizione = desc,
                            Utente = utente,
                            Importo = importo,
                            Approvato = false
                        };
                        spesaRepo.Create(newSpesa);
                        break;

                    case "2":
                        Console.WriteLine("Inserisci l'ID della spesa da approvare:");
                        int id = int.Parse(Console.ReadLine());
                        var spesa = spesaRepo.GetById(id);
                        spesa.Approvato = true;
                        spesaRepo.Update(spesa);
                        break;

                    case "3":
                        Console.WriteLine("Inserisci l'ID della spesa da eliminare: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        spesaRepo.Delete(deleteId);
                        break;

                    case "4":
                        var speseApprovate = spesaRepo.SpeseApprovate();
                        foreach (var item in speseApprovate)
                        {
                            Console.WriteLine($"Spesa Id: {item.SpeseId}\n" +
                                $"Data: {item.Data}\n" +
                                $"Categoria: {item.Categoria.CategoriaNome}\n" +
                                $"Descrizione: {item.Descrizione}\n" +
                                $"Utente: {item.Utente}" +
                                $"Importo: {item.Importo}" +
                                $"Approvato: {(item.Approvato ? "Sì" : "No")}");
                            Console.WriteLine("************************");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Inserisci il nome dell'utente: ");
                        string nomeUtente = Console.ReadLine();
                        spesaRepo.SpeseApprovatePerUtente(nomeUtente);
                        break;

                    case "6":
                        Console.WriteLine("Inserisci l'ID della categoria:");
                        int categId = int.Parse(Console.ReadLine());
                        decimal result = spesaRepo.TotaleSpesePerCategoria(categId);
                        Console.WriteLine($"Il totale è: {result}");
                        break;

                    default:
                        Console.WriteLine("Non hai inserito un valore valido");
                        break;
                }
                Console.WriteLine("Se vuoi uscire dal menù premi Q altrimenti qualsiasi altro tasto");
                if (Console.ReadLine().ToLower().Equals("q"))
                    exit = true;
                Console.Clear();
            }




            // So che il client poteva essere fatto meglio, si poteva disaccoppiare di più, astrarre e
            //      fare più controlli, gestire meglio il flusso. Però non ho avuto tempo perchè tra il
            //      testare e il risolvere qualche bug ho dovuto farlo in maniera rozza e veloce

        }
    }
}
