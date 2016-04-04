namespace WebImageDownloader
{
    public static class StringExtension
    {
        public static string LastElementFromSplit( this string value, char splitter )
        {
            var elements = value.Split( splitter );

            return elements[elements.Length - 1];
        }
    }
}