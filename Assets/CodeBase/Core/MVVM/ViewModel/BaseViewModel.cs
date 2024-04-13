﻿using System;
using Core.MVVM.WindowFsm;

namespace Core.MVVM.ViewModel
{
    public abstract class BaseViewModel : IViewModel
    {
        public event Action InvokedOpen;
        public event Action InvokedClose;

        protected readonly IWindowFsm _windowFsm;
        
        protected virtual Type Window { get; }

        public BaseViewModel(IWindowFsm windowFsm)
        {
            _windowFsm = windowFsm;

            _windowFsm.Opened += HandleOpenedWindow;
            _windowFsm.Closed += HandleClosedWindow;
        }
        
        public abstract void InvokeOpen();

        public abstract void InvokeClose();
        
        protected virtual void HandleOpenedWindow(Type uiWindow)
        {
            if(Window == uiWindow)
                InvokedOpen?.Invoke();
        }

        protected virtual void HandleClosedWindow(Type uiWindow)
        {
            if(Window == uiWindow)
                InvokedClose?.Invoke();
        }
    }
}