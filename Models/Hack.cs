using parser.Enums;
using parser.Interfaces.Models;

namespace parser.Models
{
    public class Hack : IHack
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;

        public int? Prise { get; set; }

        public Organization? Owner { get; set; }

        public int LimitPeopleForTeams { get; set; }

        public DateTimeOffset? DateStart { get; set; }

        public DateTimeOffset? DateEnd { get; set; }

        public HackType HackType { get; set; }

        public string Info { get; set; } = string.Empty;

        public bool IsEnded { get; set; } = false;
    }
}