namespace WhatsAppMessaging.Models
{
    public class WhatsMessage
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string MediaUrl { get; set; }
        public string Caption { get; set; }
        public string AudioUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Address { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
