using System;
using System.Collections.Generic;
using Core.MVVM.View;
using Core.MVVM.Windows;

namespace Sample.MVVM.WindowFsm
{
    public class WindowFsm : IWindowFsm, IWindowResolve
    {
        public int fsmNumber;

        public event Action<Type> Opened;
        public event Action<Type> Closed;

        private readonly Dictionary<Type, IWindow> _windows;
        private readonly Stack<IWindow> _windowHistory;

        private IWindow _currentWindow;
        public Type CurrentWindow { get; }

        public bool IsWindowOpened => _currentWindow != null;

        protected WindowFsm()
        {
            _windows = new Dictionary<Type, IWindow>();
            _windowHistory = new Stack<IWindow>();
        }

        public void Set<TView>() where TView : class, IView
        {
            if (_windows.ContainsKey(typeof(TView))) return;
            var window = new Window(typeof(TView));
            window.Opened += OnOpened;
            window.Closed += OnClosed;
            _windows.Add(typeof(TView), window);
        }

        public void CleanUp()
        {
            _windows.Clear();
        }

        public void OpenWindow(Type window, bool inHistory)
        {
            
        }

        public void OpenWindow(Type windowType)
        {
            if (_currentWindow == _windows[windowType])
                return;

            _currentWindow?.Close();
            _windowHistory.Push(_windows[windowType]);
            _currentWindow = _windowHistory.Peek();
            _currentWindow?.Open();
        }

        public void OpenOneWindow(Type window) => _windows[window]?.Open();

        public void CloseWindow(Type type)
        {
            _windows.TryGetValue(type, out var window);
            window?.Close();
        }

        public void CloseWindow()
        {
            
        }

        public void CloseCurrentWindow()
        {
            if (_currentWindow == null)
                return;

            _windowHistory.Pop().Close();
            _windowHistory.TryPeek(out _currentWindow);
            _currentWindow?.Open();
        }

        public void ClearHistory()
        {
            _windowHistory.Clear();
            if (_currentWindow != null)
                _windowHistory.Push(_currentWindow);
        }

        private void OnOpened(Type type) => Opened?.Invoke(type);
        private void OnClosed(Type type) => Closed?.Invoke(type);
    }
}