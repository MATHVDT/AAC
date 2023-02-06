namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //string fichier = @"C:\Users\ma_th\Documents\GitHub\Algorithmique_avanc-e_et_complexe\ConsoleApp1\Grille.txt";
            string fichier = @"C:\Users\mavilledie4\source\repos\Algorithmique_avancée_et_complexe\ConsoleApp1\Grille.txt";

            //string pathBase = @"C:\Users\ma_th\Desktop\tmp\";
            string pathBase = @"C:\Users\mavilledie4\Desktop\tmp\";

            var grapheBis = CreationGraphe.LectureFichier(fichier);
            var astarBis = new Astar();

            var nodeInitial = grapheBis[0, 0];
            var nodeFinal = grapheBis[9, 9];

            Console.WriteLine($"depart {nodeInitial.Id} -> arrive {nodeFinal.Id}");

            var chemin = astarBis.process(nodeInitial, nodeFinal, grapheBis, true, pathBase);

            foreach (var n in chemin)
            {
                Console.WriteLine(n.Id + " ");
            }
        }
    }
}