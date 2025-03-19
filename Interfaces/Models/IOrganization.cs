using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parser.Interfaces.Models
{
    public interface IOrganization
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AdditionalInfo { get; set; }
    }
}