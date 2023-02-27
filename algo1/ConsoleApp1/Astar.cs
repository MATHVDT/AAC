using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Astar
    {
        private static readonly Color PathColor = Color.Blue;
        private static readonly Color OpenColor = Color.Yellow;
        private static readonly Color ClosedColor = Color.Red;

        /// <summary>
        /// Calcule le chemin via l'algorithme A star.
        /// </summary>
        /// <param name="nodeInitial">Noeud de départ.</param>
        /// <param name="nodeFinal">Noeud d'arrivé.</param>
        /// <param name="Distance">Distance choisie.</param>
        /// <param name="graphe">Matrice contenant tous les noeuds.</param>
        /// <param name="printImage">Bool indiquant si on doit print le gif du parcours.</param>
        /// <param name="basePath">Chemin ou le gif sera enregistré.</param>
        /// <returns>Liste des noeuds du chemin.</returns>
        public List<Node>? process(Node nodeInitial, Node nodeFinal, Func<Node, Node, double> Distance,
                                      Node[,] graphe, bool printImage = false, string basePath = @"C:\Users\ma_th\Desktop\")
        {
            var toSearch = new List<Node>() { nodeInitial }; // Noeud à chercher
            var processed = new List<Node>(); // Noeud deja traite

            int cpt = 0; // Compteur pour nommer les images

            // Tant qu'il y a des noeuds potentiel
            while (toSearch.Any())
            {
                // Recuperation du meilleur noeud
                var current = toSearch[0];
                foreach (var t in toSearch)
                    if (t.Cout_f < current.Cout_f || (t.Cout_f == current.Cout_f && t.Cout_h < current.Cout_h)) current = t;


                toSearch.Remove(current);
                processed.Add(current);
                current.ColorCase = ClosedColor;

                // Arrive a la fin
                if (current == nodeFinal)
                { 
                    var currentNode = nodeFinal; // Recuperer le noeud de fin
                    var chemin = new List<Node>(); // Cree la liste des noeuds
                    currentNode.ColorCase = PathColor;

                    // Remonte jusqu'au noeud inital avec les parents
                    while (currentNode != nodeInitial)
                    {
                        chemin.Add(currentNode);
                        currentNode = currentNode.Parent;
                        currentNode.ColorCase = PathColor;

                        if (currentNode == null)
                            Console.WriteLine("Erreur dans les parents.");
                    }

                    if (printImage)
                    { // Creer l'animation gif
                        AffichageGraphe.SaveImage(graphe, 50, basePath + "astar" + cpt + ".png");
                        AffichageGraphe.ImageToGif(basePath);
                        ++cpt;
                    }
                    chemin.Reverse(); // Remet le chemin dans le bon sens
                    return chemin;
                }

                // Pour chaque voisin du noeud courant, 
                // qui n'est pas un obstacle
                // qui n'est pas deja dans les noeuds traites
                foreach (var neighbor in current.GetNodesVoisins().Where(t => t.typeNode != TypeNode.Obstacle && !processed.Contains(t)))
                {
                    var inSearch = toSearch.Contains(neighbor); 

                    // Calcul de son nouveau cout
                    var costToNeighbor = current.Cout_g + Distance(current, neighbor);

                    // Pas dans la liste des noeuds a chercher (et pas dans la liste des noeuds traite => jamais vue)
                    // Meilleur que le cout precedent calcule
                    if (!inSearch || costToNeighbor < neighbor.Cout_g)
                    { 
                        neighbor.Cout_g = costToNeighbor;
                        neighbor.Parent = current;

                        if (!inSearch) // Noeud jamais vue
                        {
                            neighbor.Cout_h = Distance(neighbor, nodeFinal);
                            toSearch.Add(neighbor); // Ajout dans la liste a traiter
                            neighbor.ColorCase = OpenColor;
                        }

                        neighbor.Cout_f = neighbor.Cout_g + neighbor.Cout_h;
                    }
                }
                // Print un image du graphe apres l'iteration
                if (printImage)
                {
                    AffichageGraphe.SaveImage(graphe, 50, basePath + "astar" + cpt + ".png");
                    ++cpt;
                }
            }
            return null;
        }


    }
}
