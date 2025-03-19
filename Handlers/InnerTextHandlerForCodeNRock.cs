using HtmlAgilityPack;
using parser.Enums;
using parser.Interfaces.Handlers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace parser.Handlers
{
    public class InnerTextHandlerForCodeNRock: IInnerTextHandler
    {
        public DateTime ToDateTimeFromInnerText(string date, string format = "dd MMMM yyyy") //format: (dd MMMM yyyy)
        {
            ArgumentException.ThrowIfNullOrEmpty(format);
            var cultureInfo = new CultureInfo("ru-RU");
            var dateTime = DateTime.ParseExact(date.TrimEnd().TrimStart(), format, cultureInfo); 
            return dateTime;
        }

        public int ToPriseFromInnerText(string prise)
        {
            string matched = Regex.Match(prise, @"\b\d{1,3}(?:\s*\d{3})*").Value.Replace(" ", "");
            return int.Parse(matched);
        }

        public HackType ToHackTypeFromInnerText(string format)
        {
            return format switch
            {
                "Онлайн" => HackType.Online,
                "Офлайн" => HackType.Offine,
                "Онлайн / Офлайн" => HackType.Hybrid,
                _ => HackType.NoInfo,
            };
        }

        public List<int> ToLimitFromInnerText(string limit)
        {
            var matches = Regex.Matches(limit, @"\d+");
            if(matches.Count == 0)
                return [1,1];
            List<int> res = new();
            foreach (Match match in matches)
            {
                res.Add(int.Parse(match.Value));
            }
            return res;
        }
    }
}
