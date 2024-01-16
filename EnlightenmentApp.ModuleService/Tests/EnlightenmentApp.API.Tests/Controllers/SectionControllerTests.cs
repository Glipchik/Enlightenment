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

        [Fact]
        public async Task Post_ValidModel_ReturnsValidModel()
        {
            var sectionModel = new SectionViewModel()
            {
                Content = "ssString",
                ModuleId = 1
            };
            var section = new Section()
            {
                Content = "ssString",
                ModuleId = 1
            };

            _mapperMock.Setup(x => x.Map<Section>(sectionModel)).Returns(section);
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Add(section, default)).ReturnsAsync(section);
            var controller = new SectionController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Post(sectionModel, default);

            result.ShouldBe(sectionModel);
        }

        [Fact]
        public async Task Put_ValidModel_ReturnsValidModel()
        {
            var sectionModel = new SectionViewModel()
            {
                Content = "ssString",
                ModuleId = 1
            };
            var section = new Section()
            {
                Content = "ssString",
                ModuleId = 1
            };

            _mapperMock.Setup(x => x.Map<Section>(sectionModel)).Returns(section);
            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Update(section, default)).ReturnsAsync(section);
            var controller = new SectionController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Put(1, sectionModel, default);

            result.ShouldBe(sectionModel);
        }

        [Fact]
        public async Task Delete_ValidModel_ReturnsValidModel()
        {
            var sectionModel = new SectionViewModel()
            {
                Content = "ssString",
                ModuleId = 1
            };
            var section = new Section()
            {
                Content = "ssString",
                ModuleId = 1
            };

            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(section);
            var controller = new SectionController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.Delete(1, default);

            result.ShouldBe(sectionModel);
        }
        [Fact]
        public async Task GetSection_ValidModel_ReturnsValidModel()
        {
            var sectionModel = new SectionViewModel()
            {
                Content = "ssString",
                ModuleId = 1
            };
            var section = new Section()
            {
                Content = "ssString",
                ModuleId = 1
            };

            _mapperMock.Setup(x => x.Map<SectionViewModel>(section)).Returns(sectionModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(section);
            var controller = new SectionController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetSection(1, default);

            result.ShouldBe(sectionModel);
        }
        [Fact]
        public async Task GetSections_ReturnsValidModel()
        {
            var sections = new List<Section>()
            {
                new(), new()
            };
            var sectionModels = new List<SectionViewModel>()
            {
                new(), new()
            };

            _mapperMock.Setup(x => x.Map<List<Section>>(sectionModels)).Returns(sections);
            _mapperMock.Setup(x => x.Map<List<SectionViewModel>>(sections)).Returns(sectionModels);
            _serviceMock.Setup(x => x.GetItems( default)).ReturnsAsync(sections);
            var controller = new SectionController(_serviceMock.Object, _mapperMock.Object);

            var result = await controller.GetSections( default);

            result.ShouldBe(sectionModels);
        }
    }
}
