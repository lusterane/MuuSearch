﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// provides model serialization for both album and artist jsons

namespace Task2_v5_0_0.Models {
    public class ExternalUrls {
        public string spotify { get; set; }
    }

    public class Followers {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class Image {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Item {
        public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        public List<string> genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Artists {
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }

    public class RootObject {
        public Artists artists { get; set; }
    }

    public class AlbumArtist {
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }


    public class AlbumImage {
        public int height { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class AlbumItem {
        public string album_group { get; set; }
        public string album_type { get; set; }
        public List<AlbumArtist> artists { get; set; }
        public List<string> available_markets { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<AlbumImage> images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class RootAlbum {
        public string href { get; set; }
        public List<AlbumItem> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }
}
