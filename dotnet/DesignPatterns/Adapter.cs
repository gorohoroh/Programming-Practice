namespace DesignPatterns
{
    interface ISocket
    {
        void Charge();
    }

    class GermanSocket : ISocket
    {
        public void Charge() { }
    }

    class BritishSocket : ISocket
    {
        public void Charge() { }
    }

    class Laptop
    {
        public void Charge(ISocket socket) { }
    }
    
    class USSocket
    {
        public void Magic() { }
    }

    class USSocketAdapter : ISocket
    {
        private USSocket AmericanSocket { get; set; }
        public USSocketAdapter(USSocket socket) => AmericanSocket = socket;
        public void Charge() => AmericanSocket.Magic();
    }
}