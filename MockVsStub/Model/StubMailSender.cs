using System.Collections.Generic;

namespace MocVsStub.Model
{
    public class StubMailSender : IMailServer
    {
        private List<MailMessage> messages = new List<MailMessage>();
        public void Send(MailMessage message)
        {
            messages.Add(message);
        }

        public int MailIsSentCount()
        {
            return messages.Count;
        }

    }
}