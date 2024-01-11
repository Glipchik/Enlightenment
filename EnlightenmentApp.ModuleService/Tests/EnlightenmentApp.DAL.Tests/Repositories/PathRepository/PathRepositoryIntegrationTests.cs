using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Tests.Repositories.PathRepository
{
    public class PathRepositoryIntegrationTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DAL.Repositories.PathRepository _repository;

        public PathRepositoryIntegrationTests()
        {
            this._options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EnlightenmentApp" + DateTime.Now.ToFileTimeUtc())
                .Options;
        }

        [Fact]
        public async Task GetEntities_DatabasePopulated_ReturnsExpectedCollection()
        {
            await using DatabaseContext context = new(_options);
            this._repository = new(context);
            var tags = new List<TagEntity>()
            {
                new(), new()
            };
            var path = new PathEntity
            {
                Title = "Anonymous",
                Tags = tags
            };

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
            var sections = new List<ModuleEntity>()
            {
                new(), new()
            };
            var path = new PathEntity
            {
                Title = "Anonymous",
                Modules = sections
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            PathEntity result = await _repository.Add(path, default);

            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task Update_ValidEntity_ReturnsUpdatedEntity()
        {
            var tags = new List<TagEntity>()
            {
                new(), new()
            };
            var sections = new List<ModuleEntity>()
            {
                new(), new()
            };
            var path = new PathEntity
            {
                Title = "Anonymous",
                Modules = sections,
                Tags = tags
            };
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Paths.AddAsync(path);
            await context.SaveChangesAsync();

            path.Modules.Remove(sections[0]);
            path.Modules.Add(new() { Summary = "strings" });
            path.Tags.Remove(tags[0]);
            path.Tags.Add(new() { Value = "strings" });

            PathEntity result = await _repository.Update(path, default);

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
            result.Modules.Count.ShouldBe(2);
            result.Modules.FirstOrDefault(x => x.Summary == "strings").ShouldNotBeNull();
            result.Tags.FirstOrDefault(x => x.Value == "strings").ShouldNotBeNull();
        }

        [Fact]
        public async Task Delete_ValidId_EntityDeleted()
        {
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
            var path = new PathEntity
            {
                Title = "Anonymous"
            };
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
