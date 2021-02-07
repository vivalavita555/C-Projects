namespace Delegates
{
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path, PhotoFilterHandler filterHandler )
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            //var filters = new PhotoFilters();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            photo.Save();
        }
    }       
}

/* Now, using delegates, it is up to the client what filters to use and the code no longer needs to be
 * recompiled or redelpoyed since it's no longer our responsibility thus making our code more extensible! */