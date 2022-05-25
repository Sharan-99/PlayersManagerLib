using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using PlayersManagerLib;

namespace PlayerManager.Tests
{
    [TestFixture]
    public class PlayerMapperTests
    {
        Mock<IPlayerMapper> ipm;
        [OneTimeSetUp]
        public void Initialize()
        {
            ipm = new Mock<IPlayerMapper>();
        }
        [Test]
        public void RegisterNewPlayer_WhenCalled_ReturnsCorrectPlayerNameThatIsInserted()
        {
            ipm.Setup(obj=>obj.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
            var playerMapper = ipm.Object;

            // var result=playerMapper.RegisterNewPlayer()
            var player = new Player("Sharan",23,"India",30);
            var result = Player.RegisterNewPlayer("Sharan",playerMapper);
            Assert.That(result.Name, Is.EqualTo("Sharan"));

        }

        [Test]
        public void RegisterNewPlayer_WhenCalledWithNullPlayerName_ThrowsException()
        {

            ipm.Setup(obj => obj.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(false);
            var playerMapper = ipm.Object;
            //var player = new Player("Syed", 23, "India", 30);
            // var result = Player.RegisterNewPlayer("", playerMapper);
            //Assert.That(() => result,Is.TypeOf<ArgumentException>());

            Assert.Throws<ArgumentException>(() =>
            {
                var result = Player.RegisterNewPlayer("", playerMapper);
            });


        }

        [Test]
        public void RegisterNewPlayer_WhenCalledWithExisitingPlayerName_ThrowsException()
        {
            
            ipm.Setup(obj => obj.IsPlayerNameExistsInDb(It.IsAny<string>())).Returns(true);
            var playerMapper = ipm.Object;
            var player = new Player("Syed", 23, "India", 30);
            //var result = Player.RegisterNewPlayer("Syed", playerMapper);
            //  Assert.That(() => result, Throws.ArgumentException);
            Assert.Throws<ArgumentException>(() =>
            {
                var result = Player.RegisterNewPlayer("Syed", playerMapper);
            });


        }

        

    }
}
