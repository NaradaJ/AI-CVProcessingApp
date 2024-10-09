namespace AIProcessingService.Models
{
    public class CVVectorData
    {
        public int Id { get; set; }
        public byte[] Vector { get; set; }
        public int CVId { get; set; }
    }
}
