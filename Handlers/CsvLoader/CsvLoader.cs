using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Interfaces.Handlers;
using parser.Interfaces.Models;

namespace parser.Handlers.CsvLoader
{
    public class CsvHandler : ILoader
    {
        public void LoadData<THack>(List<THack> values) where THack : IHack
        {

        }
    }
}