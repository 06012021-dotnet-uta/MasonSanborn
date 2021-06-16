using System;
using Xunit;

namespace RpsGame.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arange
            int x = 5;
            int y = 6;


            // Act
            int z = x + y;

            // Assert
            Assert.Equal(11, z);
        }

        [Fact]
        public void testPrivate()
        {
            // Arrange
            //RockPaperScissorsV1.RpsGame game = new RockPaperScissorsV1.RpsGame();
            //PrivateObject obj = new PrivateObject(typeof(RpsGame));

            //MethodInfo methodInfo = typeof(game).GetMethod("privateMethodTest");

            // Act 
            //bool Result = Convert.ToBoolean(obj.Invoke("privateMethodBoolTest", -1));

            // Assert
            //Assert.AreEqual(true, Result);
            //Assert.IsType()
        }
    }
}
