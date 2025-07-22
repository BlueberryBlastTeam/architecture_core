using System.Collections.Generic;
using System.Linq;
using Navigator.Editor.Domain;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Navigator.Editor.Views
{
    public class NavigationGraph : GraphView
    {
        public new class UxmlFactory : UxmlFactory<NavigationGraph, GraphView.UxmlTraits> { }
        
        public NavigationGraph()
        {
            AddToClassList("graph-container");
            
            GridBackground back = new GridBackground
            {
                name = "background"
            };
            back.RemoveFromClassList("GridBackground");
            Insert(0, back);
            
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            graphViewChanged += OnGraphViewChanged;
            ServiceLocator.GetInstance().Resolve<NodeFactory>().CreatedEvent += OnCreateNode;
        }
        
        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            // return base.GetCompatiblePorts(startPort, nodeAdapter);
            
            return ports.ToList().Where(endPort =>
                endPort.direction != startPort.direction && 
                endPort.node != startPort.node
            ).ToList();
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            evt.menu.AppendAction("Create new Fragment", _ => CreateNode());
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphViewChange)
        {
            
            
            return graphViewChange;
        }

        private void CreateNode()
        {
            // NodeView node = new NodeView("Assets/CodeBase/Navigator/Editor/Res/Layouts/NodeUXML.uxml");
            // AddElement(node);
            NewFragmentModal window = EditorWindow.GetWindow<NewFragmentModal>();
            window.titleContent = new GUIContent("Create Fragment");
            window.ShowModalUtility();
        }

        private void OnCreateNode(Node node)
        {
            AddElement(node);
        }
    }
}