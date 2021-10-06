using System;
using Xunit;
using FluentAssertions;
using web;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public class PropertyDtoTest
    {
        [Fact]
        public void ShouldCreateDto()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            var context = new ValidationContext(testPropDto);
            Action act = () => Validator.ValidateObject(testPropDto, context, true);
            act.Should().NotThrow();
        }

        [Fact]
        public void PropertyDtoShouldFailValidaton()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "BADSTATE", Zipcode = "12345", Address = "Test Address", Rate = 50 };

            var context = new ValidationContext(testPropDto);
            Action act = () => Validator.ValidateObject(testPropDto, context, true);
            act.Should().Throw<ValidationException>();
        }
    }
}
