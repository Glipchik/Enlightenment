using AutoMapper;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;
        private readonly IMapper _mapper;

        public ModuleController(IModuleService moduleService, IMapper mapper)
        {
            this._moduleService = moduleService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a Module with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">Module unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Module found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ModuleViewModel?> GetModule(int id, CancellationToken ct = default)
        {
            var module = _mapper.Map<ModuleViewModel>(await _moduleService.GetById(id, ct));
            return module;
        }

        /// <summary>
        /// Gets all Modules from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found modules.</returns>
        [HttpGet]
        public async Task<List<ModuleViewModel>> GetModules(CancellationToken ct = default)
        {
            var modules = await _moduleService.GetItems(ct);
            return _mapper.Map<List<ModuleViewModel>>(modules);
        }

        /// <summary>
        /// Adds module to database.
        /// </summary>
        /// <param name="module"><see cref="ModuleViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added Module.</returns>
        [HttpPost]
        public async Task<ModuleViewModel> Post(ModuleViewModel module, CancellationToken ct = default)
        {
            var result = await _moduleService.Add(_mapper.Map<Module>(module), ct);
            return _mapper.Map<ModuleViewModel>(result);
        }

        /// <summary>
        /// Updates a Module in database with specified id.
        /// </summary>
        /// <param name="id">Module unique identifier</param>
        /// <param name="module">Module to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated Module</returns>
        [HttpPut("{id}")]
        public async Task<ModuleViewModel> Put(int id, ModuleViewModel module, CancellationToken ct = default)
        {
            module.Id = id;
            var result = await _moduleService.Update(_mapper.Map<Module>(module), ct);
            return _mapper.Map<ModuleViewModel>(result);
        }

        /// <summary>
        /// Deletes a Module in database with specified id.
        /// </summary>
        /// <param name="id">Module unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Module deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<ModuleViewModel?> Delete(int id, CancellationToken ct = default)
        {
            var result = await _moduleService.Delete(id, ct);
            return _mapper.Map<ModuleViewModel>(result);
        }
    }
}
