using System;
using Xunit;
using web;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace test
{
    public class PropertyRepositoryTest
    {
        private Database _db;
        private IPropertyRepository _repo;

        public PropertyRepositoryTest()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
            _db = new Database(options);
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _repo = new PropertyRepository(_db);
        }

        [Fact]
        public async Task ShouldSavePropertyToDatabase()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            await _repo.AddAsync(testProperty);
            await _repo.SaveAsync();
            _db.Properties.Count().Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetAllProperties()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            PropertyDto testPropDto2 = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty2 = new Property(testPropDto2);
            await _repo.AddAsync(testProperty);
            await _repo.AddAsync(testProperty2);
            await _repo.SaveAsync();

            var properties = await _repo.GetAllAsync();
            properties.Should().HaveCount(2);
        }

        [Fact]
        public async Task ShouldSearchById()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            PropertyDto testPropDto2 = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty2 = new Property(testPropDto2);
            testProperty.Id = Guid.Parse("f104f46e-fcc6-4e57-bb06-435944e33e6b");
            await _repo.AddAsync(testProperty);
            await _repo.AddAsync(testProperty2);
            await _repo.SaveAsync();

            var properties = await _repo.SearchByIdAsync(Guid.Parse("f104f46e-fcc6-4e57-bb06-435944e33e6b"));
            properties.Id.ToString().Should().Be("f104f46e-fcc6-4e57-bb06-435944e33e6b");
        }

        [Fact]
        public async Task ShouldSearchByOwner()
        {
            PropertyDto testPropDto = new() { Owner = "TestOwner", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty = new Property(testPropDto);
            PropertyDto testPropDto2 = new() { Owner = "TestOwner2", City = "TestCity", State = "TS", Zipcode = "12345", Address = "Test Address", Rate = 50 };
            Property testProperty2 = new Property(testPropDto2);
            await _repo.AddAsync(testProperty);
            await _repo.AddAsync(testProperty2);
            await _repo.SaveAsync();

            var properties = await _repo.SearchPropertiesByOwnerAsync("TestOwner2");

            foreach (var p in properties)
                p.Owner.Should().Be("TestOwner2");
        }


    }
}
