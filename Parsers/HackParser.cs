using parser.DTO;
using parser.Interfaces.Factory;
using parser.Interfaces.Handlers;
using parser.Interfaces.Models;
using parser.Interfaces.Parsers;
using parser.Models;
using PuppeteerSharp;

namespace parser.Parsers
{
    public class HackParser<THack> : IHackParser<THack>
        where THack : IHack
    {
        private static List<THack> hacks = new();
        private readonly IHackFactory<THack> factory;
        private readonly IInnerTextHandler textHandler;
        public HackParser(IHackFactory<THack> factory, IInnerTextHandler textHandler)
        {
            this.factory = factory;
            this.textHandler = textHandler;
        }

        public async Task<List<THack>> ScrapHacks(string query, string siteName = "https://codenrock.com/")
        {
            ArgumentException.ThrowIfNullOrEmpty(siteName);

            await new BrowserFetcher().DownloadAsync();

            var launchOptions = new LaunchOptions()
            {
                Headless = false
            };

            using var browser = await Puppeteer.LaunchAsync(launchOptions);
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(siteName);

                await page.WaitForSelectorAsync("li.panel.panel-default");

                var hacksData = await page.QuerySelectorAllAsync("li.panel.panel-default");
                foreach (var hackData in hacksData)
                {
                    var infoElement = await GetElement("h2.contest-name", hackData);
                    var descriptionElement = await GetElement("xpath//.//div/a/article/div", hackData);
                    var priseElement = await GetElement("xpath//.//div/a/article/ul/li[6]", hackData);
                    var teamLimitElement = await GetElement("xpath//.//div/a/article/ul/li[5]/div/div", hackData);
                    var dateElement = await GetElement("xpath//.//div/a/article/ul/li[2]/div/span[2]", hackData);
                    var formatElement = await GetElement("xpath//.//div/a/article/ul/li[4]/div/span[2]", hackData);

                    var info = await GetInnerText(infoElement);
                    var description = await GetInnerText(descriptionElement);
                    var prise = await GetInnerText(priseElement);
                    var teamLimit = await GetInnerText(teamLimitElement);
                    var date = await GetInnerText(dateElement);
                    var format = await GetInnerText(formatElement);

                    var teamLimits = textHandler.ToLimitFromInnerText(teamLimit);
                    string[] dates = date.Split('-');
                    List<DateTime> dateTimeDates = new();
                    foreach (var item in dates)
                    {
                        dateTimeDates.Add(textHandler.ToDateTimeFromInnerText(item));
                    }
                    var hack = factory.Create(new HackCreationParameters()
                    {
                        Id = Guid.NewGuid(),
                        Description = description,
                        Info = info,
                        Prise = textHandler.ToPriseFromInnerText(prise),
                        MinLimitPeopleForTeams = teamLimits[0],
                        MaxLimitPeopleForTeams = teamLimits[1],
                        DateStart = dateTimeDates[0],
                        DateEnd = dateTimeDates[1],
                        Format = textHandler.ToHackTypeFromInnerText(format),
                        Owner = new Organization()
                        {
                            Id = Guid.NewGuid()
                        }
                    });

                    hacks.Add(hack);
                }
            }
            return hacks;
        }

        private async Task<IElementHandle?> GetElement(string query, IElementHandle? element)
        {
            return await element.QuerySelectorAsync(query);
        }
        private async Task<string?> GetInnerText(IElementHandle? element)
        {
            if (element is null)
                return string.Empty;
            return (await element.GetPropertyAsync("innerText")).RemoteObject.Value.ToString();
        }
    }
}