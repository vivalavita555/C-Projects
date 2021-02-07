using System;

namespace EventsDelegates
{
    public class MailService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            Console.WriteLine("MailService: sending an email...");
        }
    }
}
