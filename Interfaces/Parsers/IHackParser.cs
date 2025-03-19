using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Interfaces.Models;

namespace parser.Interfaces.Parsers
{
    public interface IHackParser<THack>
        where THack : IHack
    {
        Task<List<THack>> ScrapHacks(string query, string siteName);

    }
}