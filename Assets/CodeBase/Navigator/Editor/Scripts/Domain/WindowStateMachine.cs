using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Navigator.Editor.Domain
{
    public class WindowStateMachine
    {
        private readonly VisualElement _rootContext;

        private readonly Dictionary<string, VisualElement> _windows = new Dictionary<string, VisualElement>();

        public WindowStateMachine(VisualElement rootContext)
        {
            _rootContext = rootContext ?? throw new ArgumentNullException(nameof(rootContext));
        }

        public void RegisterWindow(string key, VisualElement window)
        {
            if(_windows.TryAdd(key, window))
                Debug.Log("Window was registered!");
            else 
                Debug.LogWarning($"Window with key {key} already was registered!");
        }

        public void UnregisterWindow(string key)
        {
            if(_windows.ContainsKey(key))
                _windows.Remove(key); 
            else 
                Debug.LogWarning($"Window with key {key} not registered!");
        }

        public void Open(string key)
        {
            _rootContext.Clear();

            _rootContext.Add(_windows[key]);
        }
    }
}