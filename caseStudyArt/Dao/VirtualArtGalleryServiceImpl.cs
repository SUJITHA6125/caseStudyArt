using caseStudy.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using casestudy.util;
using caseStudyArt.Entity;
using caseStudyArt.Util;

namespace casestudy.dao
{
    public class VirtualArtGalleryServiceImpl : IVirtualArtGallery
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        public VirtualArtGalleryServiceImpl()
        {
            conn = new SqlConnection("server=DESKTOP-CN4H436;database=VirtualartGallery;trusted_connection=true;");
        }
        public string connectionString = PropertyUtil.GetPropertyString();


        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool AddArtwork(Artwork artwork)
        {
            using (SqlConnection connection = conn)
            {
                string query = "INSERT INTO Artwork (ArtworkID, Title, Artist) VALUES (@ArtworkID, @Title, @Artist)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Artist", artwork.Artist);

                connection.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool UpdateArtwork(Artwork artwork)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "UPDATE Artwork SET Title = @Title, Artist = @Artist WHERE ArtworkID = @ArtworkID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ArtworkID", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Artist", artwork.Artist);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RemoveArtwork(int artworkID)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM Artwork WHERE ArtworkID = @ArtworkID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public Artwork GetArtworkById(int artworkID)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Artwork WHERE ArtworkID = @ArtworkID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Artwork
                    {
                        ArtworkID = reader.GetInt32(0),
                        Title = reader.GetString(1),

                    };
                }
                return null;
            }
        }

        public List<Artwork> SearchArtworks(string keyword)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT * FROM Artwork WHERE Title LIKE @Keyword OR Artist LIKE @Keyword";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Artwork> artworks = new List<Artwork>();
                while (reader.Read())
                {
                    artworks.Add(new Artwork
                    {
                        ArtworkID = reader.GetInt32(0),
                        Title = reader.GetString(1),

                    });
                }
                return artworks;
            }
        }

        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "INSERT INTO UserFavorites (UserID, ArtworkID) VALUES (@UserID, @ArtworkID)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "DELETE FROM UserFavorites WHERE UserID = @UserID AND ArtworkID = @ArtworkID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@ArtworkID", artworkId);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Artwork> GetUserFavoriteArtworks(int userId)
        {
            using (SqlConnection conn = GetConnection())
            {
                string query = "SELECT a.ArtworkID, a.Title, a.Artist FROM Artwork a JOIN UserFavorites uf ON a.ArtworkID = uf.ArtworkID WHERE uf.UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                List<Artwork> artworks = new List<Artwork>();
                while (reader.Read())
                {
                    artworks.Add(new Artwork
                    {
                        ArtworkID = reader.GetInt32(0),
                        Title = reader.GetString(1),

                    });
                }
                return artworks;
            }
        }

        public bool RemoveArtwork(object id1)
        {
            throw new NotImplementedException();
        }
    }
}

