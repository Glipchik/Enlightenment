using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Path;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class PathControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IPathService> _serviceMock = new();
        private readonly PathController _controller;

        public PathControllerTests()
        {
            _controller = new PathController(_serviceMock.Object, _mapperMock.Object);
        }

        [Theory, AutoControllerData]
        public async Task Post_ValidModel_ReturnsValidModel(PathViewModel pathModel, Path path)
        {
            _mapperMock.Setup(x => x.Map<Path>(pathModel)).Returns(path);
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Add(path, default)).ReturnsAsync(path);

            var result = await _controller.Post(pathModel, default);

            result.ShouldBe(pathModel);
        }

        [Theory, AutoControllerData]
        public async Task Put_ValidModel_ReturnsValidModel(PathViewModel pathModel, Path path)
        {
            _mapperMock.Setup(x => x.Map<Path>(pathModel)).Returns(path);
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Update(path, default)).ReturnsAsync(path);

            var result = await _controller.Put(1, pathModel, default);

            result.ShouldBe(pathModel);
        }

        [Theory, AutoControllerData]
        public async Task Delete_ValidModel_ReturnsValidModel(PathViewModel pathModel, Path path)
        {
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(path);

            var result = await _controller.Delete(1, default);

            result.ShouldBe(pathModel);
        }

        [Theory, AutoControllerData]
        public async Task GetPath_ValidModel_ReturnsValidModel(PathViewModel pathModel, Path path)
        {
            _mapperMock.Setup(x => x.Map<PathViewModel>(path)).Returns(pathModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(path);

            var result = await _controller.GetPath(1, default);

            result.ShouldBe(pathModel);
        }

        [Theory, AutoControllerData]
        public async Task GetPaths_ReturnsValidModel(List<PathViewModel> pathModels, List<Path> paths)
        {
            _mapperMock.Setup(x => x.Map<List<Path>>(pathModels)).Returns(paths);
            _mapperMock.Setup(x => x.Map<List<PathViewModel>>(paths)).Returns(pathModels);
            _serviceMock.Setup(x => x.GetItems(default)).ReturnsAsync(paths);

            var result = await _controller.GetPaths(default);

            result.ShouldBe(pathModels);
        }
    }
}
