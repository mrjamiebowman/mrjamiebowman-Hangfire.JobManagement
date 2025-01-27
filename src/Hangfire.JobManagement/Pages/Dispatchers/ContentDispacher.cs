﻿using Hangfire.Dashboard;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Hangfire.JobManagement.Pages.Dispatchers;

internal class ContentDispatcher : IDashboardDispatcher
{
    private static readonly Assembly ThisAssembly = typeof(ContentDispatcher).Assembly;
    private readonly string _contentType;
    private readonly string _resourceName;
    private readonly TimeSpan _expiresIn;

    public ContentDispatcher(string contentType, string resourceName, TimeSpan expiresIn) {
        _contentType = contentType;
        _resourceName = resourceName;
        _expiresIn = expiresIn;
    }

    public async Task Dispatch(DashboardContext context) {
        using var activity = OTel.Application.StartActivity($"{nameof(ContentDispatcher)}.{nameof(Dispatch)}");
        context.Response.ContentType = _contentType;
        context.Response.SetExpire(DateTimeOffset.UtcNow + _expiresIn);
        await WriteResourceAsync(context);
    }

    private async Task WriteResourceAsync(DashboardContext context) {
        using (var stream = ThisAssembly.GetManifestResourceStream(_resourceName)) {
            if (stream == null) {
                context.Response.StatusCode = 404;
            } else {
                await stream.CopyToAsync(context.Response.Body);
            }
        }
    }
}
