using AutoMapper;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.API.Models.Module;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/Modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private IModuleService _moduleService;
        private IMapper _mapper;
        public ModuleController(IModuleService moduleService, IMapper mapper)
        {
            this._moduleService = moduleService;
            this._mapper = mapper;
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<ModuleViewModel?> GetModule(int id, CancellationToken ct)
        {
            var module = _mapper.Map<ModuleViewModel>(await _moduleService.GetById(id, ct));
            return module;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<ModuleViewModel>> GetModules(CancellationToken ct)
        {
            var modules = await _moduleService.GetItems(ct);
            return _mapper.Map<List<ModuleViewModel>>(modules);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<ModuleViewModel> Post(ModuleViewModel module, CancellationToken ct)
        {
            var result = await _moduleService.Add(_mapper.Map<Module>(module), ct);
            return _mapper.Map<ModuleViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<ModuleViewModel> Put(int id, ModuleViewModel module, CancellationToken ct)
        {
            module.Id = id;
            var result = await _moduleService.Update(_mapper.Map<Module>(module), ct);
            return _mapper.Map<ModuleViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<ModuleViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _moduleService.Delete(id, ct);
            return _mapper.Map<ModuleViewModel>(result);
        }
    }
}
