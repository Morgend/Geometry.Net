using System;

/*
 * Author: Andrey Pokidov
 * Date: 5 Feb 2019
 */

namespace GeometryKit
{
    public class MathConstant
    {
        public const double EPSYLON = 0.0000000001;
        public const double SQUARE_EPSYLON = EPSYLON * EPSYLON;
        public const double POSITIVE_EPSYLON = EPSYLON;
        public const double NEGATIVE_EPSYLON = -EPSYLON;

        /// <summary>
        /// PI 
        /// </summary>
        public const double PI = Math.PI;

        /// <summary>
        /// 2 x PI 
        /// </summary>
        public const double PIx2 = Math.PI * 2.0;

        /// <summary>
        /// 0.5 PI (PI divided by 2)
        /// </summary>
        public const double PId2 = Math.PI * 0.5;

        /// <summary>
        /// 3/2 PI
        /// </summary>
        public const double PIx3d2 = Math.PI * 1.5;

        private MathConstant()
        {
        }
    }
}
