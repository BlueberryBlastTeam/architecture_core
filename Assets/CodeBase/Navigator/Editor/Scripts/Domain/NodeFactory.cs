using System;
using Navigator.Editor.Views;
using UnityEditor.Experimental.GraphView;

namespace Navigator.Editor.Domain
{
    public class NodeFactory
    {
        public NodeFactory() { }
        
        public event Action<Node> CreatedEvent;

        public void Create(string name, string id, string className)
        {
            NodeView node = new NodeView("Assets/CodeBase/Navigator/Editor/Res/Layouts/NodeUXML.uxml");

            node.title = name;
            CreatedEvent?.Invoke(node);
        }
    }
}