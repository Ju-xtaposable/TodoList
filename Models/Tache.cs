using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    [Table("Tache")]
    public class Tache
    {
        [Key]
        public int Id { get; set;}
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateCible { get; set; }
        public bool Archivée { get; set; }
        public virtual Categorie? Categorie { get; set; }
        public virtual List<Badge>? Badges { get; set; }
    }
}