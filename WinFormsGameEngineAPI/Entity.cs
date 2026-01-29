using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsGameEngineAPI
{
    public class Entity : IEntity
    {
        public static int Total = 0;
        public string Name { get; set; }
        public int Id { get; set; }
        public float[] Position { get; set; }
        public float[] Velocity { get; set; }
        public float[] Acceleration { get; set; }
        public float Mass { get; set; }
        public float[] Size {  get; set; }
        public float[] RForce { get; set; }
        public float[] AForce { get; set; }
        public float[] CForce { get; set; }
        public float[] Centre
        {
            get { return [Position[0] + (Size[0]/2), Position[1] + (Size[1]/2)]; }
        }
        public float[] InversePosition
        {
            get { return [Position[0] + Size[0], Position[1] + Size[1]]; }
        }
        public bool Collisions { get; set; }

        public Entity()
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
            this.Collisions = true;
        }
        public Entity(string aName)
        {
            Total++;
            this.Id = Total;
            this.Name = aName;
            this.Position = new float[] { 0, 0 };
            this.Velocity = new float[] { 0, 0 };
            this.Acceleration = new float[] { 0, 0 };
            this.Mass = 1;
            this.Size= new float[] { 1, 1 };
            this.AForce = new float[] { 0, 0 };
            this.RForce = new float[] { 0, 0 };
            this.CForce = new float[] { 0, 0 };
            this.Collisions = true;
        }
        public Entity(string aName, float aMass, float[] aSize, float[] aPosition)
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
            this.CForce = new float[] {0, 0 };
            this.Collisions = true;
        }
        public Entity(string aName, float aMass, float[] aSize, float[] aPosition, float[] aVelocity)
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
            this.Collisions = true;
        }
        public Entity(string aName, float aMass, float[] aSize, float[] aPosition, float[] aVelocity, bool aCollisions)
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
            this.Collisions =aCollisions;
        }
        public virtual void Simulate(float deltaT)
        {

            RForce[0] = CForce[0] + AForce[0] - Velocity[0] * Engine.DampingFactor;
            RForce[1] = CForce[1] + AForce[1] - Velocity[1] * Engine.DampingFactor + Engine.GravField * Mass;
            Acceleration[0] =  RForce[0] / Mass;
            Acceleration[1] =  RForce[1] / Mass;
            Velocity[0] += Acceleration[0] *  deltaT / 1000;
            Velocity[1] += Acceleration[1] * deltaT / 1000;
            Position[0] += Velocity[0] * deltaT / 1000;
            Position[1] += Velocity[1] * deltaT / 1000;
        }

        public virtual void WhenCollided(IEntity entity)
        {
        }

        public void CollisionsCalc()
        {
            foreach (IEntity entity in Engine.Entities.Where(x => x.Collisions == true && x != this))
            {
                float[] deltaPosition = [entity.Centre[0] - Centre[0], entity.Centre[1] - Centre[1]];
                if (InversePosition[0] > entity.Position[0] &&
                    Position[0] < entity.Centre[0] &&
                    InversePosition[1] > entity.Position[1] &&
                    Position[1] < entity.InversePosition[1])
                {
                    CForce[0] = (entity.Position[0] - InversePosition[0]) * Engine.RestitutionCo;
                }
            }
        }
    }
}
