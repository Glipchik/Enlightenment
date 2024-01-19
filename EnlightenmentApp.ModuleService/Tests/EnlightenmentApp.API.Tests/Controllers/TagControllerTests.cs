using AutoFixture;
using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.API.Models.Tag;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class TagControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<ITagService> _serviceMock = new();
        private readonly Fixture _fixture = new();

        public TagControllerTests()
        {
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task Post_ValidModel_ReturnsValidModel()
        {
            var tagModel = _fixture.Create<TagViewModel>();
            var tag = _fixture.Create<Tag>();
            _mapperMock.Setup(x => x.Map<Tag>(tagModel)).Returns(tag);
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Add(tag, default)).ReturnsAsync(tag);
            var controller = new TagController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Post(tagModel, default);

            result.ShouldBe(tagModel);
        }

        [Fact]
        public async Task Put_ValidModel_ReturnsValidModel()
        {
            var tagModel = _fixture.Create<TagViewModel>();
            var tag = _fixture.Create<Tag>();
            _mapperMock.Setup(x => x.Map<Tag>(tagModel)).Returns(tag);
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Update(tag, default)).ReturnsAsync(tag);
            var controller = new TagController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Put(1, tagModel, default);

            result.ShouldBe(tagModel);
        }

        [Fact]
        public async Task Delete_ValidModel_ReturnsValidModel()
        {
            var tagModel = _fixture.Create<TagViewModel>();
            var tag = _fixture.Create<Tag>();
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(tag);
            var controller = new TagController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Delete(1, default);

            result.ShouldBe(tagModel);
        }
        [Fact]
        public async Task GetTag_ValidModel_ReturnsValidModel()
        {
            var tagModel = _fixture.Create<TagViewModel>();
            var tag = _fixture.Create<Tag>();
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(tag);
            var controller = new TagController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetTag(1, default);

            result.ShouldBe(tagModel);
        }
        [Fact]
        public async Task GetTags_ReturnsValidModel()
        {
            var tagModels = _fixture.Create<List<TagViewModel>>();
            var tags = _fixture.Create<List<Tag>>();
            _mapperMock.Setup(x => x.Map<List<Tag>>(tagModels)).Returns(tags);
            _mapperMock.Setup(x => x.Map<List<TagViewModel>>(tags)).Returns(tagModels);
            _serviceMock.Setup(x => x.GetItems( default)).ReturnsAsync(tags);
            var controller = new TagController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetTags( default);

            result.ShouldBe(tagModels);
        }
    }
}
