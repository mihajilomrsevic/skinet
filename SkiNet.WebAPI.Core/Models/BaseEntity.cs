//-------------------------------------------------------------------------------
// <copyright file="BaseEntity.cs" company="SkiNet">
//     Copyright (c) All rights reserved.
// </copyright>
//-------------------------------------------------------------------------------
namespace SkiNet.WebAPI.Core.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// BaseEntity class made to contains a mutual properties.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
    }
}