using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Würfelverschlüsselung
{
    internal class Crypt
    {
        public Crypt() { }

         public string Decrypt(string klartext)
        {
            var fulltext = klartext.Replace(" ", "").ToUpper();
            fulltext.ToUpper();

            Console.WriteLine("Wie lang soll der Zeichenblock sein");

            var is_int = int.TryParse(Console.ReadLine(), out int length);
            
            if (is_int)
            {
                var height = fulltext.Length / length;
                int p = 0;
                char[,] charArr = new char[height, length];
                for (int i = 0; i < height; i++)
                {

                    for (int l = 0; l < length; l++)
                    {
                        charArr[i, l] = fulltext[l + p];
                        //Console.Write(charArr[i, l]);
                    }
                    //Console.WriteLine();
                    p = p + length;
                }
                //for(int i = 0; i < height; i++)
                //{

                //    for (int l = 0; l < length; l++)
                //    {
                //        norm[i, l] = charArr[l, i];


                //    }
                char[,] crypt = new char[length, height];
                string cyphertext="";
                for (int i = 0; i < length; i++)
                {
                    for (int l = 0; l < height; l++)
                    {
                        crypt[i, l] = charArr[l, i];
                        cyphertext=cyphertext+crypt[i,l];
                    }
                }
                Console.WriteLine("Die Verschlüsselung lautet");
                Console.WriteLine(cyphertext);
                return cyphertext;
            }
            else
            {
                Console.WriteLine("Falsche Eingabe");
                return klartext;
            }
           
        }
        public  string entcrypt(string crypttext)
        {
            crypttext.ToUpper();

            Console.WriteLine("Wie lang soll der Zeichenblock sein");

            var is_int = int.TryParse(Console.ReadLine(), out int length);
            
            if (is_int)
            {
                var height = crypttext.Length / length;
                int p = 0;
                char[,] charArr = new char[length, height];
                for (int i = 0; i < length; i++)
                {

                    for (int l = 0; l < height; l++)
                    {
                        charArr[i, l] = crypttext[l+p];
                        //Console.Write(charArr[i, l]);
                    }
                    //Console.WriteLine();
                    p = p + height;
                }

                char[,] norm = new char[height, length];
                string text="";
                for (int i = 0; i < height; i++)
                {

                    for (int l = 0; l < length; l++)
                    {
                        norm[i, l] = charArr[l, i];
                        text = text + norm[i, l];
                        
                        
                    }
            
                }
                Console.WriteLine("Der Text Lautet");
                Console.WriteLine(text);
                return text;
                
                
            }
            else
            {
                Console.WriteLine("Ein fehler ist aufgetreten bitte versuchen sie es nocheinmal");
                return crypttext;
            }
        }
    }
}
