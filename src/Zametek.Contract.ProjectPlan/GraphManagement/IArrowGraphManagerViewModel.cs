using Prism.Interactivity.InteractionRequest;
using System.Windows.Input;
using Zametek.Common.ProjectPlan;

namespace Zametek.Contract.ProjectPlan
{
    public interface IArrowGraphManagerViewModel
        : INamed
    {
        bool IsBusy { get; }

        bool HasStaleArrowGraph { get; }

        ArrowGraphData ArrowGraphData { get; }

        ICommand GenerateArrowGraphCommand { get; }

        byte[] ExportArrowGraphToDiagram(DiagramArrowGraphModel diagramArrowGraph);
    }
}
