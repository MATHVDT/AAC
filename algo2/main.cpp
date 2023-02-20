#include <iostream>

#include "knuthMorrisPratt.hpp"

/*
g++ *cpp -o prog.exe && ./prog.exe
*/

int main(int argc, char *argv[])
{

    std::string chaine = "lalopalalali";
    std::string motif = "lala";

    int res = knuth_morris_pratt(chaine, motif);

    std::cout << "Dans la chaine : " << chaine << std::endl;
    std::cout << "Le motif : " << motif << std::endl;

    if (res = -1)
        std::cout << "N'est pas présent.";
    else
        std::cout << "Débute à la position : " << res;

    std::cout << std::endl;
}