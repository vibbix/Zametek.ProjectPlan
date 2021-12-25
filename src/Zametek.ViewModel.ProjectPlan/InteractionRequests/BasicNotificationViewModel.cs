using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace Zametek.ViewModel.ProjectPlan
{
    public class BasicNotificationViewModel
        : BindableBase, IDialogAware
    {
        #region Fields

        private string _title = "Notification";
        private object _content = null;


        #endregion

        #region Ctors

        public BasicNotificationViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
        }

        #endregion

        #region Properties

        public object Content
        {
            get{ return _content; }
            private set{ SetProperty(ref _content, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        public Action OnClose
        {
            get;
            set;
        }

        public Action FinishInteraction
        {
            get;
            set;
        }

        public event Action<IDialogResult> RequestClose;

        #endregion

        #region Commands

        public ICommand ConfirmCommand
        {
            get;
            private set;
        }

        #endregion

        #region Public Methods

        public virtual void Confirm()
        {
            ConfirmInteraction?.Invoke();
            RaiseRequestClose(new DialogResult(ButtonResult.OK));
        }

        public Action ConfirmInteraction
        {
            get;
            set;
        }

        #endregion


        #region IDialogAware
        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
            
        }


        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("title");
            Content = parameters.GetValue<object>("content");
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            FinishInteraction?.Invoke();
            OnClose?.Invoke();
            RequestClose?.Invoke(dialogResult);
        }

        #endregion
    }
}
