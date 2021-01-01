﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Database;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicantDBContext _customerContext;

        public Repository(ApplicantDBContext customerContext)
        {
            _customerContext = customerContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _customerContext.Set<TEntity>();
            }
            catch (Exception)
            {
                throw new Exception("Couldn't retrieve entities");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _customerContext.AddAsync(entity);
                await _customerContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _customerContext.Update(entity);
                await _customerContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception($"{nameof(entity)} could not be updated");
            }
        }
    }
}