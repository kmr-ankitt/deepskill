using CustomerCommLib;
using Moq;
using NUnit.Framework;

namespace CustomerCommLib.Tests;

[TestFixture]
public class CustomerCommTests
{
    private Mock<IMailSender> mockMailSender;
    private CustomerComm customerComm;

    [OneTimeSetUp]
    public void Init()
    {
        // Create mock object
        mockMailSender = new Mock<IMailSender>();

        // Inject mock into CustomerComm
        customerComm = new CustomerComm(mockMailSender.Object);
    }

    [TestCase]
    public void SendMailToCustomer_ReturnsTrue()
    {
        // Arrange
        mockMailSender
            .Setup(x => x.SendMail(It.IsAny<string>(),
                                   It.IsAny<string>()))
            .Returns(true);

        // Act
        bool result = customerComm.SendMailToCustomer();

        // Assert
        Assert.That(result, Is.True);
    }
}