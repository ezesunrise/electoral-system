using ElectoralSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectoralSystem.Entities
{
    [Table("Voters")]
    public class Voter
    {
        public Voter()
        {
            Votes = new HashSet<Vote>();
        }
        [Key]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
                
        public bool HasVoted {
            get { return Votes?.Count > 0; }
        }

        public ICollection<Vote> Votes { get; set; }
    }
}