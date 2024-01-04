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
        protected readonly IMapper _mapper;

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
            if (item != null)
            {
                var entity = await _repository.Add(_mapper.Map<TMapToEntity>(item), ct);
                var result = _mapper.Map<TItem>(entity);
                return result;
            }

            throw new ArgumentNullException();
        }

        public virtual async Task<TItem> Delete(int id, CancellationToken ct)
        {
            var itemExists = await _repository.EntityExists(id, ct);
            if (itemExists)
            {
                var entity = await _repository.Delete(id, ct);
                var result = _mapper.Map<TItem>(entity);
                return result;
            }

            throw new KeyNotFoundException();
        }

        public virtual async Task<TItem> Update(TItem item, CancellationToken ct)
        {
            var entity = _mapper.Map<TMapToEntity>(item);
            var itemExists = await _repository.EntityExists(entity, ct);
            if (itemExists)
            {
                var result = _mapper.Map<TItem>(await _repository.Update(entity, ct));
                return result;
            }

            throw new DbUpdateConcurrencyException();
        }
    }
}
