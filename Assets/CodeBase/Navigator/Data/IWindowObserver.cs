namespace Navigator.Data
{
    public interface IWindowObserver
    {
        void OnOpen();
        void OnClose();
    }
}