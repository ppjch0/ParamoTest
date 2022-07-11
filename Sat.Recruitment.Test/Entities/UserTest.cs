using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Enums;

namespace Sat.Recruitment.Test.Services
{
    [TestClass]
    public class UserTest
    {

        [TestMethod]
        public void UserNormal_MoneyGreaterThan100_IncreaseMoney()
        {
            //init
            var user = new NormalUser
            {
                Money = 120
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 134.4m);
        }

        [TestMethod]
        public void UserNormal_MoneySmallerThan100_AndGreaterThan10_IncreaseMoney()
        {
            //init
            var user = new NormalUser
            {
                Money = 30
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 54);
        }

        [TestMethod]
        public void UserNormal_MoneyEqual10_ReturnEqualMoney()
        {
            //init
            var user = new NormalUser
            {
                Money = 10
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 10);
        }

        [TestMethod]
        public void SuperUser_MoneySmallerThan100_ReturnEqualMoney()
        {
            //init
            var user = new SuperUser
            {
                Money = 30
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 30);
        }


        [TestMethod]
        public void SuperUser_MoneyGreaterThan100_IncreaseMoney()
        {
            //init
            var user = new SuperUser
            {
                Money = 200
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 240);
        }


        [TestMethod]
        public void PremiumUser_MoneySmallerThan100_ReturnEqualMoney()
        {
            //init
            var user = new PremiumUser
            {
                Money = 100
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 100);
        }


        [TestMethod]
        public void PremiumUser_MoneyGreaterThan100_IncreaseMoney()
        {
            //init
            var user = new PremiumUser
            {
                Money = 200
            };

            //act
            user.CalculateGif();

            //assert
            Assert.AreEqual(user.Money, 600);
        }
    }
}
