using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Models;

namespace parser.DTO
{
    public class HackCreationParameters
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public int? Prise { get; set; }

        public Organization? Owner { get; set; }

        public int LimitPeopleForTeams { get; set; }

        public DateTimeOffset DateStart { get; set; }

        public DateTimeOffset DateEnd { get; set; }

        public string Info { get; set; } = string.Empty;
    }
}