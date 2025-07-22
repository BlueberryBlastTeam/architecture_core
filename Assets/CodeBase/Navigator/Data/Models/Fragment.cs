using Unity.Plastic.Newtonsoft.Json.Serialization;

namespace Navigator.Data.Models
{
    public class Fragment
    {
        public readonly int ID;

        public Fragment(int id)
        {
            ID = id;
        }

        public event Action OpeningEvent;
        public event Action ClosingEvent;
        
        
    }
}