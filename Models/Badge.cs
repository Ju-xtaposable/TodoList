using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    [Table("Badge")]
    public class Badge
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Numero { get; set; }
        // public string Group { get; set; }
        public  virtual List<Tache> Taches { get; set; }
        public  virtual List<Event> Events { get; set; }
        public  virtual List<Note> Notes { get; set; }
    }
}