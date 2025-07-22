using Navigator.Editor.Domain;
using Navigator.Editor.StaticData;
using Navigator.Editor.ViewModels;
using UnityEditor.UIElements;

namespace Navigator.Editor.Views
{
    public class NavbarView 
    {
        private readonly NavbarViewModel _viewModel;
        private readonly Toolbar _toolbar;
        
        public NavbarView(Toolbar toolbar) 
        {
            _toolbar = toolbar;
            _viewModel = ServiceLocator.GetInstance().Resolve<NavbarViewModel>();
            
            ToolbarMenu toolbarMenu = new ToolbarMenu()
            {
                text = "File"
            };
            
            toolbarMenu.menu.AppendAction(ConstantValue.LoadNavigation, (a) => _viewModel.OnBrowseNavigation());
            toolbarMenu.menu.AppendAction(ConstantValue.CreateNavigation, _viewModel.OnHandlerDropdownAction);
            
            
            ToolbarButton helpButton = new ToolbarButton(_viewModel.OnOpenHelp)
            {
                text = ConstantValue.Help,
            };
            
            _toolbar.Add(toolbarMenu);
            _toolbar.Add(helpButton);
        }
        
        public Toolbar ContentContainer => _toolbar;
        
    }
}