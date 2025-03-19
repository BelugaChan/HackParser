using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Interfaces.Models;

namespace parser.Models
{
    public class Organization : IOrganization
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string AdditionalInfo { get; set; } = string.Empty;
    }
}