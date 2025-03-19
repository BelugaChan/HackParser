using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using parser.DTO;
using parser.Interfaces.Factory;
using parser.Models;

namespace parser.Factory
{
    public class HackFactory : IHackFactory<Hack>
    {
        public Hack Create(HackCreationParameters creationParameters)
        {
            return new Hack()
            {
                Id = Guid.NewGuid(),
                Info = creationParameters.Info,
                Description = creationParameters.Description,
                DateStart = creationParameters.DateStart,
                DateEnd = creationParameters.DateEnd,
                HackType = creationParameters.Format,
                MinLimitPeopleForTeams = creationParameters.MinLimitPeopleForTeams,
                MaxLimitPeopleForTeams = creationParameters.MaxLimitPeopleForTeams,
                Prise = creationParameters.Prise,
                Owner = creationParameters.Owner,
            };
        }
    }
}