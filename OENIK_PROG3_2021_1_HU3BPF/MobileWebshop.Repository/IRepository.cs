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
    internal interface IRepository<T>
        where T : class
    {
        // CRUD.
        // Modosítás nem generikus!.

        /// <summary>
        /// One Entity read.
        /// </summary>
        /// <param name="id">Entity id.</param>
        /// <returns>Entity value.</returns>
        T GetOne(int id);

        /// <summary>
        /// All properties read.
        /// </summary>
        /// <returns>All properties.</returns>
        IQueryable<T> GetALL();
    }
}
