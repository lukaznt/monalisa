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


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Gal.Pieces[i].ToString());
            }

            Console.WriteLine("\n---------Prices-----------------");
            Gal.Pieces.Sort();

            //foreach (ArtPiece Piece in Gal.Pieces)
           //    Console.WriteLine(Gal.Pieces.ToString());

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Gal.Pieces[i].ToString());
            }
        }
    }

    class ArtPiece : IComparable<ArtPiece>
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
                    return ("Piece: " + _Name + " - Type: Painting - Price: " + _Price);
                case Category.SCULPTURE:
                    return ("Piece: " + _Name + " - Type: Sculpture - Price: " + _Price);
                default:
                    return ("Piece: " + _Name + " - Type: Drawing - Price: " + _Price);
            }
        }

        public int CompareTo(ArtPiece p)
        {
            return this._Price.CompareTo(p._Price);
        }


    }

    class ArtGallery
    {
        public List<ArtPiece> Pieces = new List<ArtPiece>();

        

        public void Initialize()
        {

            Pieces.Add(new ArtPiece("Monalisa", Category.PAINTING, 2000));
            Pieces.Add(new ArtPiece("Davi", Category.SCULPTURE, 1000));
            Pieces.Add(new ArtPiece("Sun", Category.DRAWING, 3000));

        }
    }

    enum Category
    {
        PAINTING,
        DRAWING,
        SCULPTURE
    }

    
}
