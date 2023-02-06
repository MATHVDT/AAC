namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Indiquer ici le chemin du fichier Grille.txt contenu dans la solution
            //string fichier = @"C:\Users\ma_th\Documents\GitHub\Algorithmique_avanc-e_et_complexe\ConsoleApp1\Grille.txt";
            string fichier = @"C:\Users\mavilledie4\source\repos\Algorithmique_avancée_et_complexe\ConsoleApp1\Grille.txt";

            // Indiquer ici le chemin de sortie de l'animation
            //string pathBase = @"C:\Users\ma_th\Desktop\tmp\";
            string pathBase = @"C:\Users\mavilledie4\Desktop\tmp\";

            var grapheBis = CreationGraphe.LectureFichier(fichier);
            var astarBis = new Astar();

            var nodeInitial = grapheBis[0, 0];
            var nodeFinal = grapheBis[6, 10];

            Console.WriteLine($"depart {nodeInitial.Id} -> arrive {nodeFinal.Id}");

            var chemin = astarBis.process(nodeInitial, nodeFinal, Distance.Tchebychev, grapheBis, true, pathBase);

            Console.WriteLine("Le chemin passe par les noeuds :");
            foreach (var n in chemin)
            {
                Console.Write(n.Id + " ");
            }
        }
    }
}