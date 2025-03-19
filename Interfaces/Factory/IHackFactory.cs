using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.DTO;
using parser.Interfaces.Models;

namespace parser.Interfaces.Factory
{
    public interface IHackFactory<THack>
        where THack : IHack
    {
        THack Create(HackCreationParameters creationParameters);
    }
}