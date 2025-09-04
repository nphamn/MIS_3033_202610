

using Cereal_Problem;
using System.Xml.Linq;
//string fileContents = File.ReadAllText("Creal_Data.txt");

//string[] linesOfFile = File.ReadAllLines("Cereal_Data.txt");

List<Cereal> allCereals = new List<Cereal>();
string[] linesOfFile = File.ReadAllLines("Cereal_Data.txt");

for (int i = 1; i<linesOfFile.Length; i++)
{
    //"name | manufacturer | calories | cups"
    string line = linesOfFile[i];
    string[] parts = line.Split("|");

    Cereal c = new Cereal();
    c.Name = parts[0];
    c.Manufacturer = parts[1];
    c.Calories = double.Parse(parts[2]);    
    c.Cups = double.Parse(parts[3]);

    allCereals.Add(c);

}

foreach (var cereal in allCereals)
{
    if (cereal.Cups >=1)
    {
        Console.WriteLine(cereal);
    }
}