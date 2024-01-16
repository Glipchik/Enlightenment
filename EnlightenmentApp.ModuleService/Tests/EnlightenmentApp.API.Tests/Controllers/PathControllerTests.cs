using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Path;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class PathControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IPathService> _serviceMock = new();

        [Fact]
        public async Task Post_ValidModel_ReturnsValidModel()
        {
            var pathModel = new PathViewModel()
            {
                Summary = "ssString"
            };
            var path = new Path()
            {
                Summary = "ssString"
            };

            _mapperMock.Setup(x => x.Map<Path>(pathModel)).Returns(path);
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Add(path, default)).ReturnsAsync(path);
            var controller = new PathController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Post(pathModel, default);

            result.ShouldBe(pathModel);
        }

        [Fact]
        public async Task Put_ValidModel_ReturnsValidModel()
        {
            var pathModel = new PathViewModel()
            {
                Summary = "ssString"
            };
            var path = new Path()
            {
                Summary = "ssString"
            };

            _mapperMock.Setup(x => x.Map<Path>(pathModel)).Returns(path);
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Update(path, default)).ReturnsAsync(path);
            var controller = new PathController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Put(1, pathModel, default);

            result.ShouldBe(pathModel);
        }

        [Fact]
        public async Task Delete_ValidModel_ReturnsValidModel()
        {
            var pathModel = new PathViewModel()
            {
                Summary = "ssString"
            };
            var path = new Path()
            {
                Summary = "ssString"
            };

            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(path);
            var controller = new PathController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Delete(1, default);

            result.ShouldBe(pathModel);
        }
        [Fact]
        public async Task GetPath_ValidModel_ReturnsValidModel()
        {
            var pathModel = new PathViewModel()
            {
                Summary = "ssString"
            };
            var path = new Path()
            {
                Summary = "ssString"
            };

            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(path);
            var controller = new PathController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetPath(1, default);

            result.ShouldBe(pathModel);
        }
        [Fact]
        public async Task GetPaths_ReturnsValidModel()
        {
            var paths = new List<Path>()
            {
                new(), new()
            };
            var pathModels = new List<PathViewModel>()
            {
                new(), new()
            };

            _mapperMock.Setup(x => x.Map<List<Path>>(pathModels)).Returns(paths);
            _mapperMock.Setup(x => x.Map<List<PathViewModel>>(paths)).Returns(pathModels);
            _serviceMock.Setup(x => x.GetItems( default)).ReturnsAsync(paths);
            var controller = new PathController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetPaths( default);

            result.ShouldBe(pathModels);
        }
    }
}
