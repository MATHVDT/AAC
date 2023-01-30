using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum TypeNode { Obstacle, Libre }

    struct NodeCara
    { 
        public double Cout_g; // le cout pour aller du point de départ au nœud considéré
        public double Cout_h; // le cout pour aller du nœud considéré au point de destination
        public double Cout_f; // somme des précédents, mais mémorisé pour ne pas le recalculer à chaque fois

        public Node Parent;
    }

    internal class Node
    {
        // Id du noeud pour l'identifier plus facilement
        public int Id;

        // Coordonnées transform
        public double x, y;

        public TypeNode typeNode;

        // Liste voisin
        private List<Node> _voisin;

        private NodeCara _nodeCara;

        public double Cout_g { get => _nodeCara.Cout_g; }
        public double Cout_h { get => _nodeCara.Cout_h;}
        public double Cout_f { get => _nodeCara.Cout_f;}

        public Node Parent { get => _nodeCara.Parent; }



        /// <summary>
        /// Donne la liste des voisins.
        /// </summary>
        /// <param name="lvlDetail">Inutile pour l'instance.</param>
        /// <returns></returns>
        public List<Node> GetNodesVoisins(int lvlDetail = 0)
        {
            return _voisin;
        }


        public void SetNodeCara(NodeCara cara)
        {
            _nodeCara = cara;
        }


    }
}
