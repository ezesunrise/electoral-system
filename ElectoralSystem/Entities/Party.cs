using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ElectoralSystem.Models;

namespace ElectoralSystem.Entities
{
    [Table("Party")]
    public class Party: ElectionEntity
    {
        public Party()
        {
            Candidates = new HashSet<Candidate>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
        
        public ICollection<Candidate> Candidates { get; set; }
    }
}