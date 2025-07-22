using Navigator.Editor.Domain;
using Navigator.Editor.StaticData;
using Navigator.Editor.ViewModels;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Navigator.Editor.Views
{
    public class MainWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
        private VisualElement m_layoutFromUXML;
        
        private NavbarView _navbarView;
        private VisualElement _contentContainer;
        
        [MenuItem("Window/Navigator")]
        public static void Open()
        {
            MainWindow window = GetWindow<MainWindow>();
            window.title = "Navigator";
        }

        private void OnEnable()
        {
            m_VisualTreeAsset.CloneTree(rootVisualElement);
            Toolbar toolbar = rootVisualElement.Q<Toolbar>(className: "navbar");
            _contentContainer = rootVisualElement.Q<VisualElement>(className: "content-container");
            
            RegisterBindings();
            _navbarView = new NavbarView(toolbar);
        }

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            
            root.Add(m_layoutFromUXML);
            root.Q<Button>("create-btn").clicked += OnCreateClicked;
            root.Q<Button>("browse-btn").clicked += OnOpenBrowser;
            
        }

        private void OnCreateClicked()
        {
            
        }

        private void OnOpenBrowser()
        {
            
        }

        private void RegisterBindings()
        {
            
            WindowStateMachine stateMachine = new WindowStateMachine(_contentContainer);
            ServiceLocator.GetInstance().Register<WindowStateMachine>(stateMachine);

            ServiceLocator.GetInstance().Register<NodeFactory>();  
            ServiceLocator.GetInstance().Register<NavbarViewModel>();
            
            stateMachine.RegisterWindow(ConstantValue.LoadNavigation, new TestView());
            stateMachine.RegisterWindow(ConstantValue.CreateNavigation, new NavigationGraph());
            stateMachine.RegisterWindow(ConstantValue.SaveNavigation, new TestView());
            stateMachine.RegisterWindow(ConstantValue.Help, new TestView());
        }

        private void OnDisable()
        {
            ServiceLocator.GetInstance().Dispose();
        }
    }
}