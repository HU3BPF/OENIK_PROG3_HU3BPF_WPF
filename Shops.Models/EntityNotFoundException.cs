// <copyright file="EntityNotFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Shops.Data.Models
{
    using System;

    /// <summary>
    /// Costume Exception.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner Exception.</param>
        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc/>
        public override string Message => "Entity not found.".ToString();

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// Entity not found exception.
        /// </summary>
        public EntityNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="message">New Message.</param>
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
