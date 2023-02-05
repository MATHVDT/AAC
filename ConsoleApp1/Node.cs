using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TypeNode { Obstacle = 0, Libre = 1 }

    struct NodeCara
    {
        public double Cout_g; // le cout pour aller du point de départ au nœud considéré
        public double Cout_h; // le cout pour aller du nœud considéré au point de destination
        public double Cout_f; // somme des précédents, mais mémorisé pour ne pas le recalculer à chaque fois

        public Node Parent;
    }
    internal class NodeEqualityById : IEqualityComparer<Node>
    {
        public bool Equals(Node? x, Node? y) => x?.Id == y?.Id;

        public int GetHashCode([DisallowNull] Node obj)
        {
            return obj.Id;
        }
    }


    internal class Node
    {
        // Id du noeud pour l'identifier plus facilement
        public int Id;

        // Coordonnées transform
        public double x, y;

        public TypeNode typeNode;

        // Liste voisin
        private List<Node> _voisins;

        private NodeCara _nodeCara;

        public double Cout_g { get => _nodeCara.Cout_g; }
        public double Cout_h { get => _nodeCara.Cout_h; }
        public double Cout_f { get => _nodeCara.Cout_f; }

        public Node Parent { get => _nodeCara.Parent; }

        public Node(int id, double x, double y, TypeNode typeNode)
        {
            Id = id;
            this.x = x;
            this.y = y;
            this.typeNode = typeNode;
            _voisins = new List<Node>();
            _nodeCara = new NodeCara()
            {
                Cout_f = 0,
                Cout_g = 0,
                Cout_h = 0
            };
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


        public void SetNodeCara(NodeCara cara)
        {
            _nodeCara = cara;
        }


    }
}
