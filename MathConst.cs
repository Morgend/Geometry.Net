using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 */

namespace MathKit
{
    public class MathConst
    {
        public const double EPSYLON = 0.000000000001;
        public const double POSITIVE_EPSYLON = EPSYLON;
        public const double NEGATIVE_EPSYLON = -EPSYLON;

        /// <summary>
        /// PI 
        /// </summary>
        public const double PI = 3.1415926535897932;

        /// <summary>
        /// 2 x PI 
        /// </summary>
        public const double PIx2 = 6.2831853071795864;

        /// <summary>
        /// 0.5 PI (PI divided by 2)
        /// </summary>
        public const double PId2 = 1.5707963267948966;

        /// <summary>
        /// 3/2 PI
        /// </summary>
        public const double PIx3d2 = 4.7123889803846898;

        private MathConst()
        {
        }
    }
}
