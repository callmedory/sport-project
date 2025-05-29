namespace Sport.Models
{
    public class EmailSettings
    {
        public string SenderEmail { get; set; }
        public string SenderName { get; set; }
        public string EmailUrl { get; set; }
        public string PasswordUrl { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
    }
}