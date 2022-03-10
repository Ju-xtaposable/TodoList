using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Badge>? Badges { get; set; }
    }
}