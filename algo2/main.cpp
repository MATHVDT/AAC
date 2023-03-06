#include <iostream>

#include "knuthMorrisPratt.hpp"

/*
g++ *cpp -o prog.exe && ./prog.exe
g++ *cpp -o prog.exe && ./prog.exe "ABC ABCDAB ABCDABCDABDE" "ABCDABD"

*/

int main(int argc, char *argv[])
{
    std::string chaine;
    std::string motif;

    if (argc == 3)
    {
        chaine = argv[1];
        motif = argv[2];
    }
    else
    {
        chaine = "lalopalalali";
        motif = "lala";
    }

    int res = -1;
    // res = naif(chaine, motif);
    res = knuth_morris_pratt(chaine, motif);

    std::cout << "Dans la chaine : " << chaine << std::endl;
    std::cout << "Le motif : " << motif << std::endl;

    if (res == -1)
        std::cout << "N'est pas présent. " << res;
    else
        std::cout << "Débute à la position : " << res;

    std::cout << std::endl;
}