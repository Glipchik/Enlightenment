﻿using AutoMapper;
using EnlightenmentApp.API.Models.Tag;
using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnlightenmentApp.API.Controllers
{
    [Route("api/Tags")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;
        private IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper)
        {
            this._tagService = tagService;
            this._mapper = mapper;
        }

        // GET: api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<TagViewModel?> GetTag(int id, CancellationToken ct)
        {
            var tag = _mapper.Map<TagViewModel>(await _tagService.GetById(id, ct));
            return tag;
        }

        // GET api/<Controller>
        [HttpGet]
        public async Task<List<TagViewModel>> GetTags(CancellationToken ct)
        {
            var tags = await _tagService.GetItems(ct);
            return _mapper.Map<List<TagViewModel>>(tags);
        }

        // POST api/<Controller>
        [HttpPost]
        public async Task<TagViewModel> Post(TagViewModel tag, CancellationToken ct)
        {
            var result = await _tagService.Add(_mapper.Map<Tag>(tag), ct);
            return _mapper.Map<TagViewModel>(result);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<TagViewModel> Put(int id, TagViewModel tag, CancellationToken ct)
        {
            tag.Id = id;
            var result = await _tagService.Update(_mapper.Map<Tag>(tag), ct);
            return _mapper.Map<TagViewModel>(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public async Task<TagViewModel> Delete(int id, CancellationToken ct)
        {
            var result = await _tagService.Delete(id, ct);
            return _mapper.Map<TagViewModel>(result);
        }
    }
}