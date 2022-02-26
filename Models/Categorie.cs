using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Numero { get; set; }
        public int MaxTaches { get; set; }
        public virtual List<Tache>? Taches { get; set; }
    }
}