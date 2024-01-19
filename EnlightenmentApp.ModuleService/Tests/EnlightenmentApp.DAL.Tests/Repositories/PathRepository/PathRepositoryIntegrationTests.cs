using AutoFixture;
using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Tests.Repositories.PathRepository
{
    public class PathRepositoryIntegrationTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DAL.Repositories.PathRepository? _repository;
        private readonly Fixture _fixture;


        public PathRepositoryIntegrationTests()
        {
            this._options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EnlightenmentApp" + DateTime.Now.ToFileTimeUtc())
                .Options;

            _fixture = new Fixture();

            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetEntities_DatabasePopulated_ReturnsExpectedCollection()
        {
            await using DatabaseContext context = new(_options);
            this._repository = new(context);
            
            var path = _fixture.Create<PathEntity>();


            await context.Paths.AddAsync(path);
            await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            var result = (await _repository.GetEntities(default)).ToList();

            result.ShouldNotBeNull();
            result.ForEach(x => x.Tags.ShouldNotBeNull());
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsExpectedEntity()
        {
            var path = _fixture.Create<PathEntity>();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            PathEntity? result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.Modules.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task Add_ValidEntity_ReturnsAddedEntity()
        {
            var path = _fixture.Create<PathEntity>();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            PathEntity result = await _repository.Add(path, default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Update_ValidEntity_ReturnsUpdatedEntity()
        {
            var path = _fixture.Create<PathEntity>();
            var modules = path.Modules.ToList();
            var tags = path.Tags.ToList();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            path.Modules.Remove(modules[0]);
            path.Modules.Add(new() { Summary = "strings" });
            path.Tags.Remove(tags[0]);
            path.Tags.Add(new() { Value = "strings" });

            PathEntity result = await _repository.Update(path, default);

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
            result.Modules.FirstOrDefault(x => x.Summary == "strings").ShouldNotBeNull();
            result.Tags.FirstOrDefault(x => x.Value == "strings").ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_ValidId_EntityDeleted()
        {
            var path = _fixture.Create<PathEntity>();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            PathEntity? result = await _repository.Delete(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
        }

        [Fact]
        public async Task EntityExists_ValidId_ReturnsTrue()
        {
            var path = _fixture.Create<PathEntity>();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity.Id, default);

            result.ShouldBeTrue();
        }

        [Fact]
        public async Task EntityExists_ValidEntity_ReturnsTrue()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity, default);

            result.ShouldBeTrue();
        }

        [Fact]
        public async Task GetEntities_EmptyDatabase_ReturnsEntityCollection()
        {
            await using DatabaseContext context = new(_options);
            this._repository = new(context);

            IEnumerable<PathEntity> result = await _repository.GetEntities(default);

            result.ShouldBeEmpty();
        }

        [Fact]
        public async Task GetById_InValidId_ReturnsNull()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            PathEntity? result = await _repository.GetById(entity.Entity.Id + 1, default);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Add_Null_Throws()
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            await _repository.Add(null!, default)
                .ShouldThrowAsync<Exception>();
        }

        [Fact]
        public async Task Update_InValidEntity_Throws()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();
            path.Id = entity.Entity.Id + 1;

            await _repository.Update(path, default)
                .ShouldThrowAsync<Exception>();
        }

        [Fact]
        public async Task Delete_InValidId_Throws()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            await _repository.Delete(entity.Entity.Id + 1, default)
                .ShouldThrowAsync<Exception>();
        }

        [Fact]
        public async Task EntityExists_InValidId_ReturnsFalse()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity.Id + 1, default);

            result.ShouldBeFalse();
        }

        [Fact]
        public async Task EntityExists_InValidEntity_ReturnsFalse()
        {
            var path = _fixture.Create<PathEntity>();
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();
            path.Id = entity.Entity.Id + 1;

            bool result = await _repository.EntityExists(entity.Entity, default);

            result.ShouldBeFalse();
        }
    }
}
