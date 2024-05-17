using System;

namespace casestudy.myexceptions
{
    public class ArtWorkNotFoundException : Exception
    {
        public ArtWorkNotFoundException() : base("Artwork not found.")
        {
        }

        public ArtWorkNotFoundException(string message) : base(message)
        {
        }

        public ArtWorkNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
