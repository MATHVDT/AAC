using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Distance
    {

        /// <summary>
        /// Distance euclidienne de n1 à n2.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double Euclidienne(Node n1, Node n2)
        {
            double x = (n2.x - n1.x);
            double y = (n2.y - n1.y);
            return Math.Sqrt(Carre(x) + Carre(y));
        }

        /// <summary>
        /// Elève un nombre au carré.
        /// </summary>
        /// <param name="nb"></param>
        /// <returns></returns>
        public static double Carre(double nb)
        {
            return nb * nb;
        }


    }
}
