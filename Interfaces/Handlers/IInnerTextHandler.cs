using parser.Enums;

namespace parser.Interfaces.Handlers
{
    public interface IInnerTextHandler
    {
        DateTime ToDateTimeFromInnerText(string date, string format = "dd MMMM yyyy");
        int ToPriseFromInnerText(string prise);
        HackType ToHackTypeFromInnerText(string format);

        List<int> ToLimitFromInnerText(string limit);
    }
}
