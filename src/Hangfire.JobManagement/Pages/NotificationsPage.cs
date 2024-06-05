﻿using Hangfire.Dashboard.Pages;
using Hangfire.JobManagement.Core;

namespace Hangfire.JobManagement.Pages
{
    internal sealed class NotificationsPage : PageBase
    {
        public const string Title = "Notifications";
        public const string PageRoute = "/management/notifications";

        private static readonly string PageHtml;

        static NotificationsPage()
        {
            PageHtml = Utility.ReadStringResource("Hangfire.JobManagement.Dashboard.Notifications.html");
        }

        public override void Execute()
        {
            WriteEmptyLine();
            Layout = new LayoutPage(Title);
            WriteLiteralLine(PageHtml);
            WriteEmptyLine();
        }
    }
}
