using ElectoralSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ElectoralSystem.Entities
{
    [Table("Votes")]
    public class Vote : ElectionEntity
    {
        public string VoterId { get; set; }
        public int CandidateId { get; set; }
        
        public Voter Voter { get; set; }
        public Candidate Candidate { get; set; }

    }
}