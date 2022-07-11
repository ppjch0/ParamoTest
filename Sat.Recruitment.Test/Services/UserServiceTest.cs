using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sat.Recruitment.Entity.Entities;
using Sat.Recruitment.Entity.Interfaces.Repositories;
using Sat.Recruitment.Entity.Interfaces.Services;
using Sat.Recruitment.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Test.Services
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _userService;

        private Mock<IUserRepository> _userRepository;

        [TestInitialize]
        public void SetUp()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        [TestMethod]
        public void OnCreateUser_DuplicatedEmail_ReturnResultError()
        {
            //init
            var user = new NormalUser
            {
                Address = "Calle 25 nro 50",
                Email = "carlos@mail.com",
                Money = 50,
                Name = "Carlos",
                Phone = "50603070"
            };
            _userRepository.Setup(x => x.GetAll())
                        .Returns(Task.FromResult(
                                (
                                    IEnumerable<User>)(new List<User>()
                                    {
                                        new NormalUser() {
                                            Name = "carlos paz",
                                            Email = "carlos@mail.com",
                                            Address = "CALLE 38 nro 1005 ",
                                            Phone = "4500-4458"
                                        }
                                    })));

            //act
            var result = _userService.Create(user).GetAwaiter().GetResult(); ;

            //assert
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.Errors, "User is duplicated");
        }

        [TestMethod]
        public void OnCreateUser_DuplicatedName_ReturnResultError()
        {
            //init
            var user = new NormalUser
            {
                Address = "Calle 25 nro 50",
                Email = "carlos@mail.com",
                Money = 50,
                Name = "Carlos",
                Phone = "50603070"
            };
            _userRepository.Setup(x => x.GetAll())
                        .Returns(Task.FromResult(
                                (
                                    IEnumerable<User>)(new List<User>() 
                                    { 
                                        new NormalUser() { 
                                            Name = "carlos ",
                                            Email = "carlospaz@mail.com",
                                            Address = "CALLE 38 nro 1005 ",
                                            Phone = "4500-4458"
                                        } 
                                    })));

            //act
            var result = _userService.Create(user).GetAwaiter().GetResult(); ;

            //assert
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.Errors, "User is duplicated");
        }

        [TestMethod]
        public void OnCreateUser_DuplicatedAddress_ReturnResultError()
        {
            //init
            var user = new NormalUser
            {
                Address = "Calle 25 nro 50",
                Email = "carlos@mail.com",
                Money = 50,
                Name = "Carlos",
                Phone = "50603070"
            };
            _userRepository.Setup(x => x.GetAll())
                            .Returns(Task.FromResult(
                                (
                                    IEnumerable<User>)(new List<User>()
                                    {
                                        new NormalUser() {
                                            Name = "carlos paz",
                                            Email = "carlospaz@mail.com",
                                            Address = "CALLE 25 NRO 50 ",
                                            Phone = "4500-4458"
                                        }
                                    })));

            //act
            var result = _userService.Create(user).GetAwaiter().GetResult(); ;

            //assert
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.Errors, "User is duplicated");
        }

        [TestMethod]
        public void OnCreateUser_DuplicatedPhone_ReturnResultError()
        {
            //init
            var user = new NormalUser
            {
                Address = "Calle 25 nro 50",
                Email = "carlos@mail.com",
                Money = 50,
                Name = "Carlos",
                Phone = "50603070"
            };
            _userRepository.Setup(x => x.GetAll())
                        .Returns(Task.FromResult(
                                (
                                    IEnumerable<User>)(new List<User>()
                                    {
                                        new NormalUser() {
                                            Name = "carlos paz",
                                            Email = "carlospaz@mail.com",
                                            Address = "CALLE 38 nro 1005 ",
                                            Phone = "50603070"
                                        }
                                    })));

            //act
            var result = _userService.Create(user).GetAwaiter().GetResult(); ;

            //assert
            Assert.IsFalse(result.IsSuccess);
            Assert.AreEqual(result.Errors, "User is duplicated");
        }

        [TestMethod]
        public void OnCreateUser_NormalUser_ReturnResultSuccess()
        {
            //init
            var user = new NormalUser
            {
                Address = "Calle 25 nro 50",
                Email = "carlos@mail.com",
                Money = 50,
                Name = "Carlos",
                Phone = "50603070"
            };
            _userRepository.Setup(x => x.GetAll())
                        .Returns(Task.FromResult(
                                (
                                    IEnumerable<User>)(new List<User>()
                                    {
                                        new NormalUser() {
                                            Name = "carlos paz",
                                            Email = "carlospaz@mail.com",
                                            Address = "CALLE 38 nro 1005 ",
                                            Phone = "4580-0011"
                                        }
                                    })));

            //act
            var result = _userService.Create(user).GetAwaiter().GetResult(); ;

            //assert
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Errors, "User Created");
        }
    }
}
