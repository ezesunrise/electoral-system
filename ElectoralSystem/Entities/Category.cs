using ElectoralSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectoralSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Candidates = new HashSet<Candidate>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [StringLength(2048)]
        public string Description { get; set; }
        
        public ICollection<Candidate> Candidates { get; set; }



    }
}