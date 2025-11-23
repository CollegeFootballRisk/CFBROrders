using CFBROrders.Web.Interfaces.Handlers;

namespace CFBROrders.Web.Handlers
{
    public class ColorHandler : IColorHandler
    {
        public string GetContrastColor(string hexColor)
        {
            hexColor = hexColor.Replace("#", "");

            int r = Convert.ToInt32(hexColor[..2], 16);
            int g = Convert.ToInt32(hexColor.Substring(2, 2), 16);
            int b = Convert.ToInt32(hexColor.Substring(4, 2), 16);

            double luminance = (0.299 * r + 0.587 * g + 0.114 * b);

            return luminance > 150 ? "black" : "white";
        }

    }
}
