using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ElectoralSystem.Models;

namespace ElectoralSystem.Entities
{
    [Table("Elections")]
    public class Election
    {
        public Election()
        {
            Candidates = new HashSet<Candidate>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Title { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
        
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Is Open")]
        public bool IsOpen {
            get
            {
                return (StartDate <= DateTime.Now.ToLocalTime()) && (DateTime.Now.ToLocalTime() < EndDate);
            }
        }

        public ICollection<Candidate> Candidates { get; set; }
    }
}