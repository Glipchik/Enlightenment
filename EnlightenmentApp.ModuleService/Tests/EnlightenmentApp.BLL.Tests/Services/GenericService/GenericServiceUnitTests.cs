﻿using AutoFixture;
using AutoMapper;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.BLL.Services;
using EnlightenmentApp.DAL.Entities;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.AutoMock;

namespace EnlightenmentApp.BLL.Tests.Services.GenericService
{
    public class GenericServiceUnitTests
    {
        private readonly Mock<IGenericRepository<SectionEntity>> _repoMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly GenericService<Section, SectionEntity> _service;
        private readonly Fixture _fixture;

        public GenericServiceUnitTests()
        {
            _service = new GenericService<Section, SectionEntity>(_repoMock.Object, _mapperMock.Object);

            _fixture = new Fixture();

            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetItems_HasData_ReturnsValidModel()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = _fixture.Create<ICollection<Section>>();

            mocker.Setup<IGenericService<Section>, Task<IEnumerable<Section>>>(x => x.GetItems(default))
                .ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Section>>();

            var actual = await service.GetItems(default);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetById_HasData_ReturnsValidModel()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = _fixture.Create<Section>();

            mocker.Setup<IGenericService<Section>, Task<Section?>>(x => x.GetById(expected.Id, default))
                .ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Section>>();

            var actual = await service.GetById(expected.Id, default);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsValidModel()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = _fixture.Create<Section>();

            mocker.Setup<IGenericService<Section>, Task<Section>>(x => x.Add(expected, default))
                .ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Section>>();

            var actual = await service.Add(expected, default);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task Delete_HasData_ReturnsValidModel()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = _fixture.Create<Section>();

            mocker.Setup<IGenericService<Section>, Task<Section?>>(x => x.Delete(expected.Id, default))
                .ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Section>>();

            var actual = await service.Delete(expected.Id, default);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task Update_HasData_ReturnsValidModel()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var expected = _fixture.Create<Section>();

            mocker.Setup<IGenericService<Section>, Task<Section>>(x => x.Update(expected, default))
                .ReturnsAsync(expected);

            var service = mocker.Get<IGenericService<Section>>();

            var actual = await service.Update(expected, default);

            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public async Task GetById_NonExistentId_ReturnsNull()
        {
            var id = 0;
            _mapperMock.Setup(x => x.Map<Section>(null)).Returns((Section)null!);
            _repoMock.Setup(x => x.GetById(id, default)).ReturnsAsync((SectionEntity)null!);

            var actual = await _service.GetById(id, default);

            actual.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public async Task Add_Null_ThrowsArgumentNullException()
        {
            var actual = await _service.Add(null!, default)
                .ShouldThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Delete_NonExistentId_ReturnsNull()
        {
            var id = 0;
            _repoMock.Setup(x => x.EntityExists(id, default)).ReturnsAsync(false);

            var actual = await _service.Delete(id, default);

            actual.ShouldBeEquivalentTo(null);
        }

        [Fact]
        public async Task Update_NonExistentItem_ThrowsDbUpdateConcurrencyException()
        {
            var expected = _fixture.Create<Section>();
            var expectedEntity = _fixture.Create<SectionEntity>();
            _mapperMock.Setup(x => x.Map<SectionEntity>(expected)).Returns(expectedEntity);
            _repoMock.Setup(x => x.EntityExists(expectedEntity, default)).ReturnsAsync(false);

            var actual = await _service.Update(expected, default)
                .ShouldThrowAsync<DbUpdateConcurrencyException>();
        }
    }
}
