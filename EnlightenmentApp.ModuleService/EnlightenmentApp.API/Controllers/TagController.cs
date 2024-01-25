using AutoMapper;
using EnlightenmentApp.API.Models.Tag;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            this._tagService = tagService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a Tag with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">Tag unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Tag found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<TagViewModel?> GetTag(int id, CancellationToken ct = default)
        {
            var tag = _mapper.Map<TagViewModel>(await _tagService.GetById(id, ct));
            return tag;
        }

        /// <summary>
        /// Gets all Tags from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found Tags.</returns>
        [HttpGet]
        public async Task<List<TagViewModel>> GetTags(CancellationToken ct = default)
        {
            var tags = await _tagService.GetItems(ct);
            return _mapper.Map<List<TagViewModel>>(tags);
        }

        /// <summary>
        /// Adds Tag to database.
        /// </summary>
        /// <param name="tag"><see cref="TagViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added Tag.</returns>
        [HttpPost]
        public async Task<TagViewModel> Post(TagViewModel tag, CancellationToken ct = default)
        {
            var result = await _tagService.Add(_mapper.Map<Tag>(tag), ct);
            return _mapper.Map<TagViewModel>(result);
        }

        /// <summary>
        /// Updates a Tag in database with specified id.
        /// </summary>
        /// <param name="id">Tag unique identifier</param>
        /// <param name="tag">Tag to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated Tag</returns>
        [HttpPut("{id}")]
        public async Task<TagViewModel> Put(int id, TagViewModel tag, CancellationToken ct = default)
        {
            tag.Id = id;
            var result = await _tagService.Update(_mapper.Map<Tag>(tag), ct);
            return _mapper.Map<TagViewModel>(result);
        }

        /// <summary>
        /// Deletes a Tag in database with specified id.
        /// </summary>
        /// <param name="id">Tag unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Tag deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<TagViewModel?> Delete(int id, CancellationToken ct = default)
        {
            var result = await _tagService.Delete(id, ct);
            return _mapper.Map<TagViewModel>(result);
        }
    }
}
