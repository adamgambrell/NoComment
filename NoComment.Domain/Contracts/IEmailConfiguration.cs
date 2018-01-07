namespace NoComment.Domain.Contracts {
    public interface IEmailConfiguration {
        string Password { get; set; }
        string Username { get; set; }

        string SmtpServer { get; }
        int SmtpPort { get; }

        string ImapServer { get; }
        int ImapPort { get; }
    }
}