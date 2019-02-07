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
            this.heading.normalize();
            this.elevation.normalize();

            if (MathConst.PId2 < this.elevation.radians && this.elevation.radians < MathConst.PIx3d2)
            {
                this.elevation.radians = MathConst.PI - this.elevation.radians;

                this.heading.addRadians(MathConst.PI);
                this.heading.normalize();

                this.bank.addRadians(MathConst.PI);
            }
            else if (this.elevation.radians >= MathConst.PI)
            {
                this.elevation.radians -= MathConst.PIx2;
            }

            this.bank.normalize();
        }

        public override string ToString()
        {
            return String.Format("EulerAngles(heading = {0} deg, elevation = {1} deg, bank = {2} deg)", this.heading.degrees, this.elevation.degrees, this.bank.degrees);
        }
    }
}
