using Microsoft.VisualStudio.TestTools.UnitTesting;
using StefansSuperShop.Pages.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace StefansSuperShopTests.Pages.ContactUs
{
    [TestClass]
    public class IndexTests
    {
        private IndexModel sut; //SYSTEM UNDER TEST

        public IndexTests()
        {
            sut = new IndexModel();
        }
#if DEBUG
        [TestMethod]
        public void Test_if_email_is_sent_ethereal()
        {
            //Arrange
            var name = "batman";
            var email = "batman@batcave.com";
            var subject = "subject";
            var text = "Hej";
            var expected = true;

            //Act
            var result = sut.SendEmailEthereal(name, email, subject, text);

            //Assert
            Assert.AreEqual(expected, result);
        }
#endif
#if RELEASE
        [TestMethod]
        public void Test_if_email_is_sent_mailtrap()
        {
            //Arrange
            var name = "batman";
            var email = "batman@batcave.com";
            var subject = "subject";
            var text = "Hej";
            var expected = true;

            //Act
            var result = sut.SendEmailMailTrap(name, email, subject, text);

            //Assert
            Assert.AreEqual(expected, result);
        }
#endif
    }

}
