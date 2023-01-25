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
    [Testclass]
    internal class ContactTests : Pages_ContactUs_Contact
    {
        private Pages_ContactUs_Contact sut; //SYSTEM UNDER TEST

        public ContactTests()
        {
            sut = new Pages_ContactUs_Contact();
        }

        [TestMethod]
        public void Test_if_email_is_sent()
        {
            //Arrange
            var name = "batman";
            var email = "batman@batcave.com";
            var subject = "subject";
            var text = "Hej";


            //Act
            var result = sut.SendEmailMailTrap();
            //Assert
        }
    }
}
