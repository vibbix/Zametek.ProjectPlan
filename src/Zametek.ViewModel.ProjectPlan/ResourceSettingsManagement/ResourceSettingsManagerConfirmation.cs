using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Zametek.Common.ProjectPlan;
using Zametek.Contract.ProjectPlan;

namespace Zametek.ViewModel.ProjectPlan
{
    public class ResourceSettingsManagerConfirmation
        : IDialogResult
    {
        #region Ctors

        public ResourceSettingsManagerConfirmation(ResourceSettingsModel resourceSettings)
        {
            if (resourceSettings == null)
            {
                throw new ArgumentNullException(nameof(resourceSettings));
            }
            DefaultUnitCost = resourceSettings.DefaultUnitCost;
            AreDisabled = resourceSettings.AreDisabled;
            Resources = new ObservableCollection<IManagedResourceViewModel>();
            SetManagedResources(resourceSettings.Resources);
        }

        #endregion

        #region Properties

        public ObservableCollection<IManagedResourceViewModel> Resources
        {
            get;
        }

        public double DefaultUnitCost
        {
            get;
            set;
        }

        public bool AreDisabled
        {
            get;
            set;
        }

        public ResourceSettingsModel ResourceSettings
        {
            get
            {
                return new ResourceSettingsModel
                {
                    Resources = Resources.Select(x => x.Resource).ToList(),
                    DefaultUnitCost = DefaultUnitCost,
                    AreDisabled = AreDisabled
                };
            }
        }
        public IDialogParameters Parameters
        {
            get;
            private set;
        } = new DialogParameters();


        public ButtonResult Result
        {
            get;
            private set;
        }

        #endregion

        #region Private Methods

        private void SetManagedResources(IEnumerable<ResourceModel> resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }
            Resources.Clear();
            Resources.AddRange(resources.Select(x => new ManagedResourceViewModel(x)));
        }

        #endregion

        public ResourceSettingsManagerConfirmation withButtonResult(ButtonResult result)
        {
            this.Result = result;
            return this;
        }
    }
}
