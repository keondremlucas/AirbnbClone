using System;
using Xunit;
using web;
using FluentAssertions;

namespace test.Models
{
    public class BookingTest
    {
        [Fact]
        public void ShouldCreateBooking()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            var testDate1 = "10/10/2021 8:30:52 AM";
            var testDate2 = "10/17/2021 8:30:52 AM";
            DateTime date1 = DateTime.Parse(testDate1, System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.Parse(testDate2, System.Globalization.CultureInfo.InvariantCulture);
            BookingDto testBookDto = new() { StartDate = date1, EndDate = date2, PropertyGuid = new Guid() };
            Booking testBook = new Booking(testBookDto, testProperty);

            testBook.Property.Should().Be(testProperty);
            testBook.StartDate.Should().Be(date1);
            testBook.EndDate.Should().Be(date2);
            testBook.Cost.Should().Be(50 * (date2 - date1).Days);
        }
    }
}
