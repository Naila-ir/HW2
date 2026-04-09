using System.Xml.Serialization;

namespace HW_2;

[XmlRoot("BotanicalGarden")]
public class BotanicalGardenFile
{
    [XmlArray("Plants")]
    [XmlArrayItem("Plant")]
    public List<GardenPlant> Plants { get; set; } = [];
}

public class GardenPlant
{
    public string Name { get; set; } = string.Empty;

    public string LatinName { get; set; } = string.Empty;

    public string Family { get; set; } = string.Empty;

    public string PlantType { get; set; } = string.Empty;

    public int AgeYears { get; set; }

    public bool IsRare { get; set; }

    public string Description { get; set; } = string.Empty;

    public GardenLocation Location { get; set; } = new();

    public GardenCare Care { get; set; } = new();
}

public class GardenLocation
{
    public string Greenhouse { get; set; } = string.Empty;

    public string Section { get; set; } = string.Empty;

    public string BedNumber { get; set; } = string.Empty;
}

public class GardenCare
{
    public string Watering { get; set; } = string.Empty;

    public string Light { get; set; } = string.Empty;

    public string Temperature { get; set; } = string.Empty;

    public string Soil { get; set; } = string.Empty;
}
