using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace DICJ_Ipsum
{
    class Affichage
    {
        public Affichage()
        {
            Menu1();
        }
        private void Menu1()
        {
            string choix = "";
            Clear();
            WriteLine("BIENVENUE DANS LE GÉNÉRATEUR DICJ IPSUM!");
            WriteLine("Choisissez une option :");
            WriteLine("1 - Générer aléatoirement des termes informatiques");
            WriteLine("2 - Générer un nombre prédéfini de termes informatiques");
            WriteLine("3 - Générer un texte prédéfini en code ASCII ou en binaire");
            Write("Votre choix : ");
            choix = ReadLine();
            TraiterChoixMenu1(choix);
        }

        private void TraiterChoixMenu1(string choix)
        {
            switch(choix){
                case "1":
                    Option1();
                    break;
                case "2":
                    Option2();
                    break;
                case "3":
                    Option3();
                    break;
                default:
                    Menu1();
                    break;
            }
        }

        private void Option1()
        {
            string resultat = Generateur.Generate();
            Console.WriteLine(resultat);
            AfficherFin(resultat);
        }

        private void Option2()
        {
            string quantiteStr = "";
            string resultat = "";
            int quantite = 0;
            bool valide = false;
            while (!valide)
            {
                Write("Entrez le nombre de termes désiré : ");
                quantiteStr = Console.ReadLine();
                if(int.TryParse(quantiteStr, out quantite))
                {
                    valide = true;
                    resultat = Generateur.Generate(quantite);
                    Console.WriteLine(resultat);
                }
            }
            AfficherFin(resultat);
        }

        private void Option3()
        {
            string choix = "";
            string aTransformer = "";
            string type = "";
            string resultat = "";

            Write("Entrez le texte désiré : ");
            aTransformer = ReadLine();
            WriteLine("En quel type voulez-vous faire générer votre texte?");
            WriteLine("1 - Code ASCII");
            WriteLine("2 - Binaire");
            Write("Votre choix : ");
            choix = ReadLine();
            if(choix == "1")
            {
                type = "ascii";
            }
            else if(choix == "2")
            {
                type = "binaire";
            }
            else
            {
                Option3();
            }
            resultat = Generateur.Generate(type, aTransformer);
            WriteLine(resultat);
            AfficherFin(resultat);
        }

        private void AfficherFin(string resultat)
        {
            string choix = "";
            WriteLine("");
            WriteLine("Appuyez sur M pour revenir au menu.");
            WriteLine("Appuyez sur I pour imprimer le résultat dans un fichier.");
            choix = ReadLine().ToLower();
            if (choix == "m")
            {
                Menu1();
            }
            else if (choix == "i")
            {
                EcrireFichier(resultat);
            }
            else
            {
                WriteLine("Merci d'avoir utilisé ce programme!");
                Thread.Sleep(1500);
                Environment.Exit(0);
            }
        }

        private void EcrireFichier(string resultat)
        {
            string fileName = @"C:\resultat.txt";

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine(resultat);
                }
                WriteLine("Un fichier texte resultat.txt a été créé dans votre disque C:");
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
