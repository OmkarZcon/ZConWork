using Azure;
using Azure.Data.Tables;


namespace AzureTableStorage.Functions
{
    public class PropertyEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public PropertyEntity() { }
        public PropertyEntity(string propertyType, string propertyId, string address, double price)
        {
            PartitionKey = propertyType;
            RowKey = propertyId;
            Address = address;
            Price = price;
        }
    }
}
