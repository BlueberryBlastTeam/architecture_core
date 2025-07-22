using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Navigator.Editor.Views
{
    public class NodeView : Node
    {
        public Port input;
        public Port output;

        public NodeView(string uxmlPath) : base(uxmlPath)
        {
            // this.UseDefaultStyling();
            CreateInputPorts();
            CreateOutputPorts();
        }

        private void CreateInputPorts()
        {
            input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            if (input != null)
            {
                input.portName = "";
                input.style.flexDirection = FlexDirection.Row;
                inputContainer.Add(input);
            }
        }
        
        private void CreateOutputPorts()
        {
            output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
            if (output != null)
            {
                output.portName = "";
                output.style.flexDirection = FlexDirection.RowReverse;
                outputContainer.Add(output);
            }
        }
    }
}