using System;
using System.Collections.Generic;
using caseStudy.Entity;
using casestudy.dao;


namespace casestudy.main
{


    namespace casestudy.main
    {
        class Program
        {
            static void Main(string[] args)
            {
                IVirtualArtGallery artGalleryService = new VirtualArtGalleryServiceImpl();

                while (true)
                {
                    Console.WriteLine("Virtual Art Gallery Management System");
                    Console.WriteLine("1. Add Artwork");
                    Console.WriteLine("2. Update Artwork");
                    Console.WriteLine("3. Remove Artwork");
                    Console.WriteLine("4. Get Artwork by ID");
                    Console.WriteLine("5. Search Artworks");
                    Console.WriteLine("6. Add Artwork to Favorites");
                    Console.WriteLine("7. Remove Artwork from Favorites");
                    Console.WriteLine("8. Get User's Favorite Artworks");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Artwork ID: ");
                            int addId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Artwork Title: ");
                            string addTitle = Console.ReadLine();
                            Console.Write("Enter Artist Name: ");
                            string addArtist = Console.ReadLine();

                            Artwork newArtwork = new Artwork
                            {
                                ArtworkID = addId,
                                Title = addTitle,

                            };

                            bool isAdded = artGalleryService.AddArtwork(newArtwork);
                            Console.WriteLine(isAdded ? "Artwork added successfully." : "Failed to add artwork.");
                            break;

                        case 2:
                            Console.Write("Enter Artwork ID to Update: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter New Title: ");
                            string updateTitle = Console.ReadLine();
                            Console.Write("Enter New Artist Name: ");
                            string updateArtist = Console.ReadLine();

                            Artwork updatedArtwork = new Artwork
                            {
                                ArtworkID = updateId,
                                Title = updateTitle,

                            };

                            bool isUpdated = artGalleryService.UpdateArtwork(updatedArtwork);
                            Console.WriteLine(isUpdated ? "Artwork updated successfully." : "Failed to update artwork.");
                            break;

                        case 3:
                            Console.Write("Enter Artwork ID to Remove: ");
                            int removeId = Convert.ToInt32(Console.ReadLine());

                            bool isRemoved = artGalleryService.RemoveArtwork(removeId);
                            Console.WriteLine(isRemoved ? "Artwork removed successfully." : "Failed to remove artwork.");
                            break;

                        case 4:
                            Console.Write("Enter Artwork ID to Get Details: ");
                            int getId = Convert.ToInt32(Console.ReadLine());

                            Artwork artwork = artGalleryService.GetArtworkById(getId);
                            if (artwork != null)
                            {
                                Console.WriteLine($"Artwork ID: {artwork.ArtworkID}");
                                Console.WriteLine($"Title: {artwork.Title}");
                                Console.WriteLine($"Artist: {artwork.Artist}");
                            }
                            else
                            {
                                Console.WriteLine("Artwork not found.");
                            }
                            break;

                        case 5:
                            Console.Write("Enter keyword to search artworks: ");
                            string keyword = Console.ReadLine();

                            List<Artwork> artworks = artGalleryService.SearchArtworks(keyword);
                            foreach (var art in artworks)
                            {
                                Console.WriteLine($"Artwork ID: {art.ArtworkID}, Title: {art.Title}, Artist: {art.Artist}");
                            }
                            break;

                        case 6:
                            Console.Write("Enter User ID: ");
                            int userId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Artwork ID to Add to Favorites: ");
                            int favArtId = Convert.ToInt32(Console.ReadLine());

                            bool isAddedToFav = artGalleryService.AddArtworkToFavorite(userId, favArtId);
                            Console.WriteLine(isAddedToFav ? "Artwork added to favorites successfully." : "Failed to add artwork to favorites.");
                            break;

                        case 7:
                            Console.Write("Enter User ID: ");
                            int remUserId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Artwork ID to Remove from Favorites: ");
                            int remArtId = Convert.ToInt32(Console.ReadLine());

                            bool isRemovedFromFav = artGalleryService.RemoveArtworkFromFavorite(remUserId, remArtId);
                            Console.WriteLine(isRemovedFromFav ? "Artwork removed from favorites successfully." : "Failed to remove artwork from favorites.");
                            break;

                        case 8:
                            Console.Write("Enter User ID: ");
                            int favUserId = Convert.ToInt32(Console.ReadLine());

                            List<Artwork> favoriteArtworks = artGalleryService.GetUserFavoriteArtworks(favUserId);
                            foreach (var art in favoriteArtworks)
                            {
                                Console.WriteLine($"Artwork ID: {art.ArtworkID}, Title: {art.Title}, Artist: {art.Artist}");
                            }
                            break;

                        case 9:
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }

}
