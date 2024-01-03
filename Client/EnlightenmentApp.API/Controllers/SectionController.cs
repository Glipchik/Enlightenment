using AutoMapper;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/Sections")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private ISectionService _sectionService;
        private IMapper _mapper;
        public SectionController(ISectionService sectionService, IMapper mapper)
        {
            this._sectionService = sectionService;
            this._mapper = mapper;
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<SectionViewModel?> GetSection(int id, CancellationToken ct)
        {
            var section = _mapper.Map<SectionViewModel>(await _sectionService.GetById(id, ct));
            return section;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<SectionViewModel>> GetSections(CancellationToken ct)
        {
            var sections = await _sectionService.GetItems(ct);
            return _mapper.Map<List<SectionViewModel>>(sections);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<SectionViewModel> Post(SectionViewModel section, CancellationToken ct)
        {
            var result = await _sectionService.Add(_mapper.Map<Section>(section), ct);
            return _mapper.Map<SectionViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<SectionViewModel> Put(int id, SectionViewModel section, CancellationToken ct)
        {
            section.Id = id;
            var result = await _sectionService.Update(_mapper.Map<Section>(section), ct);
            return _mapper.Map<SectionViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<SectionViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _sectionService.Delete(id, ct);
            return _mapper.Map<SectionViewModel>(result);
        }
    }
}
