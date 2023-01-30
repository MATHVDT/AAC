using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{



    internal class Astar
    {

        private List<Node> _openList = new();
        //private List<Node> _closeList = new();
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
            //Node tmpNode = new Node();

            NodeCara nodeCara = new NodeCara();

            var listVoisins = nodeBase.GetNodesVoisins();

            foreach (var nodeVoisin in listVoisins)
            {
                // Test si le noeud voisin est bien libre (ie possible de passer à travers)
                if (nodeVoisin.typeNode == TypeNode.Obstacle) { continue; }

                // le noeud n'est pas déjà présent dans la liste fermée 
                if (!_closeList.Contains(nodeVoisin))
                {
                    /* calcul du cout G du noeud en cours d'étude : cout du parent + distance jusqu'au parent */
                    nodeCara.Cout_g = nodeBase.Cout_g + Distance.Euclidienne(nodeVoisin, nodeBase);

                    ///* calcul du cout G du noeud en cours d'étude : cout du parent + distance jusqu'au parent */
                    //tmp.cout_g = liste_fermee[n].cout_g + distance(i, j, n.first, n.second);

                    /* calcul du cout H du noeud à la destination */
                    nodeCara.Cout_h = Distance.Euclidienne(nodeVoisin, nodeFinal);
                    nodeCara.Cout_f = nodeCara.Cout_g + nodeCara.Cout_f;
                    nodeCara.Parent = nodeBase;

                    /* calcul du cout H du noeud à la destination */
                    //tmp.cout_h = distance(i, j, arrivee.x, arrivee.y);
                    //tmp.cout_f = tmp.cout_g + tmp.cout_h;
                    //tmp.parent = n;

                    if (_openList.Contains(nodeVoisin))
                    {
                        // le noeud est déjà présent dans la liste ouverte, il faut comparer les couts 
                        if (nodeCara.Cout_f < nodeVoisin.Cout_f)
                        {
                            // si le nouveau chemin est meilleur, on met à jour 
                            nodeVoisin.SetNodeCara(nodeCara);
                        }
                        // le noeud courant a un moins bon chemin, on ne change rien 

                    }
                    else
                    {
                        // le noeud n'est pas présent dans la liste ouverte, on l'y ajoute
                        _openList.Add(nodeVoisin);
                    }

                    //if (deja_present_dans_liste(it, liste_ouverte))
                    //{
                    /* le noeud est déjà présent dans la liste ouverte, il faut comparer les couts */
                    //    if (tmp.cout_f < liste_ouverte[it].cout_f)
                    //    {
                    //        /* si le nouveau chemin est meilleur, on met à jour */
                    //        liste_ouverte[it] = tmp;
                    //    }

                    //    /* le noeud courant a un moins bon chemin, on ne change rien */
                    //}
                    //else
                    //{
                    //    /* le noeud n'est pas présent dans la liste ouverte, on l'y ajoute */
                    //    liste_ouverte[pair<int, int>(i, j)] = tmp;
                    //}
                }
            }
        }


        public void ajouter_liste_fermee(Node node)
        {
            //noeud & n = liste_ouverte[p];

            _closeList.Add(node);
            //liste_fermee[p] = n;

            // il faut le supprimer de la liste ouverte, ce n'est plus une solution explorable 
            if (!_openList.Remove(node))
                Console.WriteLine("Erreur, le noeud n'apparaît pas dans la liste ouverte, impossible à supprimer");


            /* il faut le supprimer de la liste ouverte, ce n'est plus une solution explorable */
            //if (liste_ouverte.erase(p) == 0)
            //    cerr << "Erreur, le noeud n'apparaît pas dans la liste ouverte, impossible à supprimer" << endl;
            //return;
        }


        public List<Node> retrouver_chemin(Node nodeInitial, Node nodeFinal)
        {
            // l'arrivée est le dernier élément de la liste fermée


            /* l'arrivée est le dernier élément de la liste fermée */
            // noeud & tmp = liste_fermee[std::pair<int, int>(arrivee.x, arrivee.y)];

            Node tmpNode = nodeFinal;
            List<Node> chemin = new List<Node>();

            chemin.Insert(0, tmpNode);

            // Remonter la liste des noeuds pour former le chemin
            while (tmpNode != nodeInitial)
            {
                tmpNode = tmpNode.Parent;
                chemin.Insert(0, tmpNode);
            }

            //struct point n;
            //pair<int, int> prec;
            //n.x = arrivee.x;
            //n.y = arrivee.y;
            //prec.first  = tmp.parent.first;
            //prec.second = tmp.parent.second;
            //chemin.push_front(n);

            //while (prec != pair<int, int>(depart.parent.first, depart.parent.first)){
            //    n.x = prec.first;
            //    n.y = prec.second;
            //    chemin.push_front(n);

            //    tmp = liste_fermee[tmp.parent];
            //    prec.first  = tmp.parent.first;
            //    prec.second = tmp.parent.second;
            //}
            return chemin;
        }


        public void process(Node nodeInitial, Node nodeFinal)
        {


            //arrivee.x = s->w - 1;
            //arrivee.y = s->h - 1;

            //depart.parent.first = 0;
            //depart.parent.second = 0;

            //pair<int, int> courant;

            ///* déroulement de l'algo A* */

            ///* initialisation du noeud courant */
            //courant.first = 0;
            //courant.second = 0;

            ///* ajout de courant dans la liste ouverte */
            //liste_ouverte[courant] = depart;
            //ajouter_liste_fermee(courant);
            //ajouter_cases_adjacentes(courant);

            ///* tant que la destination n'a pas été atteinte et qu'il reste des noeuds à explorer dans la liste ouverte */
            //while (!((courant.first == arrivee.x) && (courant.second == arrivee.y))
            //        &&
            //       (!liste_ouverte.empty())
            //     )
            //{

            //    /* on cherche le meilleur noeud de la liste ouverte, on sait qu'elle n'est pas vide donc il existe */
            //    courant = meilleur_noeud(liste_ouverte);

            //    /* on le passe dans la liste fermée, il ne peut pas déjà y être */
            //    ajouter_liste_fermee(courant);

            //    /* on recommence la recherche des noeuds adjacents */
            //    ajouter_cases_adjacentes(courant);
            //}

            ///* si la destination est atteinte, on remonte le chemin */
            //if ((courant.first == arrivee.x) && (courant.second == arrivee.y))
            //{
            //    retrouver_chemin();

            //    ecrire_bmp();
            //}
            //else
            //{
            //    /* pas de solution */
            //}
        }
    }
}
