using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TypeNode { Obstacle = 0, Libre = 1 }

    internal class Node
    {
        // Id du noeud pour l'identifier plus facilement
        public int Id;

        // Coordonnées transform
        public double x, y;

        public TypeNode typeNode;

        // Liste voisin
        private List<Node> _voisins;

        public double Cout_g;
        public double Cout_h;
        public double Cout_f;

        public Node? Parent;

        public Color ColorCase;

        public Node(int id, double x, double y, TypeNode typeNode)
        {
            Id = id;
            this.x = x;
            this.y = y;
            Cout_g = Cout_h = Cout_f = 0;
            Parent = null;
            this.typeNode = typeNode;
            _voisins = new List<Node>();

            if (typeNode == TypeNode.Obstacle)
            {
                ColorCase = Color.Black;
            }
            else
            {
                ColorCase = Color.White;
            }
        }

        public void AddVoisin(Node voisin)
        {
            _voisins.Add(voisin);
        }

        /// <summary>
        /// Donne la liste des voisins.
        /// </summary>
        /// <param name="lvlDetail">Inutile pour l'instance.</param>
        /// <returns></returns>
        public List<Node> GetNodesVoisins(int lvlDetail = 0)
        {
            return _voisins;


        }
    }
}
