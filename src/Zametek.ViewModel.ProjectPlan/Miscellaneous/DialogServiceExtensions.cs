using Prism.Services.Dialogs;
using System.Threading.Tasks;

namespace Zametek.ViewModel.ProjectPlan.Miscellaneous
{
    public static class DialogServiceExtensions
    {

        /// <summary>
        /// Shows a modal dialog, return the result as a task
        /// </summary>
        /// <param name="dialogService">The service to use</param>
        /// <param name="name">Name of the dialog</param>
        /// <param name="parameters">The parameters to pass</param>
        /// <returns>A Task containing the result</returns>
        public static Task<IDialogResult> ShowDialogAsync(this IDialogService dialogService, string name, IDialogParameters parameters)
        {
            var t = new TaskCompletionSource<IDialogResult>();
            dialogService.ShowDialog(name, parameters, s => t.TrySetResult(s));
            return t.Task;
        }

        /// <summary>
        /// Shows a non-modal dialog, return the result as a task
        /// </summary>
        /// <param name="dialogService">The service to use</param>
        /// <param name="name">Name of the dialog</param>
        /// <param name="parameters">The parameters to pass</param>
        /// <returns>A Task containing the result</returns>
        public static Task<IDialogResult> ShowAsync(this IDialogService dialogService, string name, IDialogParameters parameters)
        {
            var t = new TaskCompletionSource<IDialogResult>();
            dialogService.Show(name, parameters, s => t.TrySetResult(s));
            return t.Task;
        }

        public static Task<IDialogResult> DispatchNotification(this IDialogService dialogService, string title, string message)
        {
            var dp = new DialogParameters($"content={message}")
            {
                { "title", title },
                { "content", message }
            };
            var t = new TaskCompletionSource<IDialogResult>();
            dialogService.ShowDialog("NotificationDialog", dp, s => t.TrySetResult(s));
            return t.Task;
        }

        public static Task<IDialogResult> DispatchConfirmation(this IDialogService dialogService, string title, string message)
        {
            var dp = new DialogParameters($"content={message}")
            {
                { "title", title },
                { "content", message }
            };
            var t = new TaskCompletionSource<IDialogResult>();
            dialogService.ShowDialog("ConfirmationDialog", dp, s => t.TrySetResult(s));
            return t.Task;
        }
    }
}
