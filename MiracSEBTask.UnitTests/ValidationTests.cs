using MiracSEBTask.Dtos;
using MiracSEBTask.Actions;

namespace MiracSEBTask.UnitTests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void ValidateCreateCustomerDto_DtoIsNull_False()
        {
            //Arrange
            CreateCustomerDto customerDto = null;

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateCreateCustomerDto_SocialSecurityNumberIsNull_False()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber=null,
                EmailAddress="test@test.com",
                PhoneNumber="+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateCreateCustomerDto_SocialSecurityNumberIsNot10or12digits_False()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "123456",
                EmailAddress = "test@test.com",
                PhoneNumber = "+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_SocialSecurityNumber10digits_True()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "8101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_SocialSecurityNumber12digits_True()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_EmailDoesnotcontainetsign_False()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "testtest.com",
                PhoneNumber = "+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_Emailcontainsetsign_True()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "+46731234567"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_PhoneNumberDigitNot9or12_False()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "731235"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_PhoneNumberDigit9_True()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "123456789"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_PhoneNumberDigit12Doesnotstartwithplus46_False()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "123456789012"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void ValidateCreateCustomerDto_PhoneNumberDigit12startswithplus46_True()
        {
            //Arrange
            CreateCustomerDto customerDto = new()
            {
                SocialSecurityNumber = "198101015660",
                EmailAddress = "test@test.com",
                PhoneNumber = "+46123456789"
            };

            //Act
            var result = ValidateData.ValidateCreateCustomerDto(customerDto);

            //Assert
            Assert.IsTrue(result);
        }
    }
}