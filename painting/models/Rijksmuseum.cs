namespace painting.models
{
    public class Rijksmuseum
    {

        public class PaintingSummary
        {
            public int elapsedMilliseconds { get; set; }
            public int count { get; set; }
            public Artobject[] ArtObjects { get; set; }
        }

        public class Artobject
        {
            public Links links { get; set; }
            public string id { get; set; }
            public string objectNumber { get; set; }
            public string title { get; set; }
            public bool hasImage { get; set; }
            public string principalOrFirstMaker { get; set; }
            public string longTitle { get; set; }
            public bool showImage { get; set; }
            public bool permitDownload { get; set; }
            public Webimage webImage { get; set; }
            public Headerimage headerImage { get; set; }
            public string[] productionPlaces { get; set; }
        }

        public class Links
        {
            public string self { get; set; }
            public string web { get; set; }
        }

        public class Webimage
        {
            public string guid { get; set; }
            public int offsetPercentageX { get; set; }
            public int offsetPercentageY { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string url { get; set; }
        }

        public class Headerimage
        {
            public string guid { get; set; }
            public int offsetPercentageX { get; set; }
            public int offsetPercentageY { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public string url { get; set; }
        }

    }
}
