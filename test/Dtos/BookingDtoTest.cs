using System;
using Xunit;
using web;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace test
{
    public class BookingDtoTest
    {
        [Fact]
        public void ShouldCreateDto()
        {
            var testDate1 = "10/10/2021 8:30:52 AM";
            var testDate2 = "10/17/2021 8:30:52 AM";
            DateTime date1 = DateTime.Parse(testDate1, System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.Parse(testDate2, System.Globalization.CultureInfo.InvariantCulture);
            BookingDto testbookingDto = new() { StartDate = date1, EndDate = date2, PropertyGuid = new Guid() };
            var context = new ValidationContext(testbookingDto);
            Action act = () => Validator.ValidateObject(testbookingDto, context, true);
            act.Should().NotThrow();
        }
    }
}