using Xamarin.Essentials;

namespace People
{
    // This class contains the method which gets the local filepath for storing the SQLite database.
    // It gets the correct path for both Android and iOS.
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);
        }
    }
}
