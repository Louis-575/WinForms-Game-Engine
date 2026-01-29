using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGameEngineAPI
{
    public class Immovable : Entity
    {
        public Immovable()
        {
            Total++;
            this.Id = Total;
            this.Name = $"entity {Total}";
            this.Position = new float[] { 0, 0 };
            this.Velocity = new float[] { 0, 0 };
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = 1;
            this.Size = new float[] { 1, 1 };
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
        }
        public Immovable(string aName)
        {
            Total++;
            this.Id = Total;
            this.Name = aName;
            this.Position = new float[] { 0, 0 };
            this.Velocity = new float[] { 0, 0 };
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = 1;
            this.Size = new float[] { 1, 1 };
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
        }
        public Immovable(string aName, float aMass, float[] aSize, float[] aPosition)
        {
            Total++;
            this.Id = Total;
            this.Name = aName;
            this.Position = aPosition;
            this.Velocity = new float[] { 0, 0 };
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = aMass;
            this.Size = aSize;
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
        }
        public Immovable(string aName, float aMass, float[] aSize, float[] aPosition, float[] aVelocity)
        {
            Total++;
            this.Id = Total;
            this.Name = aName;
            this.Position = aPosition;
            this.Velocity = aVelocity;
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = aMass;
            this.Size = aSize;
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
        }
        public Immovable(string aName, float aMass, float[] aSize, float[] aPosition, float[] aVelocity, bool aCollisions)
        {
            Total++;
            this.Id = Total;
            this.Name = aName;
            this.Position = aPosition;
            this.Velocity = aVelocity;
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = aMass;
            this.Size = aSize;
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
            this.Collisions = aCollisions;
        }
        public override void Simulate(float deltaT)
        {
            this.Name = deltaT.ToString();
        }
    }
}
