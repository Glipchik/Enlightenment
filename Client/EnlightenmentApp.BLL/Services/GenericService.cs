using EnlightenmentApp.BLL.Entities;
using EnlightenmentApp.BLL.Interfaces.Services;
using EnlightenmentApp.DAL.Interfaces.Repositories;
using AutoMapper;
using EnlightenmentApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnlightenmentApp.BLL.Services
{
    public class GenericService<TItem, TMapToEntity> : IGenericService<TItem>
        where TItem : BaseItem
        where TMapToEntity : BaseEntity
    {
        protected readonly IGenericRepository<TMapToEntity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TMapToEntity> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public virtual async Task<IEnumerable<TItem>> GetItems(CancellationToken ct)
        {
            var result = _mapper.Map<IEnumerable<TItem>>(await _repository.GetEntities(ct));
            return result;
        }

        public virtual async Task<TItem> GetById(int id, CancellationToken ct)
        {
            var result = _mapper.Map<TItem>(await _repository.GetById(id, ct));
            if (result != null)
            {
                return result;
            }

            throw new KeyNotFoundException();
        }

        public virtual async Task<TItem> Add(TItem item, CancellationToken ct)
        {
            var entity = await _repository.Add(_mapper.Map<TMapToEntity>(item), ct);
            if (entity != null)
            {
                var result = _mapper.Map<TItem>(entity);
                return result;
            }

            throw new ArgumentNullException();
        }

        public virtual async Task<TItem> Delete(int id, CancellationToken ct)
        {
            TItem result;
            TMapToEntity? entity;
            try
            {
                entity = await _repository.Delete(id, ct);
            }
            catch
            {
                throw new KeyNotFoundException();
            }
            if (entity != null)
            {
                result = _mapper.Map<TItem>(entity);
                return result;
            }

            throw new KeyNotFoundException();
        }

        public virtual async Task<TItem> Update(TItem item, CancellationToken ct)
        {
            if (await _repository.EntityExists(_mapper.Map<TMapToEntity>(item), ct))
            {
                var entity = await _repository.Update(_mapper.Map<TMapToEntity>(item), ct);
                var result = _mapper.Map<TItem>(entity);
                return result;
            }

            throw new DbUpdateConcurrencyException();
        }
    }
}
