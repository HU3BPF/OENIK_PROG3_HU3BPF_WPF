// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Repository funcions.
    /// </summary>
    /// <typeparam name="T">T is a class.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        // CRUD.
        // Modosítás nem generikus!.

        /// <summary>
        /// One Entity reader.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        T GetOne(int id);

        /// <summary>
        /// All Entities reader.
        /// </summary>
        /// <returns>All properties.</returns>
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
        private DbContext ctx;

        /// <summary>
        /// Gets ctx dbcontext.
        /// </summary>
        protected DbContext Ctx
        {
          get { return this.ctx; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AncestorRepository{T}"/> class.
        /// Dbcontext set.
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
        /// <returns>All properties.</returns>
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
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// Entity Remove.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public void Remove(T entity)
        {
            this.ctx.Set<T>().Remove(entity);
            this.ctx.SaveChanges();
        }
    }
}
