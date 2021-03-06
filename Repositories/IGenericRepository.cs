using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeAlkemyC.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
		Task<List<TEntity>> GetAll();
		Task<TEntity> GetById(int id); // to search by id
		Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); // to search by name
		Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate); // to search by name
		Task<TEntity> Insert(TEntity entity);
		Task<TEntity> Update(TEntity entity);
		Task Delete(int id);
		IQueryable<TEntity> GetQueryable();
	}
}
