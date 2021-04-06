// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Shops.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Shops.Data.Models;

    /// <summary>
    /// Repository funcions.
    /// </summary>
    /// <typeparam name="T">T is a class.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        T GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All Entities.</returns>
        IQueryable<T> GetALL();

        /// <summary>
        /// One Entity inserter.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Entity Remove.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Remove(T entity);
    }

    /// <summary>
    /// Repository funcions.
    /// </summary>
    /// <typeparam name="T">T is a class.</typeparam>
    public abstract class AncestorRepository<T> : IRepository<T>
     where T : class
    {
        /// <summary>
        /// Dbcontext.
        /// </summary>
        private readonly DbContext ctx;

        /// <summary>
        /// Gets ctx dbcontext.
        /// </summary>
        protected DbContext Ctx
        {
            get { return this.ctx; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AncestorRepository{T}"/> class.
        /// Dbcontext Sets.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        protected AncestorRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AncestorRepository{T}"/> class.
        /// </summary>
        private AncestorRepository()
        {
        }

        /// <summary>
        ///  All Entities reader.
        /// </summary>
        /// <returns>All Entities.</returns>
        public IQueryable<T> GetALL()
        {
            return this.ctx.Set<T>();
        }

        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// One Entity insert.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Entity Remove.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            this.ctx?.Set<T>()?.Remove(entity);
            this.ctx.SaveChanges();
        }
    }
}
