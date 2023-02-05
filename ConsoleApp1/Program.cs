namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string fichier = @"C:\Users\ma_th\Documents\GitHub\Algorithmique_avanc-e_et_complexe\ConsoleApp1\Grille.txt";


            string pathBase = @"C:\Users\ma_th\Desktop\tmp\";


            //var graphe = CreationGraphe.LectureFichier(fichier);
            //var astar = new Astar();

            //var nodeInitial = graphe[0, 0];
            //var nodeFinal = graphe[1, 3];

            //Console.WriteLine($"depart {nodeInitial.Id} -> arrive {nodeFinal.Id}");

            //astar.process(nodeInitial, nodeFinal, graphe, true, pathBase);


            var grapheBis = CreationGraphe.LectureFichierBis(fichier);

            var astarBis = new AstarBis();

            var nodeInitial = grapheBis[0, 0];
            var nodeFinal = grapheBis[1, 3];

            Console.WriteLine($"depart {nodeInitial.Id} -> arrive {nodeFinal.Id}");

            var chemin = astarBis.process(nodeInitial, nodeFinal, grapheBis, true, pathBase);

            foreach (var n in chemin)
            {
                Console.WriteLine(n.Id + " ");
            }




        }
    }
}