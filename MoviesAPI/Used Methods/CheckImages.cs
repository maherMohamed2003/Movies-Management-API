namespace MoviesAPI.Used_Methods
{
    public static class CheckImages
    {
        private static readonly List<string> AllowedExtentions = new List<string> { ".jpg", ".png" };
        private static readonly long maxAllowedSize = 1024 * 1024 * 3;  // 3 MB

        public static bool CkeckSize(IFormFile img )
        { 
            if(img.Length < 0 || img.Length > maxAllowedSize)
                return false;
            else
            {
                return true;
               
            }

        }
        public static bool CheckType(IFormFile img)
        {
            if (AllowedExtentions.Contains(Path.GetExtension(img.FileName).ToLower()))
                return true;
            else
                return false;
        }


    }
}
