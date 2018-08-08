using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ElectoralSystem.Models;

namespace ElectoralSystem.Entities
{
    [Table("Candidates")]
    public class Candidate : ElectionEntity
    {
        public Candidate()
        {
            AcquiredVotes = new HashSet<Vote>();
        }
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Display(Name = "Nick Name")]
        [MaxLength(50)]
        public string NickName { get; set; }

        //public byte?[] Photo { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PartyId { get; set; }
        public Party Party { get; set; }

        public int ElectionId { get; set; }
        public Election Election { get; set; }

        public ICollection<Vote> AcquiredVotes { get; set; }
    }
}