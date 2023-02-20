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
        /// Distance Euclidienne de n1 à n2.
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
        /// Distance de Manhattan de n1 à n2.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double Manhanttan(Node n1, Node n2)
        {
            double x = Math.Abs(n2.x - n1.x);
            double y = Math.Abs(n2.y - n1.y);
            return x + y;
        }

        /// <summary>
        /// Distance de Tchebychev de n1 à n2.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double Tchebychev(Node n1, Node n2)
        {
            double x = Math.Abs(n2.x - n1.x);
            double y = Math.Abs(n2.y - n1.y);
            return Math.Max(x, y);
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
