using EnlightenmentApp.DAL.DataContext;
using EnlightenmentApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.DAL.Tests.Repositories.ModuleRepository
{
    public class ModuleRepositoryIntegrationTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        private DAL.Repositories.ModuleRepository? _repository;

        public ModuleRepositoryIntegrationTests()
        {
            this._options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "EnlightenmentApp" + DateTime.Now.ToFileTimeUtc())
                .Options;
        }

        [Theory, AutoRepositoryData]
        public async Task GetEntities_DatabasePopulated_ReturnsExpectedCollection(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            this._repository = new(context);

            await context.Modules.AddAsync(module);
            await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            var result = (await _repository.GetEntities(default)).ToList();

            result.ShouldNotBeNull();
            result.ForEach(x => x.Tags.ShouldNotBeNull());
        }

        [Theory, AutoRepositoryData]
        public async Task GetById_ValidId_ReturnsExpectedEntity(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            ModuleEntity? result = await _repository.GetById(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.Sections.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
        }

        [Theory, AutoRepositoryData]
        public async Task Add_ValidEntity_ReturnsAddedEntity(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            ModuleEntity result = await _repository.Add(module, default);

            result.ShouldNotBeNull();
        }

        [Theory, AutoRepositoryData]
        public async Task Update_ValidEntity_ReturnsUpdatedEntity(ModuleEntity module)
        {
            var sections = module.Sections.ToList();
            var tags = module.Tags.ToList();

            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            module.Sections.Remove(sections[0]);
            module.Sections.Add(new (){ Content = "strings" });
            module.Tags.Remove(tags[0]);
            module.Tags.Add(new() { Value = "strings" });

            ModuleEntity result = await _repository.Update(module, default);

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
            result.Sections.FirstOrDefault(x => x.Content == "strings").ShouldNotBeNull();
            result.Tags.FirstOrDefault(x => x.Value == "strings").ShouldNotBeNull();
        }

        [Theory, AutoRepositoryData]
        public async Task Delete_ValidId_EntityDeleted(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            ModuleEntity? result = await _repository.Delete(entity.Entity.Id, default);

            result.ShouldNotBeNull();
            result.ShouldBeEquivalentTo(entity.Entity);
        }

        [Theory, AutoRepositoryData]
        public async Task EntityExists_ValidId_ReturnsTrue(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity.Id, default);

            result.ShouldBeTrue();
        }

        [Theory, AutoRepositoryData]
        public async Task EntityExists_ValidEntity_ReturnsTrue(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity, default);

            result.ShouldBeTrue();
        }

        [Fact]
        public async Task GetEntities_EmptyDatabase_ReturnsEntityCollection()
        {
            await using DatabaseContext context = new(_options);
            this._repository = new(context);

            IEnumerable<ModuleEntity> result = await _repository.GetEntities(default);

            result.ShouldBeEmpty();
        }

        [Theory, AutoRepositoryData]
        public async Task GetById_InValidId_ReturnsNull(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            ModuleEntity? result = await _repository.GetById(entity.Entity.Id + 1, default);

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

        [Theory, AutoRepositoryData]
        public async Task Update_InValidEntity_Throws(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();
            module.Id = entity.Entity.Id + 1;

            await _repository.Update(module, default)
                .ShouldThrowAsync<Exception>();
        }

        [Theory, AutoRepositoryData]
        public async Task Delete_InValidId_Throws(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            await _repository.Delete(entity.Entity.Id + 1, default)
                .ShouldThrowAsync<Exception>();
        }

        [Theory, AutoRepositoryData]
        public async Task EntityExists_InValidId_ReturnsFalse(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();

            bool result = await _repository.EntityExists(entity.Entity.Id + 1, default);

            result.ShouldBeFalse();
        }

        [Theory, AutoRepositoryData]
        public async Task EntityExists_InValidEntity_ReturnsFalse(ModuleEntity module)
        {
            await using DatabaseContext context = new(_options);
            _repository = new(context);

            var entity = await context.Modules.AddAsync(module);
            await context.SaveChangesAsync();
            module.Id = entity.Entity.Id + 1;

            bool result = await _repository.EntityExists(entity.Entity, default);

            result.ShouldBeFalse();
        }
    }
}
