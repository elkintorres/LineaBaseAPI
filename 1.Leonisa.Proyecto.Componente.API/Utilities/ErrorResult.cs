// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-26-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="ErrorResult.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Class ErrorResult.
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public List<string> Messages { get; set; } = new();

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public string? Source { get; set; }
        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public string? Exception { get; set; }
        /// <summary>
        /// Gets or sets the error identifier.
        /// </summary>
        /// <value>The error identifier.</value>
        public string? ErrorId { get; set; }
        /// <summary>
        /// Gets or sets the support message.
        /// </summary>
        /// <value>The support message.</value>
        public string? SupportMessage { get; set; }
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; set; }
    }
}
