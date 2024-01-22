using AutoMapper;
using EnlightenmentApp.API.Models.Section;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/sections")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;
        private readonly IMapper _mapper;

        public SectionController(ISectionService sectionService, IMapper mapper)
        {
            this._sectionService = sectionService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a Section with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">Section unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Section found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<SectionViewModel?> GetSection(int id, CancellationToken ct = default)
        {
            var section = _mapper.Map<SectionViewModel>(await _sectionService.GetById(id, ct));
            return section;
        }

        /// <summary>
        /// Gets all Sections from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found sections.</returns>
        [HttpGet]
        public async Task<List<SectionViewModel>> GetSections(CancellationToken ct = default)
        {
            var sections = await _sectionService.GetItems(ct);
            return _mapper.Map<List<SectionViewModel>>(sections);
        }

        /// <summary>
        /// Adds section to database.
        /// </summary>
        /// <param name="section"><see cref="SectionViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added Section.</returns>
        [HttpPost]
        public async Task<SectionViewModel> Post(SectionViewModel section, CancellationToken ct = default)
        {
            var result = await _sectionService.Add(_mapper.Map<Section>(section), ct);
            return _mapper.Map<SectionViewModel>(result);
        }

        /// <summary>
        /// Updates a Section in database with specified id.
        /// </summary>
        /// <param name="id">Section unique identifier</param>
        /// <param name="section">Section to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated Section</returns>
        [HttpPut("{id}")]
        public async Task<SectionViewModel> Put(int id, SectionViewModel section, CancellationToken ct = default)
        {
            section.Id = id;
            var result = await _sectionService.Update(_mapper.Map<Section>(section), ct);
            return _mapper.Map<SectionViewModel>(result);
        }

        /// <summary>
        /// Deletes a Section in database with specified id.
        /// </summary>
        /// <param name="id">Section unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Section deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<SectionViewModel?> Delete(int id, CancellationToken ct = default)
        {
            var result = await _sectionService.Delete(id, ct);
            return _mapper.Map<SectionViewModel>(result);
        }
    }
}
