using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountManager.Data.Core
{
    public abstract class DataServiceBase<TEntity, TId, TContext>
        where TId: IEquatable<TId>
        where TEntity: ModelBase<TId>
        where TContext: DbContext
    {
        public DataServiceBase(IMapper mapper, TContext context)
        {
            Context = context;
            Mapper = mapper;
        }

        protected TContext Context { get; set; }
        protected IMapper Mapper { get; set; }

        public IQueryable<TDto> GeTAll<TDto>(params string[] includes)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();

            return Mapper.ProjectTo<TDto>(table);
        }

        public IQueryable<TDto> GeTAll<TDto>(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            return Mapper.ProjectTo<TDto>(table.Where(filter));
        }

        public TDto GetById<TDto>(TId id, params string[] includes)
        {
            IQueryable<TEntity> table = Context.Set<TEntity>();
            if(includes != null)
            {
                foreach (string include in includes)
                {
                    table = table.Include(include);
                }
            }

            TEntity entity = table.AsNoTracking()
                .SingleOrDefault(e => e.Id.Equals(id));

            if (entity == null)
                return default(TDto);

            

            return Mapper.Map<TDto>(entity);
        }

        public TDto GetByParamneters<TDto>(Expression<Func<TEntity, bool>> filter, params string[] includes)
        {
            DbSet<TEntity> table = Context.Set<TEntity>();
            if (includes != null)
            {
                foreach (string include in includes)
                {
                    table.Include(include);
                }
            }

            TEntity entity = table.AsNoTracking()
                .SingleOrDefault(filter);

            if (entity == null)
                return default(TDto);

            

            return Mapper.Map<TDto>(entity);
        }
        public TDto GetById<TDto>(TId id)
        {
            TEntity entity = Context.Find<TEntity>(id);
            if (entity == null)
                return default(TDto);

            Context.Entry(entity).State = EntityState.Detached;

            return Mapper.Map<TDto>(entity);
        }

        public int Save<TDto>(TDto dto)
        {
            TEntity entity = Mapper.Map<TEntity>(dto);

            if (entity.IsTransient())
            {
                Context.Add(entity);
            }
            else
            {
                TEntity updateEntity = Context.Find<TEntity>(entity.Id);
                updateEntity = Mapper.Map(dto, updateEntity);
            }

            return Context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            Context.Remove(entity);
            return Context.SaveChanges();
        }

        public int Delete(TId id)
        {
            TEntity deleteEntity = Context.Find<TEntity>(id);
            if(deleteEntity == null)
                return 0;

            return Delete(deleteEntity);
        }
    }
}
