using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Enums;
using parser.Models;

namespace parser.Interfaces.Models
{
    public interface IHack
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public int? Prise { get; set; }

        public Organization? Owner { get; set; }

        public int MinLimitPeopleForTeams { get; set; }

        public int MaxLimitPeopleForTeams { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public HackType HackType { get; set; }

        public string Info { get; set; }

        public bool IsEnded { get; set; }
    }
}