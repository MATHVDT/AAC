#ifndef __KNUTH_MORRIS_PRATT__
#define __KNUTH_MORRIS_PRATT__

#include <vector>
#include <iostream>
#include <iterator>
#include <algorithm>

int naif(const std::string &chaine,
         const std::string &motif);

int knuth_morris_pratt(const std::string &chaine,
                       const std::string &motif);

void affichage(int i, int j, std::string chaine, std::string motif);

#endif