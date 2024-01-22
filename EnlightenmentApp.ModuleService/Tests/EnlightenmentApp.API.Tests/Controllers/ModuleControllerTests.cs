using AutoMapper;
using EnlightenmentApp.API.Controllers;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Moq;

namespace EnlightenmentApp.API.Tests.Controllers
{
    public class ModuleControllerTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IModuleService> _serviceMock = new();
        private readonly ModuleController _controller;

        public ModuleControllerTests()
        {
            _controller = new ModuleController(_serviceMock.Object, _mapperMock.Object);
        }

        [Theory, AutoControllerData]
        public async Task Post_ValidModel_ReturnsValidModel(ModuleViewModel moduleModel, Module module)
        {
            _mapperMock.Setup(x => x.Map<Module>(moduleModel)).Returns(module);
            _mapperMock.Setup(x => x.Map<ModuleViewModel>(module)).Returns(moduleModel);
            _serviceMock.Setup(x => x.Add(module, default)).ReturnsAsync(module);

            var result = await _controller.Post(moduleModel, default);

            result.ShouldBe(moduleModel);
        }

        [Theory, AutoControllerData]

        public async Task Put_ValidModel_ReturnsValidModel(ModuleViewModel moduleModel, Module module)
        {
            _mapperMock.Setup(x => x.Map<Module>(moduleModel)).Returns(module);
            _mapperMock.Setup(x => x.Map<ModuleViewModel>(module)).Returns(moduleModel);
            _serviceMock.Setup(x => x.Update(module, default)).ReturnsAsync(module);

            var result = await _controller.Put(1, moduleModel, default);

            result.ShouldBe(moduleModel);
        }

        [Theory, AutoControllerData]
        public async Task Delete_ValidModel_ReturnsValidModel(ModuleViewModel moduleModel, Module module)
        {
            _mapperMock.Setup(x => x.Map<ModuleViewModel>(module)).Returns(moduleModel);
            _serviceMock.Setup(x => x.Delete(1, default)).ReturnsAsync(module);

            var result = await _controller.Delete(1, default);

            result.ShouldBe(moduleModel);
        }

        [Theory, AutoControllerData]
        public async Task GetModule_ValidModel_ReturnsValidModel(ModuleViewModel moduleModel, Module module)
        {
            _mapperMock.Setup(x => x.Map<ModuleViewModel>(module)).Returns(moduleModel);
            _serviceMock.Setup(x => x.GetById(1, default)).ReturnsAsync(module);

            var result = await _controller.GetModule(1, default);

            result.ShouldBe(moduleModel);
        }

        [Theory, AutoControllerData]
        public async Task GetModules_ReturnsValidModel(List<ModuleViewModel> moduleModels, List<Module> modules)
        {
            _mapperMock.Setup(x => x.Map<List<Module>>(moduleModels)).Returns(modules);
            _mapperMock.Setup(x => x.Map<List<ModuleViewModel>>(modules)).Returns(moduleModels);
            _serviceMock.Setup(x => x.GetItems(default)).ReturnsAsync(modules);

            var result = await _controller.GetModules(default);

            result.ShouldBe(moduleModels);
        }
    }
}
