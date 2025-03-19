using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.Interfaces.Models;

namespace parser.Interfaces.Handlers
{
    public interface ILoader
    {
        void LoadData<THack>(List<THack> values)
            where THack : IHack;
    }
}