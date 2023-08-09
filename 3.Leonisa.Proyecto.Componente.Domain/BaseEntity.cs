// ***********************************************************************
// Assembly         : 3.Leonisa.Proyecto.Componente.Domain
// Author           : Arq. Elkin Torres
// Created          : 07-14-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="3.Leonisa.Proyecto.Componente.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3.Leonisa.Proyecto.Componente.Domain
{
    /// <summary>
    /// Class BaseEntity.
    /// </summary>
    [Table("BaseEntity")]
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the base entity identifier.
        /// </summary>
        /// <value>The base entity identifier.</value>
        [Key]
        [Column(name: "BaseEntityID")]
        [Required(ErrorMessage = "BaseEntityId can't empty or null")]
        public int BaseEntityId { get; set; }
    }
}
