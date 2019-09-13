﻿using Hangfire.Annotations;
using Hangfire.Dashboard;
using Hangfire.RecurringJobAdmin.Pages;
using System;
using System.Reflection;

namespace Hangfire.RecurringJobAdmin
{
    public static class ConfigurationExtensions
    {

        [PublicAPI]
        public static IGlobalConfiguration UseRecurringJobAdmin(this IGlobalConfiguration config, string assembly)
        {
            PeriodicJobBuilder.GetAllJobs(Type.GetType(assembly).Assembly);
            CreateManagmentJob();
            return config;
        }


        [PublicAPI]
        public static IGlobalConfiguration UseRecurringJobAdmin(this IGlobalConfiguration config, Assembly assembly)
        {
            PeriodicJobBuilder.GetAllJobs(assembly);
            CreateManagmentJob();
            return config;
        }


        [PublicAPI]
        public static IGlobalConfiguration UseRecurringJobAdmin(this IGlobalConfiguration config)
        {
            CreateManagmentJob();
            return config;
        }

        private static void CreateManagmentJob()
        {
            DashboardRoutes.Routes.AddRazorPage(JobExtensionPage.PageRoute, x => new JobExtensionPage());
            DashboardRoutes.Routes.Add("/JobConfiguration/GetJobs", new GetJobDispatcher());
            DashboardRoutes.Routes.Add("/JobConfiguration/UpdateJobs", new ChangeJobDispatcher());

            NavigationMenu.Items.Add(page => new MenuItem(JobExtensionPage.Title, "JobConfiguration")
            {
                Active = page.RequestPath.StartsWith(JobExtensionPage.PageRoute)
            });

           AddDashboardRouteToEmbeddedResource("/JobConfiguration/js/page", "application/js", "Hangfire.RecurringJobAdmin.Dashboard.Content.jobextension.js");
           AddDashboardRouteToEmbeddedResource("/JobConfiguration/js/vue", "application/js", "Hangfire.RecurringJobAdmin.Dashboard.Content.vue.js");
           AddDashboardRouteToEmbeddedResource("/JobConfiguration/js/axio", "application/js", "Hangfire.RecurringJobAdmin.Dashboard.Content.axios.min.js");

        }

        private static void AddDashboardRouteToEmbeddedResource(string route, string contentType, string resourceName)
           => DashboardRoutes.Routes.Add(route, new ContentDispatcher(contentType, resourceName, TimeSpan.FromDays(1)));
    }

    
}
