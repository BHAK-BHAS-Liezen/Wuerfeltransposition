using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Würfelverschlüsselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Dominik\Documents\Projects\Würfelverschlüsselung\";
            var source = path + @"Text.txt";
            do
            {
                Console.Clear();

                Console.WriteLine("Möchtest du einen Eigenen Text eingeben (N) oder ein Dokument ve/entrschlüsseln (D)");
                var input = Console.ReadLine();
                if (input.ToUpper() == "N")
                {
                    Console.WriteLine("wollen sie den Text ent-(E) oder verschlüsseln (V)");
                    var act = Console.ReadLine();
                    if (act.ToUpper() == "V")
                    {
                        Console.Clear();
                        Console.WriteLine("Bitte geben sie einen Text ein");
                        string new_text = Console.ReadLine();
                        var cypher = new Crypt();
                        cypher.Decrypt(new_text);
                    }
                    if (act.ToUpper() == "E")
                    {
                        Console.Clear();
                        Console.WriteLine("Bitte geben sie den Cyphertext ein");
                        var cyphertext = Console.ReadLine();
                        var decypher = new Crypt();
                        decypher.entcrypt(cyphertext);

                    }
                }
                if (input.ToUpper() == "D")
                {
                    Console.WriteLine("wollen sie den Text ent-(E) oder verschlüsseln (V)");
                    var act = Console.ReadLine();
                    if (act.ToUpper() == "V")
                    {

                        var sr= new StreamReader(source);
                        var normtext= sr.ReadToEnd();
                        sr.Close();
                        var cypher = new Crypt();
                        string cyphertext = cypher.Decrypt(normtext);
                        var sw= new StreamWriter(source);
                        sw.WriteLine(cyphertext);
                        sw.Close();
                    }
                    if (act.ToUpper() == "E")
                    {
                        var sr = new StreamReader(source);
                        var cyphertext = sr.ReadToEnd();
                        sr.Close();
                        var cypher = new Crypt();
                        string klartext = cypher.entcrypt(cyphertext);
                        var sw = new StreamWriter(source);
                        sw.WriteLine(klartext);
                        sw.Close();
                    }
                }
                else
                {
                    Console.WriteLine("Zum beenden drücken Sie (P)");
                }
                } while (Console.ReadKey(true).Key != ConsoleKey.P) ;
            
        }
    }
}
