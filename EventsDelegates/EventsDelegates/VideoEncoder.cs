using System;
using System.Threading;

namespace EventsDelegates
{
    public class VideoEncoder
    {
        // 1- Define a delegate
        // 2- Define an event based on that delegate
        // 3- Raise the event

        public delegate void VideoEncodedEventHandler(object source, EventArgs args);// 1 //It is conventional to append the delegate name with EventHandler
        public event VideoEncodedEventHandler VideoEncoded; // 2

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(); // 3
        }

        protected virtual void OnVideoEncoded() //Another convention is that event publisher methods should be protected virtual and void & should also have the prefix 'On'
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, EventArgs.Empty)
            }
        }
}