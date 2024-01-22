using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class SectionControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<ISectionService> _serviceMock = new();
        private readonly SectionController _controller;

        public SectionControllerTests()
        {
            _controller = new SectionController(_serviceMock.Object, _mapperMock.Object);
        }

        [Theory, AutoControllerData]
        public async Task Post_ValidModel_ReturnsValidModel(SectionViewModel sectionModel, Section section)
        {
            _mapperMock.Setup(x => x.Map<Section>(sectionModel)).Returns(section);
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Add(section, default)).ReturnsAsync(section);

            var result = await _controller.Post(sectionModel, default);

            result.ShouldBe(sectionModel);
        }

        [Theory, AutoControllerData]
        public async Task Put_ValidModel_ReturnsValidModel(SectionViewModel sectionModel, Section section)
        {
            _mapperMock.Setup(x => x.Map<Section>(sectionModel)).Returns(section);
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Update(section, default)).ReturnsAsync(section);

            var result = await _controller.Put(1, sectionModel, default);

            result.ShouldBe(sectionModel);
        }

        [Theory, AutoControllerData]
        public async Task Delete_ValidModel_ReturnsValidModel(SectionViewModel sectionModel, Section section)
        {
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(section);

            var result = await _controller.Delete(1, default);

            result.ShouldBe(sectionModel);
        }

        [Theory, AutoControllerData]
        public async Task GetSection_ValidModel_ReturnsValidModel(SectionViewModel sectionModel, Section section)
        {
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(section);

            var result = await _controller.GetSection(1, default);

            result.ShouldBe(sectionModel);
        }

        [Theory, AutoControllerData]
        public async Task GetSections_ReturnsValidModel(List<SectionViewModel> sectionModels, List<Section> sections)
        {
            _mapperMock.Setup(x => x.Map<List<Section>>(sectionModels)).Returns(sections);
            _mapperMock.Setup(x => x.Map<List<SectionViewModel>>(sections)).Returns(sectionModels);
            _serviceMock.Setup(x => x.GetItems(default)).ReturnsAsync(sections);

            var result = await _controller.GetSections(default);

            result.ShouldBe(sectionModels);
        }
    }
}
