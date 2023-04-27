using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Madeni.Server.Data;
using Microsoft.EntityFrameworkCore;


namespace Madeni.Server.Repository
{
    //TO DO Add Automapper to this repository for automatic mapping
    public class Repository<TEntity, TDto> : IRepository<TEntity, TDto> where TEntity : class, new()
    {
        protected readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public TDto AddItem(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            var result = _mapper.Map<TDto>(entity);
            return result;
        }
        public TEntity AddItems(ICollection<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            _context.SaveChanges();
            return _context.Set<TEntity>()?.AsEnumerable()?.LastOrDefault();
        }
        public TEntity GetItem(Expression<Func<TEntity, bool>> predicate)
         => _context.Set<TEntity>()?.FirstOrDefault(predicate);

        public IEnumerable<TDto> GetItems(Expression<Func<TEntity, bool>> predicate)
        {
            var items = _context.Set<TEntity>().Where(predicate);
            var result = _mapper.Map<IEnumerable<TDto>>(items);
            return result;
        }

        public (IEnumerable<TEntity> items, int count) GetItems(Expression<Func<TEntity, bool>> predicate, int? skipSize, int? count)
        => (
            _context.Set<TEntity>().Where(predicate).Skip((int)skipSize).Take((int)count),
            _context.Set<TEntity>().Where(predicate).ToList().Count()
          );

        public void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity item = _context.Set<TEntity>().FirstOrDefault(predicate);
            _context.Entry(item).State = EntityState.Deleted;
        }
    }
}
