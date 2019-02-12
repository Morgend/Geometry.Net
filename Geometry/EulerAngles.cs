using System;

/*
 * Author: Andrey Pokidov
 * Date: 2 Feb 2019
 */

namespace MathKit.Geometry
{
    public struct EulerAngles
    {
        public Angle heading;
        public Angle elevation;
        public Angle bank;

        public EulerAngles(double heading, double elevation, double bank)
        {
            this.heading = new Angle(heading);
            this.elevation = new Angle(elevation);
            this.bank = new Angle(bank);
        }

        public EulerAngles(Angle heading, Angle elevation, Angle bank)
        {
            this.heading = heading;
            this.elevation = elevation;
            this.bank = bank;
        }

        public EulerAngles(EulerAngles angles)
        {
            this.heading = angles.heading;
            this.elevation = angles.elevation;
            this.bank = angles.bank;
        }

        public static EulerAngles fromDegrees(double heading, double elevation, double bank)
        {
            return new EulerAngles(Angle.degreesToRadians(heading), Angle.degreesToRadians(elevation), Angle.degreesToRadians(bank));
        }

        public static EulerAngles fromGrads(double heading, double elevation, double bank)
        {
            return new EulerAngles(Angle.gradsToRadians(heading), Angle.gradsToRadians(elevation), Angle.gradsToRadians(bank));
        }

        public void setAngles(double heading, double elevation, double bank)
        {
            this.heading.radians = heading;
            this.elevation.radians = elevation;
            this.bank.radians = bank;
        }

        public void setDegrees(double heading, double elevation, double bank)
        {
            this.heading.setDegrees(heading);
            this.elevation.setDegrees(elevation);
            this.bank.setDegrees(bank);
        }

        public void setGrads(double heading, double elevation, double bank)
        {
            this.heading.setGrads(heading);
            this.elevation.setGrads(elevation);
            this.bank.setGrads(bank);
        }

        public void setAngles(Angle heading, Angle elevation, Angle bank)
        {
            this.heading = heading;
            this.elevation = elevation;
            this.bank = bank;
        }

        public void setAngles(EulerAngles angles)
        {
            this.heading = angles.heading;
            this.elevation = angles.elevation;
            this.bank = angles.bank;
        }

        public void normalize()
        {
            this.heading.normalizePiMinusPi();
            this.elevation.normalizePiMinusPi();

            bool renormalize = false;

            if (this.elevation.radians < -MathConst.PId2)
            {
                this.elevation.radians = -MathConst.PI - this.elevation.radians;
                renormalize = true;
            }
            else if (this.elevation.radians > MathConst.PId2)
            {
                this.elevation.radians = MathConst.PI - this.elevation.radians;
                renormalize = true;
            }

            if (renormalize)
            {
                this.heading.addRadians(MathConst.PI);
                this.heading.normalizePiMinusPi();

                this.bank.addRadians(MathConst.PI);
            }

            this.bank.normalizePiMinusPi();
        }

        public override string ToString()
        {
            return String.Format("EulerAngles(heading = {0} deg, elevation = {1} deg, bank = {2} deg)", this.heading.degrees, this.elevation.degrees, this.bank.degrees);
        }
    }
}
