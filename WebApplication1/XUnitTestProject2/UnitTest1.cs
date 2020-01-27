
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Util;
using WebApplication1.Models;
using System.Configuration;
using Xunit;
using Moq;

namespace XUnitTestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void IndexActionResultNotNull()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            HomeController homeController = new HomeController(mock.Object);
            //Act
            var result = homeController.Index();
            //Assert
            //Assert.NotNull(result);
            
        }
        //тест на возврат сообщения при отлове исключения при сохранении в БД null объекта
        //[Theory]
        //public void UpdateTaskNullObjectMessage()
        //{
        //    //создать мок объект и описать метод UpdateUser
        //    //создать контроллер            
        //    //вызвать метод UpdateUser(null)
        //    //сравнить ожидаемое сообщение с сообщением от метода
        //}

    }
}
