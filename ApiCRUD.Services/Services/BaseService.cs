using ApiCRUD.Bl.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiCRUD.Services
{
    public interface IBaseService<TEntity,TDto, TContext> 
        where TEntity : class
        where TDto : BaseDto
        where TContext : DbContext
    {
        Task<List<TDto>> GetAll();

        Task<TDto> GetById(int id);

        Task<TDto> Add (TDto dto);

        Task<bool> Update (int id, TDto dto);

        Task<bool> Delete (int id);
    }
    public class BaseService<TEntity,TDto, TContext> : IBaseService<TEntity, TDto, TContext> 
        where TEntity : class
        where TDto : BaseDto
        where TContext : DbContext
    {
        public readonly TContext _context;

        public readonly DbSet<TEntity> _dbSet;

        public readonly IMapper _mapper;

        public BaseService(TContext context, IMapper mapper)
        {
            _dbSet = context.Set<TEntity>();    
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<TDto>> GetAll()
        {
            var entities =  await _dbSet.ToListAsync();
            var entitiesDto = _mapper.Map<List<TDto>>(entities);

            return entitiesDto;
        }

        public async Task<TDto> Add(TDto dto)
        {

            var entity = _mapper.Map<TEntity>(dto);

            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            var resultDto = _mapper.Map(entity, dto);

            return resultDto;
        }

        public async Task<TDto> GetById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            
            var dto = _mapper.Map<TDto>(entity);
            
            return dto;
        }
        public async Task<bool> Update(int id, TDto update)
        {
            var entity = await _dbSet.FindAsync(id);

            if( entity == null )
            {
                return false;
            }

            var updated = _mapper.Map<TDto,TEntity>(update, entity);

            _context.Entry(updated).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity == null) { return false; }

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
