using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CreationGraphe
    {
        public static Node[,] LectureFichier(string fichier)
        {
            string fileContent = File.ReadAllText(fichier);

            string[] lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            int rowCount = int.Parse(lines[0].Split(' ')[0]);
            int columnCount = int.Parse(lines[0].Split(' ')[1]);

            Node[,] graphe = new Node[rowCount, columnCount];
            Console.WriteLine($"rowCount {rowCount}, columnCout {columnCount}, lines.Length:{lines.Length}");
            TypeNode type;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split('\t');
                for (int j = 0; j < elements.Length; j++)
                {
                    // Récupération du type
                    type = (TypeNode)Enum.ToObject(typeof(TypeNode), int.Parse(elements[j]));
                    Node n = new Node((i - 1) * columnCount + j,
                                    j, i - 1, type);
                    graphe[i - 1, j] = n;
                }
            }

            // Ajout voisin
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {

                    if (i > 0)
                    {
                        if (graphe[i - 1, j].typeNode == TypeNode.Libre)
                        {
                            graphe[i, j].AddVoisin(graphe[i - 1, j]);
                        }
                    }
                    if (i < rowCount - 1)
                    {
                        if (graphe[i + 1, j].typeNode == TypeNode.Libre)
                        {
                            graphe[i, j].AddVoisin(graphe[i + 1, j]);
                        }
                    }
                    if (j > 0)
                    {
                        if (graphe[i, j - 1].typeNode == TypeNode.Libre)
                        {
                            graphe[i, j].AddVoisin(graphe[i, j - 1]);
                        }
                    }
                    if (j < columnCount - 1)
                    {
                        if (graphe[i, j + 1].typeNode == TypeNode.Libre)
                        {
                            graphe[i, j].AddVoisin(graphe[i, j + 1]);
                        }
                    }
                }
            }

            return graphe;
        }
    }
}
