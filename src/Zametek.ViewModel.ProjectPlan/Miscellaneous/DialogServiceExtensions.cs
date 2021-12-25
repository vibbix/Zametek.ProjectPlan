using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zametek.ViewModel.ProjectPlan.Miscellaneous
{
    public static class DialogServiceExtensions
    {
        public static void ShowNotification(this IDialogService dialogService, string message, Action<IDialogResult> callBack)
        {
            dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), callBack);
        }

        public static void DispatchNotification(this IDialogService dialogService, string title, string message)
        {
            var dp = new DialogParameters($"content={message}");
            dp.Add("title", title);
            dp.Add("content", message);
            dialogService.ShowDialog("NotificationDialog", dp, null); ;

        }
    }
}
