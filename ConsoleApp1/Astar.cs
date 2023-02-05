using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Astar
    {
        SortedSet<Node> _openList = new SortedSet<Node>(Comparer<Node>.Create((x, y) =>
        { // trie par ordre décroissant
            return y.Cout_f.CompareTo(x.Cout_f);
        }));

        SortedSet<Node> _closeList = new SortedSet<Node>(Comparer<Node>.Create((x, y) =>
        { // trie par ordre décroissant
            return y.Cout_f.CompareTo(x.Cout_f);
        }));


        /// <summary>
        /// Insertion d'un nœud dans la liste ouverte si besoin est. 
        /// Il vérifie si un nœud est présent ou non dans la liste fermée et dans la liste ouverte, 
        /// et il met à jour la liste ouverte si le nouveau nœud s'avère meilleur que celui déjà présent. 
        /// </summary>
        /// <param name="nodeBase"></param>
        /// <param name="nodeFinal">Noeud finale de la recherche.</param>
        void ajouter_cases_adjacentes(Node nodeBase, Node nodeFinal)
        {
            NodeCara nodeCara = new NodeCara();

            var listVoisins = nodeBase.GetNodesVoisins();

            foreach (var nodeVoisin in listVoisins)
            {
                // Test si le noeud voisin est bien libre (ie possible de passer à travers)
                if (nodeVoisin.typeNode == TypeNode.Obstacle) { continue; }

                // le noeud n'est pas déjà présent dans la liste fermée 
                if (!_closeList.Contains(nodeVoisin, new NodeEqualityById()))
                {
                    // calcul du cout G du noeud en cours d'étude : cout du parent + distance jusqu'au parent 
                    nodeCara.Cout_g = nodeBase.Cout_g + Distance.Euclidienne(nodeVoisin, nodeBase);

                    // calcul du cout H du noeud à la destination
                    nodeCara.Cout_h = Distance.Euclidienne(nodeVoisin, nodeFinal);
                    nodeCara.Cout_f = nodeCara.Cout_g + nodeCara.Cout_f;
                    nodeCara.Parent = nodeBase;

                    if (_openList.Contains(nodeVoisin, new NodeEqualityById()))
                    {
                        // le noeud est déjà présent dans la liste ouverte, il faut comparer les couts 
                        if (nodeCara.Cout_f < nodeVoisin.Cout_f)
                        {
                            // si le nouveau chemin est meilleur, on met à jour 
                            nodeVoisin.SetNodeCara(nodeCara);
                            //_openList.Add(nodeVoisin); // Deja dans la liste normalement
                        }
                        // le noeud courant a un moins bon chemin, on ne change rien 
                    }
                    else
                    {
                        // le noeud n'est pas présent dans la liste ouverte, on l'y ajoute
                        nodeVoisin.SetNodeCara(nodeCara);
                        _openList.Add(nodeVoisin);
                    }
                }
            }
        }

        /// <summary>
        /// Ajout d'un noeud à la liste fermée et doit donc le retirer de la liste ouverte.
        /// </summary>
        /// <param name="node">Noeud à ajouter.</param>
        public void ajouter_liste_fermee(Node node)
        {
            _closeList.Add(node);

            // il faut le supprimer de la liste ouverte, ce n'est plus une solution explorable 
            if (!_openList.Remove(node))
                Console.WriteLine("Erreur, le noeud n'apparaît pas dans la liste ouverte, impossible à supprimer");
        }

        /// <summary>
        /// Retrouve le chemin dans le bon ordre. Parcours du noeud final au noeud initial.
        /// </summary>
        /// <param name="nodeInitial"></param>
        /// <param name="nodeFinal"></param>
        /// <returns>Liste contenant les différents noeuds du chemin dans le bon ordre.</returns>
        public List<Node> retrouver_chemin(Node nodeInitial, Node nodeFinal)
        {
            // l'arrivée est le dernier élément de la liste fermée
            Node tmpNode = nodeFinal;
            List<Node> chemin = new List<Node>();

            chemin.Insert(0, tmpNode);

            // Remonter la liste des noeuds pour former le chemin
            while (tmpNode != nodeInitial)
            {
                tmpNode = tmpNode.Parent;
                chemin.Insert(0, tmpNode);
            }

            return chemin;
        }


        public void process(Node nodeInitial, Node nodeFinal,
            Node[,] graphe, bool printImage = false, string basePath = @"C:\Users\ma_th\Desktop\")
        {
            // déroulement de l'algo A* 
            Node courant = nodeInitial;

            // ajout de courant dans la liste ouverte 
            _openList.Add(courant);
            _closeList.Add(courant);
            ajouter_cases_adjacentes(courant, nodeFinal);

            int cpt = 0;

            // tant que la destination n'a pas été atteinte et qu'il reste des noeuds à explorer dans la liste ouverte
            while ((courant.Id != nodeFinal.Id))
            {
                // on cherche le meilleur noeud de la liste ouverte, on sait qu'elle n'est pas vide donc il existe 
                courant = _openList.ElementAt<Node>(0); // Premier élément car la liste est triée
                Console.WriteLine($"{courant.Id}");

                // on le passe dans la liste fermée, il ne peut pas déjà y être 
                ajouter_liste_fermee(courant);

                // on recommence la recherche des noeuds adjacents 
                ajouter_cases_adjacentes(courant, nodeFinal);

                if (printImage)
                {
                    AffichageGraphe.SaveImage(graphe, _openList, _closeList, 50, basePath + "astar" + cpt + ".png");
                    ++cpt;
                }
            }

            // si la destination est atteinte, on remonte le chemin
            if (courant.Id == nodeFinal.Id)
            {
                var chemin = retrouver_chemin(nodeInitial, nodeFinal);
                Console.WriteLine("Chemin trouvé");
            }
            else
            {
                Console.WriteLine("Pas de solution.");
            }
        }


    }
}
