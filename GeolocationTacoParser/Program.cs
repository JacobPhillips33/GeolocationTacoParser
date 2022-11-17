using GeolocationTacoParser;
using GeoCoordinatePortable;

ILog logger = new TacoLogger();
const string csvPath = "TacoBell-US-AL.csv";
const double metersToMiles = .00062137;

logger.LogInfo("Log initialized");
Console.WriteLine();

var lines = File.ReadAllLines(csvPath);

if (lines.Length < 2)
{
    if (lines.Length < 1)
    {
        logger.LogError("No lines found in csv file.");
    }
    logger.LogWarning("Only 1 line found in csv file.");
}

Console.Write("Would you like to see all of the Taco Bells in the csv file? yes/no: ");
var userInput = Console.ReadLine().ToLower();
Console.WriteLine();

if (userInput != "yes" && userInput != "no")
{
    Console.Write("Invalid entry. Please answer \"yes\" or \"no\": ");
    userInput = Console.ReadLine().ToLower();
    Console.WriteLine();
}

if (userInput == "yes")
{
    Console.Write("Retrieving data");
    for (int i = 0; i < 9; i++)
    {
        Console.Write(". ");
        Thread.Sleep(500);
    }
    Console.WriteLine();

    for (int i = 0; i < lines.Length; i++)
    {
        logger.LogInfo($"Lines: {lines[i]}");
    }
    Console.WriteLine();
}

Console.Write("Press ENTER to begin parsing: ");
Console.ReadLine();
Console.WriteLine();

logger.LogInfo("Begin parsing");
Console.WriteLine();
Console.Write("Calculating");
for (int i = 0; i < 9; i++)
{
    Console.Write(". ");
    Thread.Sleep(500);
}
Console.WriteLine();
Console.WriteLine();

var parser = new TacoParser();

var locations = lines.Select(parser.Parse).ToArray();

ITrackable tacoBell1 = new TacoBell();
ITrackable tacoBell2 = new TacoBell();
double distance = 0;

var corA = new GeoCoordinate();
var corB = new GeoCoordinate();
foreach (var locA in locations)
{
    corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
    foreach (var locB in locations)
    {
        corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
        if (distance < corA.GetDistanceTo(corB))
        {
            distance = corA.GetDistanceTo(corB);
            tacoBell1 = locA;
            tacoBell2 = locB;
        }
    }
}

var milesApart = Math.Round(distance * metersToMiles, 2);

Console.WriteLine("***********************************************************************");
Console.WriteLine();

logger.LogInfo($"{tacoBell1.Name} and {tacoBell2.Name} are farthest away from each other.");
Console.WriteLine();
logger.LogInfo($"They are {milesApart} miles apart.");

Console.WriteLine();
Console.WriteLine("***********************************************************************");