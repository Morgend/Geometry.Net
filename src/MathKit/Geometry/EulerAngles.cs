using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct EulerAngles
    {
        public Angle Heading;
        public Angle Elevation;
        public Angle Bank;

        public EulerAngles(double heading, double elevation, double bank)
        {
            this.Heading = new Angle(heading);
            this.Elevation = new Angle(elevation);
            this.Bank = new Angle(bank);
        }

        public EulerAngles(Angle heading, Angle elevation, Angle bank)
        {
            this.Heading = heading;
            this.Elevation = elevation;
            this.Bank = bank;
        }

        public EulerAngles(EulerAngles angles)
        {
            this.Heading = angles.Heading;
            this.Elevation = angles.Elevation;
            this.Bank = angles.Bank;
        }

        public static EulerAngles FromDegrees(double heading, double elevation, double bank)
        {
            return new EulerAngles(Angle.DegreesToRadians(heading), Angle.DegreesToRadians(elevation), Angle.DegreesToRadians(bank));
        }

        public static EulerAngles FromGrads(double heading, double elevation, double bank)
        {
            return new EulerAngles(Angle.GradsToRadians(heading), Angle.GradsToRadians(elevation), Angle.GradsToRadians(bank));
        }

        public void SetRadians(double heading, double elevation, double bank)
        {
            this.Heading.Radians = heading;
            this.Elevation.Radians = elevation;
            this.Bank.Radians = bank;
        }

        public void SetDegrees(double heading, double elevation, double bank)
        {
            this.Heading.Degrees = heading;
            this.Elevation.Degrees = elevation;
            this.Bank.Degrees = bank;
        }

        public void SetGrads(double heading, double elevation, double bank)
        {
            this.Heading.Grads = heading;
            this.Elevation.Grads = elevation;
            this.Bank.Grads = bank;
        }

        public void SetAngles(Angle heading, Angle elevation, Angle bank)
        {
            this.Heading = heading;
            this.Elevation = elevation;
            this.Bank = bank;
        }

        public void SetAngles(EulerAngles angles)
        {
            this.Heading = angles.Heading;
            this.Elevation = angles.Elevation;
            this.Bank = angles.Bank;
        }

        public void Normalize()
        {
            this.Heading.NormalizePiMinusPi();
            this.Elevation.NormalizePiMinusPi();

            bool renormalize = false;

            if (this.Elevation.Radians < -MathConst.PId2)
            {
                this.Elevation.Radians = -MathConst.PI - this.Elevation.Radians;
                renormalize = true;
            }
            else if (this.Elevation.Radians > MathConst.PId2)
            {
                this.Elevation.Radians = MathConst.PI - this.Elevation.Radians;
                renormalize = true;
            }

            if (renormalize)
            {
                this.Heading.AddRadians(MathConst.PI);
                this.Heading.NormalizePiMinusPi();

                this.Bank.AddRadians(MathConst.PI);
            }

            this.Bank.NormalizePiMinusPi();
        }

        public override string ToString()
        {
            return String.Format("EulerAngles(heading = {0} deg, elevation = {1} deg, bank = {2} deg)", this.Heading.Degrees, this.Elevation.Degrees, this.Bank.Degrees);
        }
    }
}
