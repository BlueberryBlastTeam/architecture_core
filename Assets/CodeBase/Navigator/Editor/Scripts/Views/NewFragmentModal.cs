using Navigator.Editor.Domain;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Navigator.Editor.Views
{
    public class NewFragmentModal : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;
        
        private TextField _nameTextField;
        private TextField _idTextField;
        private TextField _classNameTextField;
        
        private void CreateGUI()
        {
            m_VisualTreeAsset.CloneTree(rootVisualElement);
            Button cancelButton = rootVisualElement.Q<Button>("cancel-btn");
            cancelButton.clickable.clicked += Close;
            
            Button createButton = rootVisualElement.Q<Button>("create-btn");
            createButton.clickable.clicked += OnCreate;
            
            _nameTextField = rootVisualElement.Q<TextField>("name--fragment");
            _idTextField = rootVisualElement.Q<TextField>("id--fragment");
            _classNameTextField = rootVisualElement.Q<TextField>("class-name--fragment");
        }

        private void OnCreate()
        {
            Debug.Log("Creating new fragment");
            string name = _nameTextField.value;
            string id = _idTextField.value;
            string className = _classNameTextField.value;
            
            ServiceLocator
                .GetInstance()
                .Resolve<NodeFactory>()
                .Create(name, id, className);
            
            this.Close();
        }
    }
}