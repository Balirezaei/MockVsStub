using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MocVsStub.Model;
using NSubstitute;
using Xunit;

namespace MocVsStub.Test
{
    public class MocVsStubUnitTest
    {
        private static String product = "IPhoneX";

        [Fact]
        public void StubSubmitOrderCheckMailSending()
        {
            Order order = new Order(product, 50);
            var stubMailServer = new StubMailSender();
            order.SetMailer(stubMailServer);

            order.Submit();

            Assert.Equal(1, stubMailServer.MailIsSentCount());
        }

        [Fact]
        public void MockSubmitOrderCheckMailSending()
        {
            Order order = new Order(product, 50);

            var mockMailServer = NSubstitute.Substitute.For<IMailServer>();
            order.SetMailer(mockMailServer);


            order.Submit();

            mockMailServer.Received(1).Send(order.mailMessage);

        }
    }
}
