using System;
using Xunit;
using FluentAssertions;
using web;

namespace test
{
    public class PropertyTest
    {
        [Fact]
        public void ShouldCreateProperty()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            testProperty.Owner.Should().Be("TestOwner");
            testProperty.City.Should().Be("TestCity");
            testProperty.State.Should().Be("TS");
            testProperty.Zipcode.Should().Be("12345");
            testProperty.Address.Should().Be("Test Address");
            testProperty.Rate.Should().Be(50);
        }
    }
}
