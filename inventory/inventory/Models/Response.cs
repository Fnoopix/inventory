using Google.Protobuf;

namespace inventory.Models
{
    public class Response
    {
        public class InventoryDeviceResponse
        {
            
            public Inventory.Device Device { get; set; }
            public string Exception { get; set; }
            public string ExceptionText { get; set; }
            public bool Success { get; set; }
        }
    }
}