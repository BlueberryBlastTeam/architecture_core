using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = System.Object;

namespace Navigator.Editor.Domain
{
    public class ServiceLocator : IDisposable
    {
        private static ServiceLocator _instance;
        private static readonly object Lock = new object();

        private readonly List<Object> _services = new List<Object>();
        
        private ServiceLocator() { }

        public static ServiceLocator GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    _instance ??= new ServiceLocator();
                }
            }
            
            return _instance;
        }

        // All instance as Singleton 
        public void Register<TImplementation>()
        where TImplementation : class, new()
        {
            try
            {
                if(_services.Any(x => x.GetType() == typeof(TImplementation)))
                    throw new ArgumentException("Service already registered");
                
                _services.Add(Activator.CreateInstance<TImplementation>());
            }
            catch (ArgumentException e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }
        
        public void Register<TImplementation>(TImplementation instance)
        where TImplementation : class
        {
            try
            {
                if(_services.Any(x => x.GetType() == typeof(TImplementation)))
                    throw new ArgumentException("Service already registered");
                
                _services.Add(instance);
            }
            catch (ArgumentException e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }

        public TImplementation Resolve<TImplementation>()
        where TImplementation : class
        {
            try
            {
                if(_services.Exists(x => x.GetType() == typeof(TImplementation)) == false)
                    throw new ArgumentException("Service not registered");
                
                return _services.Find(x => x.GetType() == typeof(TImplementation)) as TImplementation;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }

        public void Dispose()
        {
            _services.Clear();
        }
    }
}