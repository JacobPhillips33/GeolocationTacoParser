using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeolocationTacoParser
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            // Splits the csv file up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If the array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Does not fail if one record parsing fails, instead returns null
                logger.LogError("The array length was less than 3.");
                return null; 
            }

            // Grabs the latitude
            var latParseable = double.TryParse(cells[0], out double latitude);

            if (!latParseable) logger.LogError("Unable to parse latitude into a double.");

            // Grabs the longitude
            var lonParseable = double.TryParse(cells[1], out double longitude);

            if (!lonParseable) logger.LogError("Unable to parse longitude into a double.");

            var name = cells[2];

            var location = new Point()
            {
                Latitude = latitude,
                Longitude = longitude
            };

            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = location
            };

            return tacoBell;
        }
    }
}
