// ***********************************************************************
// Assembly         : 3.Leonisa.Proyecto.Componente.Domain
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="Products.cs" company="3.Leonisa.Proyecto.Componente.Domain">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3.Leonisa.Proyecto.Componente.Domain
{
    [Table("Products")]
    /// <summary>
    /// Clase que representa la entidad "Products" en la base de datos.
    /// </summary>
    public class Products : IValidatableObject
    {
        /// <summary>
        /// Clave primaria de la entidad "Products".
        /// </summary>
        /// <value>The product identifier.</value>
        [Key]
        [Column(name: "ProductID")]
        public int ProductID { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        /// <value>The name of the product.</value>
        [StringLength(maximumLength: 40, MinimumLength = 3, ErrorMessage = "ProductName no puede tener mas de 40 caracteres")]
        public string ProductName { get; set; }

        /// <summary>
        /// Identificador del proveedor del producto (puede ser nulo).
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Identificador de la categoría del producto (puede ser nulo).
        /// </summary>
        /// <value>The category identifier.</value>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Cantidad por unidad del producto.
        /// </summary>
        /// <value>The quantity per unit.</value>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Precio unitario del producto (puede ser nulo).
        /// </summary>
        /// <value>The unit price.</value>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Unidades en stock del producto (puede ser nulo).
        /// </summary>
        /// <value>The units in stock.</value>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// Unidades en orden del producto (puede ser nulo).
        /// </summary>
        /// <value>The units on order.</value>
        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Nivel de reorden del producto (puede ser nulo).
        /// </summary>
        /// <value>The reorder level.</value>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Indica si el producto ha sido descontinuado.
        /// </summary>
        /// <value><c>true</c> if discontinued; otherwise, <c>false</c>.</value>
        public bool Discontinued { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new();

            if (UnitPrice <= 0)
                result.Add(new ValidationResult("Unit Price no pueder ser menor o igual a 0", new List<string>() { nameof(UnitPrice) }));

            return result;
        }
    }
}
