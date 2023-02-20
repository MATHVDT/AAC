#include "knuthMorrisPratt.hpp"

int knuth_morris_pratt(const std::string &chaine, const std::string &motif)
{
    // Verifie que le motif n'est pas null
    if (motif == "")
        return -1;

    int lenChaine = chaine.size();
    int lenMotif = motif.size();

    std::cout << "lenChaine : " << lenChaine << std::endl;
    std::cout << "lenMotif : " << lenMotif << std::endl;

    std::vector<int> r(lenMotif, 0); // Vecteur de lenMotif 0
    int j = -1;
    r[0] = -1;

    std::cout << "r : ";
    for (int i = 0; i < r.size(); ++i)
        std::cout
            << r[i] << " ";
    std::cout << std::endl;

    for (int i = 1; i < lenMotif; ++i)
    {
        while (j >= 0 && motif[i - 1] != motif[j])
        {
            j = r[j];
        }
        j += 1;
        r[i] = j;
    }
    j = 0;

    for (int i = 0; i < lenChaine; ++i)
    {
        while (j >= 0 && chaine[i] != motif[j])
        {
            j = r[j];
        }
        j += 1;
        if (j == lenMotif)
        {
            return i - lenMotif + 1;
        }
    }

    return -1;
}
