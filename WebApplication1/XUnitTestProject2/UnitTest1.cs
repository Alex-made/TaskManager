
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
        //���� �� ������� ��������� ��� ������ ���������� ��� ���������� � �� null �������
        //[Theory]
        //public void UpdateTaskNullObjectMessage()
        //{
        //    //������� ��� ������ � ������� ����� UpdateUser
        //    //������� ����������            
        //    //������� ����� UpdateUser(null)
        //    //�������� ��������� ��������� � ���������� �� ������
        //}

    }
}
