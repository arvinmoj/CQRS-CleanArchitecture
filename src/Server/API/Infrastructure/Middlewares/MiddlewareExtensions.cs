using System;
namespace API.Infrastructure.Middlewares
{
    public static class MiddlewareExtensions
    {
        static MiddlewareExtensions()
        {
        }

        public static Microsoft.AspNetCore.Builder.IApplicationBuilder
            UseExceptionHandlingMiddleware(this Microsoft.AspNetCore.Builder.IApplicationBuilder builder)
        {
            // UseMiddleware -> Extension Method -> using Microsoft.AspNetCore.Builder;
            return builder.UseMiddleware
                <Middlewares.ExceptionHandlingMiddleware>();
        }
    }
}
