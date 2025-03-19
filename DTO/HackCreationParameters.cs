using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Enums;
using parser.Models;

namespace parser.DTO
{
    public class HackCreationParameters
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public int? Prise { get; set; }

        public Organization? Owner { get; set; }

        public int MinLimitPeopleForTeams { get; set; }

        public int MaxLimitPeopleForTeams { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public HackType Format { get; set; }

        public string Info { get; set; } = string.Empty;
    }
}