namespace MocVsStub.Model
{
    public class Order
    {
        private readonly string _product;
        private readonly int _size;
        private IMailServer _mailServer;
        public MailMessage mailMessage;
        public Order(string product, int size)
        {
            _product = product;
            _size = size;
        }

        public void Submit()
        {
            mailMessage = new MailMessage();
            //Do Somthing
            _mailServer.Send(mailMessage);
        }

        public void SetMailer(IMailServer mailServer)
        {
            _mailServer = mailServer;
        }


    }
}