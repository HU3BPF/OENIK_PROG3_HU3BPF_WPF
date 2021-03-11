// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MobileWebshop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
        /// One Entity insert.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Entity remover.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Remover(T entity);
    }
}
