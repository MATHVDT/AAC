using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AffichageGraphe
    {

        public static void SaveImage(Node[,] graphe, SortedSet<Node> openList, SortedSet<Node> closedList, int nodeSize, string filePath)
        {
            Bitmap bmp = new Bitmap(width: graphe.GetLength(0) * nodeSize, height: graphe.GetLength(1) * nodeSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Remplir la grille de carrés
                for (int i = 0; i < graphe.GetLength(0); i++)
                {
                    for (int j = 0; j < graphe.GetLength(1); j++)
                    {
                        Brush brush;
                        if (graphe[i, j].typeNode == (int)TypeNode.Obstacle)
                        {
                            brush = Brushes.Black;
                        }
                        else
                        {
                            brush = Brushes.White;
                        }
                        g.FillRectangle(brush, i * nodeSize, j * nodeSize, nodeSize, nodeSize);
                    }
                }

                // Peindre les éléments de la liste ouverte en rouge
                foreach (Node node in openList)
                {
                    g.FillRectangle(Brushes.Red, (int)node.x * nodeSize, (int)node.y * nodeSize, nodeSize, nodeSize);
                }

                // Peindre les éléments de la liste fermée en vert
                foreach (Node node in closedList)
                {
                    g.FillRectangle(Brushes.Green, (int)node.x * nodeSize, (int)node.y * nodeSize, nodeSize, nodeSize);
                }


                for (int i = 0; i < graphe.GetLength(0); i++)
                {
                    for (int j = 0; j < graphe.GetLength(1); j++)
                    {
                        Brush brush;
                        if (graphe[i, j].typeNode == (int)TypeNode.Obstacle)
                        {
                            brush = Brushes.Black;
                            g.FillRectangle(brush, i * nodeSize, j * nodeSize, nodeSize, nodeSize);
                        }
                    }
                }
            }

            // Enregistrer l'image
            bmp.Save(filePath, ImageFormat.Png);
        }

        public static void SaveImage(NodeBis[,] graphe, int nodeSize, string filePath)
        {
            Bitmap bmp = new Bitmap(width: graphe.GetLength(0) * nodeSize, height: graphe.GetLength(1) * nodeSize);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Remplir la grille de carrés
                for (int i = 0; i < graphe.GetLength(0); i++)
                {
                    for (int j = 0; j < graphe.GetLength(1); j++)
                    {
                        NodeBis n = graphe[i, j];

                        Brush brush = new SolidBrush(n.ColorCase);

                        g.FillRectangle(brush, i * nodeSize, j * nodeSize, nodeSize, nodeSize);
                    }
                }
            }

            // Enregistrer l'image
            bmp.Save(filePath, ImageFormat.Png);
        }
    }
}
