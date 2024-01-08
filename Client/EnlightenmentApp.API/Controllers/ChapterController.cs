using AutoMapper;
using EnlightenmentApp.API.Models.Chapter;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;
        private readonly IMapper _mapper;

        public ChapterController(IChapterService chapterService, IMapper mapper)
        {
            this._chapterService = chapterService;
            this._mapper = mapper;
        }

        /// <summary>
        /// Finds a Chapter with specified <paramref name="id"/> in database.
        /// </summary>
        /// <param name="id">Chapter unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Chapter found or <see langword="null"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ChapterViewModel?> GetChapter(int id, CancellationToken ct)
        {
            var chapter = _mapper.Map<ChapterViewModel>(await _chapterService.GetById(id, ct));
            return chapter;
        }

        /// <summary>
        /// Gets all Chapters from database.
        /// </summary>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>List of found chapters.</returns>
        [HttpGet]
        public async Task<List<ChapterViewModel>> GetChapters(CancellationToken ct)
        {
            var chapters = await _chapterService.GetItems(ct);
            return _mapper.Map<List<ChapterViewModel>>(chapters);
        }

        /// <summary>
        /// Adds chapter to database.
        /// </summary>
        /// <param name="chapter"><see cref="ChapterViewModel"/> to be added.</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Added Chapter.</returns>
        [HttpPost]
        public async Task<ChapterViewModel> Post(ChapterViewModel chapter, CancellationToken ct)
        {
            var result = await _chapterService.Add(_mapper.Map<Chapter>(chapter), ct);
            return _mapper.Map<ChapterViewModel>(result);
        }

        /// <summary>
        /// Updates a Chapter in database with specified id.
        /// </summary>
        /// <param name="id">Chapter unique identifier</param>
        /// <param name="chapter">Chapter to be updated</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Updated Chapter</returns>
        [HttpPut("{id}")]
        public async Task<ChapterViewModel> Put(int id, ChapterViewModel chapter, CancellationToken ct)
        {
            chapter.Id = id;
            var result = await _chapterService.Update(_mapper.Map<Chapter>(chapter), ct);
            return _mapper.Map<ChapterViewModel>(result);
        }

        /// <summary>
        /// Deletes a Chapter in database with specified id.
        /// </summary>
        /// <param name="id">Chapter unique identifier</param>
        /// <param name="ct"><see cref="CancellationToken"/> used to cancel a task.</param>
        /// <returns>Chapter deleted or <see langword="null"/></returns>
        [HttpDelete("{id}")]
        public async Task<ChapterViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _chapterService.Delete(id, ct);
            return _mapper.Map<ChapterViewModel>(result);
        }
    }
}
