using System;

namespace Navigator.Data.Configs
{
    // This class should be SINGLETON 
    [Serializable]
    public sealed class TagContainer
    {
        private static TagContainer _instance;
        private static readonly object Lock = new object();
        
        private TagContainer() { }
        
        public static TagContainer GetInstance()
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    _instance ??= new TagContainer();
                }
            }
            return _instance;
        }
    }
}