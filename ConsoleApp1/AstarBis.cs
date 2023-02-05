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
    internal class AstarBis
    {
        private static readonly Color PathColor = Color.Blue;
        private static readonly Color OpenColor = Color.Yellow;
        private static readonly Color ClosedColor = Color.Red;

        public List<NodeBis>? process(NodeBis nodeInitial, NodeBis nodeFinal,
                                      NodeBis[,] graphe, bool printImage = false, string basePath = @"C:\Users\ma_th\Desktop\")
        {
            var toSearch = new List<NodeBis>() { nodeInitial }; // Noeud à chercher
            var processed = new List<NodeBis>(); // Noeud deja traite

            int cpt = 0;

            while (toSearch.Any())
            {
                // Recuperation du meilleur noeud
                var current = toSearch[0];
                foreach (var t in toSearch)
                    if (t.Cout_f < current.Cout_f || t.Cout_f == current.Cout_f && t.Cout_h < current.Cout_h) current = t;

                processed.Add(current);
                toSearch.Remove(current);

                current.ColorCase = ClosedColor;

                if (current == nodeFinal)
                { // Arrive a la fin
                    var currentNode = nodeFinal;
                    var chemin = new List<NodeBis>();
                    currentNode.ColorCase = PathColor;

                    while (currentNode != nodeInitial)
                    {
                        chemin.Add(currentNode);
                        currentNode = currentNode.Parent;
                        currentNode.ColorCase = PathColor;

                        if (currentNode == null)
                            Console.WriteLine("Erreur dans les parents.");
                    }

                    if (printImage)
                    {
                        AffichageGraphe.SaveImage(graphe, 50, basePath + "astar" + cpt + ".png");
                        ++cpt;
                    }
                    chemin.Reverse();
                    return chemin;
                }

                foreach (var neighbor in current.GetNodesVoisins().Where(t => t.typeNode != TypeNode.Obstacle && !processed.Contains(t)))
                {
                    var inSearch = toSearch.Contains(neighbor);

                    var costToNeighbor = current.Cout_g + Distance.Euclidienne(current, neighbor);

                    if (!inSearch || costToNeighbor < neighbor.Cout_g)
                    {
                        neighbor.Cout_g = costToNeighbor;
                        neighbor.Parent = current;

                        if (!inSearch)
                        {
                            neighbor.Cout_h = Distance.Euclidienne(neighbor, nodeFinal);
                            toSearch.Add(neighbor);
                            neighbor.ColorCase = OpenColor;
                        }
                    }
                }

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
