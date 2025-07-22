using Navigator.Editor.Domain;
using UnityEngine;
using UnityEngine.UIElements;

namespace Navigator.Editor.ViewModels
{
    public class NavbarViewModel
    {
        private readonly WindowStateMachine _stateMachine;

        public NavbarViewModel()
        {
            _stateMachine = ServiceLocator.GetInstance().Resolve<WindowStateMachine>();
        }
        
        public void OnBrowseNavigation()
        {
            Debug.Log($"Open Browser");
        }

        public void OnHandlerDropdownAction(DropdownMenuAction action)
        {
            _stateMachine.Open(action.name);
        }

        public void OnOpenHelp()
        {
            Debug.Log("Open help");
        }
    }
}