using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
	public class GenericService<T> : IGenericService<T> where T : class
	{
		private readonly IGenericRepository<T> _repository;

		public GenericService(IGenericRepository<T> repository)
		{
			_repository = repository;
		}

		public async Task<T> AddAsync(T entity)
		{
			await _repository.AddAsync(entity);
			await _repository.SaveAsync();
			return entity;
		}

		public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
		{
			await _repository.AddRangeAsync(entities);
			await _repository.SaveAsync();
			return entities;
		}

		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
		{
			return await _repository.AnyAsync(predicate);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _repository.GetAll().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}
		public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
		{
			return _repository.Where(predicate);
		}
		public async Task RemoveAsync(T entity)
		{
			_repository.Remove(entity);
			await _repository.SaveAsync();
		}

		public async Task RemoveRangeAsync(IEnumerable<T> entities)
		{
			_repository.RemoveRange(entities);
			await _repository.SaveAsync();
		}

		public async Task UpdateAsync(T entity)
		{
			_repository.Update(entity);
			await _repository.SaveAsync();
		}


	}
}
