#include "knuthMorrisPratt.hpp"

/*
 * Algorithme naif de recherche de motif avec 2 indices.
 *
 * Entree : const std::string & - chaine dans laquelle on recherche le motif
 *          const std::string & - motif que l'on recherche dans la chaine
 */
int naif(const std::string &chaine,
         const std::string &motif)
{
    int lenChaine = chaine.length();
    int lenMotif = motif.length();

    std::cout << "chaine : " << chaine << ", "
              << "lenChaine : " << lenChaine << std::endl;

    std::cout << "motif : " << motif << ", "
              << "lenMotif : " << lenMotif << std::endl;

    // Verifie que le motif n'est pas plus grand que la chaine
    // Verifie que le motif n'est pas null
    if (lenMotif <= lenChaine || lenMotif == 0)
        return -1;

    int i = 0;
    int j = 0;

    while (i + j < lenChaine)
    {
        printf("i=%d, j=%d et chaine[i+j]=%c, motif[j]=%c\n",
               i, j, chaine[i + j], motif[j]);

        // Lettres egales avec le motif
        while (j < lenMotif &&
               chaine[i + j] == motif[j])
        {
            j++; // On progresse dans le motif et la chaine

            printf("i=%d, j=%d et chaine[i+j]=%c, motif[j]=%c\n",
                   i, j, chaine[i + j], motif[j]);
        }
        printf("\n");

        // Si l'on a atteint la fin du motif
        // ie qu'on a trouve une correspondance
        if (j == lenMotif)
        {
            std::cout << "Motif trouve a l'indice : " << i << std::endl;
            return i; // On renvoie l'indice de debut
        }

        // Motif pas trouve a cette position
        ++i;
        j = 0;
    }
    // Motif absent du mot
    return -1;
}

/*
 * Algorithme de knuth_morris_pratt. (Issue de : Programmation efficace Les 128 algorithmes qu'il faut avoir compris et codés en Python au cours de sa vie)
 *
 * Entree : const std::string & - chaine dans laquelle on recherche le motif
 *          const std::string & - motif que l'on recherche dans la chaine
 */
int knuth_morris_pratt(const std::string &chaine, const std::string &motif)
{
    int lenChaine = chaine.length();
    int lenMotif = motif.length();

    std::cout << "chaine : " << chaine << ", "
              << "lenChaine : " << lenChaine << std::endl;

    std::cout << "motif : " << motif << ", "
              << "lenMotif : " << lenMotif << std::endl;

    // Verifie que le motif n'est pas plus grand que la chaine
    // Verifie que le motif n'est pas null
    if (lenMotif > lenChaine || lenMotif == 0)
        return -1;

    // Vecteur de taille lenMotif avec la valeur 0
    std::vector<int> r(lenMotif, 0);
    int j = -1;
    r[0] = -1;

    // Initialisation prefix table
    for (int i = 1; i < lenMotif; ++i)
    {
        while (j >= 0 && motif[i - 1] != motif[j])
        {
            j = r[j];
        }
        j += 1;
        r[i] = j;
    }
    // Affichage de r
    std::cout << "initialisation du tableau de décalage r : ";
    std::copy(r.begin(), r.end(), std::ostream_iterator<int>(std::cout, ""));
    std::cout << std::endl;

    j = 0;
    int decalageAffichageMotif = 0;
    // Parcours de la chaine
    for (int i = 0; i < lenChaine; ++i)
    {
        affichage(i, j, chaine, motif);
        while (j >= 0 && chaine[i] != motif[j])
        {
            j = r[j];
            affichage(i, j,  chaine, motif);
        }
        j += 1;
        if (j == lenMotif)
        {
            return i - lenMotif + 1;
        }
    }

    return -1;
}

void affichage(int i, int j, std::string chaine, std::string motif)
{
    std::cout << std::endl;
    std::cout << "i      :";
    for (int k = 0; k < i; ++k)
        std::cout << " ";
    std::cout << "v" << std::endl;

    std::cout << "chaine :";
    std::cout << chaine << std::endl;

    std::cout << "motif  :";
    std::cout << motif << std::endl;
    std::cout << "j      :";
    for (int k = 0; k < j; ++k)
        std::cout << " ";
    std::cout << "^" << std::endl;
}