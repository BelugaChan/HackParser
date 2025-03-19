// See https://aka.ms/new-console-template for more information
using parser.Models;
using PuppeteerSharp;
using parser.Parsers;
using parser.Factory;

HackFactory hackFactory = new HackFactory();
HackParser<Hack> hackParser = new(hackFactory);
var res = await hackParser.ScrapHacks("123");

