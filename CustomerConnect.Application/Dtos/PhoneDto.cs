namespace CustomerConnect.Application.Dtos
{
    public class PhoneDto : EntityDto
    {
        public Guid ClientId { get; set; }
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
    }
}
