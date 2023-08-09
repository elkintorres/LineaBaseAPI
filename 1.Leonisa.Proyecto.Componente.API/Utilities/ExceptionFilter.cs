// ***********************************************************************
// Assembly         : 1.Leonisa.Proyecto.Componente.API
// Author           : Arq. Elkin Torres
// Created          : 07-19-2023
//
// Last Modified By : Arq. Elkin Torres
// Last Modified On : Arq. Elkin Torres
// ***********************************************************************
// <copyright file="ExceptionFilter.cs" company="1.Leonisa.Proyecto.Componente.API">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Net;

namespace _1.Leonisa.Proyecto.Componente.API.Utilities
{
    /// <summary>
    /// Class ExceptionFilter.
    /// Implements the <see cref="IAsyncExceptionFilter" />
    /// </summary>
    /// <seealso cref="IAsyncExceptionFilter" />
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ExceptionFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionFilter" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when [exception asynchronous].
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Task.</returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var message = $"Request failed with Status Code {StatusCodes.Status500InternalServerError} and Error Id {Guid.NewGuid()}. Desciption {context.Exception.Message}";

            Guid errorId = Guid.NewGuid();
            ErrorResult errorResult = new()
            {
                ErrorId = errorId.ToString(),
                Source = context.Exception.TargetSite?.DeclaringType?.FullName,
                Exception = context.Exception.Message.Trim(),
                StatusCode = (int)HttpStatusCode.InternalServerError,
                SupportMessage = $"Provide the Error Id: {errorId} to the support team for further analysis.",
            };

            errorResult.Messages.Add(context.Exception.Message);

            context.HttpContext.Response.ContentType = "application/json";
            context.Result = new JsonResult(errorResult);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            _logger.LogError(context.Exception, message);


            return Task.CompletedTask;
        }
    }
}
