using StefansSuperShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefansSuperShopTests.Services
{
    [TestClass]
    public class KrisInfoServiceTests
    {
        private KrisInfoService sut;

        public KrisInfoServiceTests()
        {
            sut = new KrisInfoService();
        }

        [TestMethod]
        public void Test_if_API_returns_list()
        {
            var lista = sut.GetAllKrisInformation();

            Assert.IsNotNull(lista);
        }
    }
}
