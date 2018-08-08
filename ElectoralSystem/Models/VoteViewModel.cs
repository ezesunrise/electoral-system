using ElectoralSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoralSystem.Models
{
    public class VoteViewModel
    {
        public ICollection<Vote> Votes { get; set; }
        public Election Election { get; set; }
    }
}