using AutoMapper;
using EnlightenmentApp.API.Controllers;
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
        private readonly TagController _controller;

        public TagControllerTests()
        {
            _controller = new TagController(_serviceMock.Object, _mapperMock.Object);
        }

        [Theory, AutoControllerData]
        public async Task Post_ValidModel_ReturnsValidModel(TagViewModel tagModel, Tag tag)
        {
            _mapperMock.Setup(x => x.Map<Tag>(tagModel)).Returns(tag);
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Add(tag, default)).ReturnsAsync(tag);

            var result = await _controller.Post(tagModel, default);

            result.ShouldBe(tagModel);
        }

        [Theory, AutoControllerData]
        public async Task Put_ValidModel_ReturnsValidModel(TagViewModel tagModel, Tag tag)
        {
            _mapperMock.Setup(x => x.Map<Tag>(tagModel)).Returns(tag);
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Update(tag, default)).ReturnsAsync(tag);

            var result = await _controller.Put(1, tagModel, default);

            result.ShouldBe(tagModel);
        }

        [Theory, AutoControllerData]
        public async Task Delete_ValidModel_ReturnsValidModel(TagViewModel tagModel, Tag tag)
        {
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(tag);

            var result = await _controller.Delete(1, default);

            result.ShouldBe(tagModel);
        }

        [Theory, AutoControllerData]
        public async Task GetTag_ValidModel_ReturnsValidModel(TagViewModel tagModel, Tag tag)
        {
            _mapperMock.Setup(x => x.Map<TagViewModel>(tag)).Returns(tagModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(tag);

            var result = await _controller.GetTag(1, default);

            result.ShouldBe(tagModel);
        }

        [Theory, AutoControllerData]
        public async Task GetTags_ReturnsValidModel(List<TagViewModel> tagModels, List<Tag> tags)
        {
            _mapperMock.Setup(x => x.Map<List<Tag>>(tagModels)).Returns(tags);
            _mapperMock.Setup(x => x.Map<List<TagViewModel>>(tags)).Returns(tagModels);
            _serviceMock.Setup(x => x.GetItems( default)).ReturnsAsync(tags);

            var result = await _controller.GetTags( default);

            result.ShouldBe(tagModels);
        }
    }
}
