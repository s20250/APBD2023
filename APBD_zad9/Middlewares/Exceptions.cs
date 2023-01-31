
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_zad9.Middlewares
{
    public class Exceptions
    {
        private readonly RequestDelegate _next;
        private readonly string _path = "logs.txt";

        public Exceptions (RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            } catch (Exception exc)
            {
                await LogExceptionAsync(context, exc);
            }
        }

        private async Task LogExceptionAsync(HttpContext context, Exception exc)
        {
            var stream = new StreamWriter(_path, true);
            await using var _ = stream.ConfigureAwait(false);
            await stream.WriteLineAsync($"{DateTime.Now},{context.TraceIdentifier},{exc.HResult}")
                .ConfigureAwait(false);
            await _next(context).ConfigureAwait(false);
        }
    }
}