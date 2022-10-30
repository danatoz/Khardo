using BL;
using Microsoft.EntityFrameworkCore;

namespace Tests.BL
{
	public class TestBaseDal
	{
		[Fact]
		public async Task GetAll_NotBeNullTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			moq.Setup(services => services.GetAsync()).ReturnsAsync(mockCities);

			var result = await moq.Object.GetAsync();

			result.Should().NotBeNull();
		}		

		[Fact]
		public async Task GetAll_OfTypeTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			moq.Setup(services => services.GetAsync()).ReturnsAsync(mockCities);

			var result = await moq.Object.GetAsync();

			result.Should().BeOfType<List<City>>();
		}

		[Fact]
		public async Task GetAll_EqualDataTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			moq.Setup(services => services.GetAsync()).ReturnsAsync(mockCities);
			var result = await moq.Object.GetAsync();

			result.Should().Equal(mockCities);
		}
		
		[Fact]
		public async Task GetById_NotBeNullTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.GetAsync(city!.Id))!.ReturnsAsync(city);
			var result = await moq.Object.GetAsync(city!.Id);

			result.Should().NotBeNull();
		}
		
		[Fact]
		public async Task GetById_OfTypeTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.GetAsync(city!.Id))!.ReturnsAsync(city);
			var result = await moq.Object.GetAsync(city!.Id);

			result.Should().BeOfType<City>();
		}
		
		[Fact]
		public async Task GetById_EqualDataTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.GetAsync(city!.Id))!.ReturnsAsync(city);
			var result = await moq.Object.GetAsync(city!.Id);

			result.Should().Be(city);
		}

		[Fact]
		public async Task GetWithFilter_EqualDataTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var cities = mockCities.Where(item => item.Name.StartsWith("Á")).ToList();
			moq.Setup(services => services.GetAsync(item => item.Name.StartsWith("Á"))).ReturnsAsync(cities);
			var result = await moq.Object.GetAsync(item => item.Name.StartsWith("Á"));

			result.Should().Equal(cities);
		}

		[Fact]
		public async Task GetWithFilter_OfTypeTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var cities = mockCities.Where(item => item.Name.StartsWith("Á")).ToList();
			moq.Setup(services => services.GetAsync(item => item.Name.StartsWith("Á"))).ReturnsAsync(cities);
			var result = await moq.Object.GetAsync(item => item.Name.StartsWith("Á"));

			result.Should().BeOfType<List<City>>();
		}		

		[Fact]
		public async Task GetWithFilter_NotBeNullTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			moq.Setup(services => services.GetAsync(item => item.Name.StartsWith("Á")))!.ReturnsAsync(mockCities);
			var result = await moq.Object.GetAsync(item => item.Name.StartsWith("Á"));

			result.Should().NotBeNull();
		}

		[Fact]
		public async Task Exists_PositiveTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.ExistsAsync(city!.Id)).ReturnsAsync(true);
			var result = await moq.Object.ExistsAsync(city!.Id);

			result.Should().BeTrue();
		}

		[Fact]
		public async Task Exists_NegativeTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();
			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.ExistsAsync(city!.Id))!.ReturnsAsync(false);
			var result = await moq.Object.ExistsAsync(city!.Id);

			result.Should().BeFalse();
		}
		
		[Fact]
		public async Task Delete_PositiveTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();

			var city = mockCities.FirstOrDefault();
			moq.Setup(services => services.DeleteHardAsync(city!.Id)).ReturnsAsync(true);
			var result = await moq.Object.DeleteHardAsync(city!.Id);
			var findObj = await moq.Object.GetAsync(city!.Id);

			result.Should().BeTrue();
			findObj.Should().BeNull();
		}

		[Fact]
		public async Task Delete_NegativeTest()
		{
			var mockCities = TestData.Cities;
			var moq = new Mock<BaseDal<AppDbContext, City, Guid>>();

			var id = It.IsAny<Guid>();
			moq.Setup(services => services.DeleteHardAsync(id)).ReturnsAsync(false);
			var result = await moq.Object.DeleteHardAsync(id);
			var city = mockCities.Find(item => item.Id == id);

			result.Should().BeFalse();
			city.Should().BeNull();
		}
	}
}