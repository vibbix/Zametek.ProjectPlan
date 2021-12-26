using OxyPlot;
using System.Windows.Input;

namespace Zametek.Contract.ProjectPlan
{
    public interface IEarnedValueChartManagerViewModel
        : INamed
    {
        bool IsBusy { get; }

        bool HasStaleOutputs { get; }

        PlotModel EarnedValueChartPlotModel { get; }

        int EarnedValueChartOutputWidth { get; set; }

        int EarnedValueChartOutputHeight { get; set; }

        ICommand CopyEarnedValueChartToClipboardCommand { get; }

        ICommand ExportEarnedValueChartToCsvCommand { get; }
    }
}
