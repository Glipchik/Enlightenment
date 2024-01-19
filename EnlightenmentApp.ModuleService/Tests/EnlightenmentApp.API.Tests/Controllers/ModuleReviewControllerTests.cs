using AutoFixture;
using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.API.Models.ModuleReview;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class ModuleReviewControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IModuleReviewService> _serviceMock = new();
        private readonly Fixture _fixture = new();

        public ModuleReviewControllerTests()
        {
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Post_ValidModel_ReturnsValidModel()
        {
            var moduleReviewModel = _fixture.Create<ModuleReviewViewModel>();
            var moduleReview = _fixture.Create<ModuleReview>();
            _mapperMock.Setup(x => x.Map<ModuleReview>(moduleReviewModel)).Returns(moduleReview);
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Add(moduleReview, default)).ReturnsAsync(moduleReview);
            var controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Post(moduleReviewModel, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Fact]
        public async Task Put_ValidModel_ReturnsValidModel()
        {
            var moduleReviewModel = _fixture.Create<ModuleReviewViewModel>();
            var moduleReview = _fixture.Create<ModuleReview>();
            _mapperMock.Setup(x => x.Map<ModuleReview>(moduleReviewModel)).Returns(moduleReview);
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Update(moduleReview, default)).ReturnsAsync(moduleReview);
            var controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Put(1, moduleReviewModel, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Fact]
        public async Task Delete_ValidModel_ReturnsValidModel()
        {
            var moduleReviewModel = _fixture.Create<ModuleReviewViewModel>();
            var moduleReview = _fixture.Create<ModuleReview>();
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(moduleReview);
            var controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Delete(1, default);

            result.ShouldBe(moduleReviewModel);
        }
        [Fact]
        public async Task GetModuleReview_ValidModel_ReturnsValidModel()
        {
            var moduleReviewModel = _fixture.Create<ModuleReviewViewModel>();
            var moduleReview = _fixture.Create<ModuleReview>();
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(moduleReview);
            var controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetModuleReview(1, default);

            result.ShouldBe(moduleReviewModel);
        }
        [Fact]
        public async Task GetModuleReviews_ReturnsValidModel()
        {
            var moduleReviewModels = _fixture.Create<List<ModuleReviewViewModel>>();
            var moduleReviews = _fixture.Create< List<ModuleReview>>();
            _mapperMock.Setup(x => x.Map<List<ModuleReview>>(moduleReviewModels)).Returns(moduleReviews);
            _mapperMock.Setup(x => x.Map<List<ModuleReviewViewModel>>(moduleReviews)).Returns(moduleReviewModels);
            _serviceMock.Setup(x => x.GetItems( default)).ReturnsAsync(moduleReviews);
            var controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetModuleReviews( default);

            result.ShouldBe(moduleReviewModels);
        }
    }
}
