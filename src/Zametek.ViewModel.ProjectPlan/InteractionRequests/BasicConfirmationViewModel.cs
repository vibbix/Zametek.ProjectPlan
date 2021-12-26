using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace Zametek.ViewModel.ProjectPlan
{
    public class BasicConfirmationViewModel
        : BasicNotificationViewModel
    {
        #region Fields

        #endregion

        #region Ctors

        public BasicConfirmationViewModel()
        {
            CancelCommand = new DelegateCommand(Cancel);
        }

        #endregion

        #region Commands

        public ICommand CancelCommand
        {
            get;
            private set;
        }

        #endregion

        #region Public Methods

        public virtual void Cancel()
        {
            ConfirmInteraction?.Invoke();
            CancelInteraction?.Invoke();
            RaiseRequestClose(new DialogResult(ButtonResult.Cancel));
        }

        public Action CancelInteraction
        {
            get;
            set;
        }

        #endregion

        #region Overrides
        public override bool CanCloseDialog()
        {
            return true;
        }

        #endregion
    }
}
