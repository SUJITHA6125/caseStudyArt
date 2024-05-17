using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caseStudy.Entity
{


    public class Gallery
    {
        public int GalleryID { get; private set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Curator { get; set; }
        // Navigation property
        public Artist CuratorArtist { get; set; }
        public string OpeningHours { get; set; }

        // Constructors
        public Gallery() { }
        public Gallery(int galleryID, string name, string website, string description, string location, int curator, string openingHours)
        {
            GalleryID = galleryID;
            Name = name;
            Website = website;
            Description = description;
            Location = location;
            Curator = curator;
            OpeningHours = openingHours;
        }
    }
}


