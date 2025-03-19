using parser.Models;
using PuppeteerSharp;
using parser.Parsers;
using parser.Factory;
using parser.Handlers;
using parser.Interfaces.Handlers;

public class Program
{
    static async Task Main(string[] args)
    {
        HackFactory hackFactory = new HackFactory();
        IInnerTextHandler textHandler = new InnerTextHandlerForCodeNRock();
        HackParser<Hack> hackParser = new(hackFactory, textHandler);
        var res = await hackParser.ScrapHacks("123");
    }
}

