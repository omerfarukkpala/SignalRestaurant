namespace SignalRWebUI.Dtos.MailDtos
{
    public class CreateMailDto
    {
        public string? ReceiverMail { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
    }
}
