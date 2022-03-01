using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public int? Indicateur { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Badge> Badges { get; set; }
    }
}