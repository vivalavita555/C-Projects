using System;

namespace EventsDelegates
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            Console.WriteLine("MessageService: sending a text...");
        }
    }
}
