using AutoMapper;
using EnlightenmentApp.API.Controllers;
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
        private readonly ModuleReviewController _controller;

        public ModuleReviewControllerTests()
        {
            _controller = new ModuleReviewController(_serviceMock.Object, _mapperMock.Object);
        }

        [Theory, AutoControllerData]
        public async Task Post_ValidModel_ReturnsValidModel(ModuleReviewViewModel moduleReviewModel, ModuleReview moduleReview)
        {
            _mapperMock.Setup(x => x.Map<ModuleReview>(moduleReviewModel)).Returns(moduleReview);
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Add(moduleReview, default)).ReturnsAsync(moduleReview);

            var result = await _controller.Post(moduleReviewModel, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Theory, AutoControllerData]
        public async Task Put_ValidModel_ReturnsValidModel(ModuleReviewViewModel moduleReviewModel, ModuleReview moduleReview)
        {
            _mapperMock.Setup(x => x.Map<ModuleReview>(moduleReviewModel)).Returns(moduleReview);
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Update(moduleReview, default)).ReturnsAsync(moduleReview);

            var result = await _controller.Put(1, moduleReviewModel, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Theory, AutoControllerData]
        public async Task Delete_ValidModel_ReturnsValidModel(ModuleReviewViewModel moduleReviewModel, ModuleReview moduleReview)
        {
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(moduleReview);

            var result = await _controller.Delete(1, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Theory, AutoControllerData]
        public async Task GetModuleReview_ValidModel_ReturnsValidModel(ModuleReviewViewModel moduleReviewModel, ModuleReview moduleReview)
        {
            _mapperMock.Setup(x => x.Map<ModuleReviewViewModel>(moduleReview)).Returns(moduleReviewModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(moduleReview);

            var result = await _controller.GetModuleReview(1, default);

            result.ShouldBe(moduleReviewModel);
        }

        [Theory, AutoControllerData]
        public async Task GetModuleReviews_ReturnsValidModel(List<ModuleReviewViewModel> moduleReviewModels, List<ModuleReview> moduleReviews)
        {
            _mapperMock.Setup(x => x.Map<List<ModuleReview>>(moduleReviewModels)).Returns(moduleReviews);
            _mapperMock.Setup(x => x.Map<List<ModuleReviewViewModel>>(moduleReviews)).Returns(moduleReviewModels);
            _serviceMock.Setup(x => x.GetItems(default)).ReturnsAsync(moduleReviews);

            var result = await _controller.GetModuleReviews(default);

            result.ShouldBe(moduleReviewModels);
        }
    }
}
