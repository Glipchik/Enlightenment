using AutoMapper;
using EnlightenmentApp.API.Models.Path;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/Paths")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private IPathService _pathService;
        private IMapper _mapper;
        public PathController(IPathService pathService, IMapper mapper)
        {
            this._pathService = pathService;
            this._mapper = mapper;
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<PathViewModel?> GetPath(int id, CancellationToken ct)
        {
            var path = _mapper.Map<PathViewModel>(await _pathService.GetById(id, ct));
            return path;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<PathViewModel>> GetPaths(CancellationToken ct)
        {
            var paths = await _pathService.GetItems(ct);
            return _mapper.Map<List<PathViewModel>>(paths);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<PathViewModel> Post(PathViewModel path, CancellationToken ct)
        {
            var result = await _pathService.Add(_mapper.Map<Path>(path), ct);
            return _mapper.Map<PathViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<PathViewModel> Put(int id, PathViewModel path, CancellationToken ct)
        {
            path.Id = id;
            var result = await _pathService.Update(_mapper.Map<Path>(path), ct);
            return _mapper.Map<PathViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<PathViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _pathService.Delete(id, ct);
            return _mapper.Map<PathViewModel>(result);
        }
    }
}
