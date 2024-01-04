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

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<ChapterViewModel?> GetChapter(int id, CancellationToken ct)
        {
            var chapter = _mapper.Map<ChapterViewModel>(await _chapterService.GetById(id, ct));
            return chapter;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<ChapterViewModel>> GetChapters(CancellationToken ct)
        {
            var chapters = await _chapterService.GetItems(ct);
            return _mapper.Map<List<ChapterViewModel>>(chapters);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<ChapterViewModel> Post(ChapterViewModel chapter, CancellationToken ct)
        {
            var result = await _chapterService.Add(_mapper.Map<Chapter>(chapter), ct);
            return _mapper.Map<ChapterViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<ChapterViewModel> Put(int id, ChapterViewModel chapter, CancellationToken ct)
        {
            chapter.Id = id;
            var result = await _chapterService.Update(_mapper.Map<Chapter>(chapter), ct);
            return _mapper.Map<ChapterViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<ChapterViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _chapterService.Delete(id, ct);
            return _mapper.Map<ChapterViewModel>(result);
        }
    }
}
