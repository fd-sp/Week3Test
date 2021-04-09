using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Week3Test.RepoEntitiesEF.Entities
{
    public class Spesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpeseId { get; set; }
        public DateTime Data { get; set; }

        [MaxLength(500)]
        public string Descrizione { get; set; }

        [MaxLength(100)]
        public string Utente { get; set; }
        public decimal Importo { get; set; }
        public bool Approvato { get; set; } = false;
        public virtual int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public virtual Categoria Categoria { get; set; }

    }
}
