using AutoMapper;
using EnlightenmentApp.API.Models.ModuleReview;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/module-reviews")]
    [ApiController]
    public class ModuleReviewController : ControllerBase
    {
        private readonly IModuleReviewService _moduleReviewService;
        private readonly IMapper _mapper;

        public ModuleReviewController(IModuleReviewService moduleReviewService, IMapper mapper)
        {
            this._moduleReviewService = moduleReviewService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a ModuleReview with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">ModuleReview unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>ModuleReview found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ModuleReviewViewModel?> GetModuleReview(int id, CancellationToken ct)
        {
            var moduleReview = _mapper.Map<ModuleReviewViewModel>(await _moduleReviewService.GetById(id, ct));
            return moduleReview;
        }

        /// <summary>
        /// Gets all ModuleReviews from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found moduleReviews.</returns>
        [HttpGet]
        public async Task<List<ModuleReviewViewModel>> GetModuleReviews(CancellationToken ct)
        {
            var moduleReviews = await _moduleReviewService.GetItems(ct);
            return _mapper.Map<List<ModuleReviewViewModel>>(moduleReviews);
        }

        /// <summary>
        /// Adds moduleReview to database.
        /// </summary>
        /// <param name="moduleReview"><see cref="ModuleReviewViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added ModuleReview.</returns>
        [HttpPost]
        public async Task<ModuleReviewViewModel> Post(ModuleReviewViewModel moduleReview, CancellationToken ct)
        {
            var result = await _moduleReviewService.Add(_mapper.Map<ModuleReview>(moduleReview), ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }

        /// <summary>
        /// Updates a ModuleReview in database with specified id.
        /// </summary>
        /// <param name="id">ModuleReview unique identifier</param>
        /// <param name="moduleReview">ModuleReview to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated ModuleReview</returns>
        [HttpPut("{id}")]
        public async Task<ModuleReviewViewModel> Put(int id, ModuleReviewViewModel moduleReview, CancellationToken ct)
        {
            moduleReview.Id = id;
            var result = await _moduleReviewService.Update(_mapper.Map<ModuleReview>(moduleReview), ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }

        /// <summary>
        /// Deletes a ModuleReview in database with specified id.
        /// </summary>
        /// <param name="id">ModuleReview unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>ModuleReview deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<ModuleReviewViewModel?> Delete(int id, CancellationToken ct)
        {
            var result = await _moduleReviewService.Delete(id, ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }
    }
}
