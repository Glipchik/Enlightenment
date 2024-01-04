using AutoMapper;
using EnlightenmentApp.API.Models.ModuleReview;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/ModuleReviews")]
    [ApiController]
    public class ModuleReviewController : ControllerBase
    {
        private IModuleReviewService _moduleReviewService;
        private IMapper _mapper;

        public ModuleReviewController(IModuleReviewService moduleReviewService, IMapper mapper)
        {
            this._moduleReviewService = moduleReviewService;
            this._mapper = mapper;
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<ModuleReviewViewModel?> GetModuleReview(int id, CancellationToken ct)
        {
            var moduleReview = _mapper.Map<ModuleReviewViewModel>(await _moduleReviewService.GetById(id, ct));
            return moduleReview;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<ModuleReviewViewModel>> GetModuleReviews(CancellationToken ct)
        {
            var moduleReviews = await _moduleReviewService.GetItems(ct);
            return _mapper.Map<List<ModuleReviewViewModel>>(moduleReviews);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<ModuleReviewViewModel> Post(ModuleReviewViewModel moduleReview, CancellationToken ct)
        {
            var result = await _moduleReviewService.Add(_mapper.Map<ModuleReview>(moduleReview), ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<ModuleReviewViewModel> Put(int id, ModuleReviewViewModel moduleReview, CancellationToken ct)
        {
            moduleReview.Id = id;
            var result = await _moduleReviewService.Update(_mapper.Map<ModuleReview>(moduleReview), ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<ModuleReviewViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _moduleReviewService.Delete(id, ct);
            return _mapper.Map<ModuleReviewViewModel>(result);
        }
    }
}
