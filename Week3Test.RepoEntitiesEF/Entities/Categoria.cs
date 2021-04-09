using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Week3Test.RepoEntitiesEF.Entities
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [MaxLength(100)]
        public string CategoriaNome { get; set; }
        public virtual ICollection<Spesa> Spese { get; set; } = new List<Spesa>();

        // Io ho inteso che le spese possono appartenere a delle categorie diverse tipo 
        //      una spesa di genere cancelleria, una di genere alimentari, una di genere 
        //      intrattenimento, viaggio ecc.. e quindi ogni spesa può appartenere ad una ed 
        //      una sola categoria. Per questo ho fatto 1:N (1 Categoria : N Spese)
    }
}
