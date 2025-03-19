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

        public int LimitPeopleForTeams { get; set; }

        public DateTimeOffset? DateStart { get; set; }

        public DateTimeOffset? DateEnd { get; set; }

        public HackType HackType { get; set; }

        public string Info { get; set; }

        public bool IsEnded { get; set; }
    }
}