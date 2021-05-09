namespace inventory.Models
{
    public class Inventory
    {
        public class Device
        {
            public string id { get; set; }
            public string name { get; set; }
            public string deviceTypeId { get; set; }
            public bool failsafe { get; set; }
            public double tempMin { get; set; }
            public double tempMax { get; set; }
            public string installationPosition { get; set; }
            public bool insertInto19InchCabinet { get; set; }
            public bool motionEnable { get; set; }
            public bool siplusCatalog { get; set; }
            public bool simaticCatalog { get; set; }
            public double rotationAxisNumber { get; set; }
            public double positionAxisNumber { get; set; }
            public bool terminalElement { get; set; }
            public bool advancedEnvironmentalConditions { get; set; }
        }
    }
}