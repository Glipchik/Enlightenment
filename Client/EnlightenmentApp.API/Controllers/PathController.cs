using AutoMapper;
using EnlightenmentApp.API.Models.Path;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Path = EnlightenmentApp.BLL.Entities.Path;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/paths")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly IPathService _pathService;
        private readonly IMapper _mapper;

        public PathController(IPathService pathService, IMapper mapper)
        {
            this._pathService = pathService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a Path with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">Path unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Path found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<PathViewModel?> GetPath(int id, CancellationToken ct)
        {
            var path = _mapper.Map<PathViewModel>(await _pathService.GetById(id, ct));
            return path;
        }

        /// <summary>
        /// Gets all Paths from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found paths.</returns>
        [HttpGet]
        public async Task<List<PathViewModel>> GetPaths(CancellationToken ct)
        {
            var paths = await _pathService.GetItems(ct);
            return _mapper.Map<List<PathViewModel>>(paths);
        }

        /// <summary>
        /// Adds path to database.
        /// </summary>
        /// <param name="path"><see cref="PathViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added Path.</returns>
        [HttpPost]
        public async Task<PathViewModel> Post(PathViewModel path, CancellationToken ct)
        {
            var result = await _pathService.Add(_mapper.Map<Path>(path), ct);
            return _mapper.Map<PathViewModel>(result);
        }

        /// <summary>
        /// Updates a Path in database with specified id.
        /// </summary>
        /// <param name="id">Path unique identifier</param>
        /// <param name="path">Path to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated Path</returns>
        [HttpPut("{id}")]
        public async Task<PathViewModel> Put(int id, PathViewModel path, CancellationToken ct)
        {
            path.Id = id;
            var result = await _pathService.Update(_mapper.Map<Path>(path), ct);
            return _mapper.Map<PathViewModel>(result);
        }

        /// <summary>
        /// Deletes a Path in database with specified id.
        /// </summary>
        /// <param name="id">Path unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Path deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<PathViewModel?> Delete(int id, CancellationToken ct)
        {
            var result = await _pathService.Delete(id, ct);
            return _mapper.Map<PathViewModel>(result);
        }
    }
}
