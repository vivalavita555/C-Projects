namespace EventsDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService(); //subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //+= to register the handler for that event
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;
            
            videoEncoder.Encode(video);
        }
    }
}
