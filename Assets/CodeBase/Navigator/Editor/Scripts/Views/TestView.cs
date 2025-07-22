using UnityEngine.UIElements;

namespace Navigator.Editor.Views
{
    public class TestView : VisualElement
    {
        public TestView()
        {
            Add(new Label("test window"));
        }
    }
}