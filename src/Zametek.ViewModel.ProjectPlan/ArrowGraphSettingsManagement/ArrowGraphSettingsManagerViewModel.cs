using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using Zametek.Contract.ProjectPlan;

namespace Zametek.ViewModel.ProjectPlan
{
    public class ArrowGraphSettingsManagerViewModel
        : BasicConfirmationViewModel, IArrowGraphSettingsManagerViewModel
    {
        #region Fields
        private ArrowGraphSettingsManagerConfirmation managerConfirmation;
        #endregion

        #region Ctors

        public ArrowGraphSettingsManagerViewModel()
            : base()
        {
        }

        #endregion

        #region Properties
        public ArrowGraphSettingsManagerConfirmation Confirmation
        {
            get { return managerConfirmation; }
            private set { SetProperty(ref managerConfirmation, value); }

        }
        #endregion

        #region IArrowGraphSettingsManagerViewModel Members

        public ObservableCollection<IManagedActivitySeverityViewModel> ActivitySeverities
        {
            get
            {
                return Confirmation.ActivitySeverities;
            }
        }

        #endregion

        public override void RaiseRequestClose(IDialogResult dialogResult)
        {
            base.RaiseRequestClose(this.managerConfirmation.withButtonResult(dialogResult.Result));
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Confirmation = parameters.GetValue<ArrowGraphSettingsManagerConfirmation>("confirmation");
        }
    }
}
