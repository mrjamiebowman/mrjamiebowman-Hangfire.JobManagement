﻿using Hangfire.JobManagement.Abstractions;
using Hangfire.JobManagement.Services.Interfaces;
using Hangfire.JobManagement.Services.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hangfire.JobManagement.Services;

public class NotificationsFactoryService : INotificationsFactoryService
{
    // logger

    // vars
    private List<INotificationService> _notificationServices  = new List<INotificationService>();

    public NotificationsFactoryService()
    {

    }

    public Task<List<INotificationService>> GetNotificationServicesAsync(CancellationToken cancellation = default)
    {
        using var activity = OTel.Application.StartActivity($"{nameof(NotificationsFactoryService)}.{nameof(GetNotificationServicesAsync)}");

        // get notification services
        var serviceProvider = Builder.Services.BuildServiceProvider();
        _notificationServices = serviceProvider.GetServices<INotificationService>().ToList();

        return Task.FromResult(_notificationServices);
    }

    //public async Task ProcessEventAsync<T>(NotificationEvent<T> @event, CancellationToken cancellation = default) where T : BaseEvent
    //{
    //    using var activity = OTel.Application.StartActivity($"{nameof(NotificationsFactoryService)}.{nameof(ProcessEventAsync)}");

    //    // lookup notifications by the job or global
    //    var notificationServices = await GetNotificationServicesAsync();

    //    // get job notification settings (global or individual jobs)
    //    var notificationOptions = new NotificationOptions();

    //    // tasks
    //    var tasks = new List<Task>();

    //    // process notifications
    //    foreach (var notificationService in notificationServices)
    //    {
    //        // process event
    //        tasks.Add(notificationService.ProcessEventAsync<T>(@event, notificationOptions, cancellation));
    //    }

    //    // await all
    //    await Task.WhenAll(tasks);
    //} 
}
