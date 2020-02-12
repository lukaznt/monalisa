using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace monalisa
{
    class Program
    {
        static void Main(string[] args)
        {
            ArtGallery Gal = new ArtGallery();

            Gal.Initialize();

            
            Console.WriteLine(Gal.Pieces[1].ToString());
        }
    }

    class ArtPiece
    {
        private string _Name;  // final
        private Category _Type;  // final
        private int _Price;

        public ArtPiece(string name, Category type, int price)
        {
            this._Name = name;
            this._Type = type;
            this._Price = price;
        }

        public override string ToString()
        {

            switch (_Type)
            {
                case Category.PAINTING:
                    return ("Piece: " + _Name + "- Type: Painting - Price: " + _Price);
                case Category.SCULPTURE:
                    return ("Piece: " + _Name + "- Type: Sculpture - Price: " + _Price);
                default:
                    return ("Piece: " + _Name + "- Type: Drawing - Price: " + _Price);
            }

        }

    }

    class ArtGallery
    {
        public List<ArtPiece> Pieces = new List<ArtPiece>();

        

        public void Initialize()
        {

            Pieces.Add(new ArtPiece("Monalisa", Category.PAINTING, 2000));
            Pieces.Add(new ArtPiece("Davi", Category.SCULPTURE, 2000));
            Pieces.Add(new ArtPiece("Sun", Category.DRAWING, 2000));

        }
    }

    enum Category
    {
        PAINTING,
        DRAWING,
        SCULPTURE
    }

    
}
