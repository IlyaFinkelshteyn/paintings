using painting.models;

namespace painting.ViewModel
{
    public class PaintingViewModel
    {
        

        public PaintingViewModel(
            string name
            , string title
            , string description
            , int year
            , string collection
            , string[]  colors
            , Image.Tile[] image
           )
        {
            Title = title;
            Description = description;
            Year = year;
            Collection = collection;
            Colors = colors;
            Image = image;
            Name = name; 
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
        public string Collection { get; private set; }
        public string Name;
        public string[] Colors;
        public Image.Tile[] Image;  
         
    }

}
