using caseStudy.Entity;
using caseStudyArt.Entity;
using System.Collections.Generic;

namespace casestudy.dao
{
    public interface IVirtualArtGallery
    {
        // Artwork Management
        bool AddArtwork(Artwork artwork);
        bool UpdateArtwork(Artwork artwork);
        bool RemoveArtwork(int artworkID);
        Artwork GetArtworkById(int artworkID);
        List<Artwork> SearchArtworks(string keyword);

        // User Favorites
        bool AddArtworkToFavorite(int userId, int artworkId);
        bool RemoveArtworkFromFavorite(int userId, int artworkId);
        List<Artwork> GetUserFavoriteArtworks(int userId);
        bool RemoveArtwork(object id1);
    }
}


