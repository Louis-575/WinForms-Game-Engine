using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WinFormsGameEngineAPI
{
    
    public static class Engine
    {
        public static int TickRate { get; private set; } = 70;
        public static float DeltaT { get; private set; } = 1000 / TickRate;

        private static bool _enabled;
        public static bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value;
                EngineTimer.Enabled = value; }
        }
        public static float DampingFactor { get; set; } = 3F;
        public static float RestitutionCo { get; set; } = 10000;
        public static float GravField { get; set; } = 0;


        public static System.Timers.Timer EngineTimer = new System.Timers.Timer(DeltaT);

        public static List<IEntity> Entities = new List<IEntity>();

           

        public static void Initialise()
        {
            //EngineTimer.Elapsed += new ElapsedEventHandler(Tick);
        }

        public static void Tick(/*object source, ElapsedEventArgs e*/)
        {
            CheckCollisions();
            foreach (IEntity entity in Entities) 
            {
                entity.Simulate(DeltaT);
            }
        }
        public static void CheckCollisionsNew() 
        {
            foreach (IEntity entity in Entities.Where(x => x.Collisions == true)) 
            {
                entity.CollisionsCalc();
            }

        }
        public static void CheckCollisions()
        {
            
            foreach (IEntity entity1 in Entities) 
            {
                entity1.CForce[0] = 0;
                entity1.CForce[1] = 0;
                foreach (IEntity entity2 in Entities)
                {
                    if (entity1 != entity2 && entity1.Collisions == true && entity2.Collisions == true)
                    {
                        BottomIntersection(entity1, entity2);
                        TopIntersection(entity1, entity2);
                        RightIntersection(entity1, entity2);
                        LeftIntersection(entity1, entity2);
                        if (entity1.CForce[0] != 0 && entity1.CForce[1] != 0)
                        {
                            if (Math.Abs(entity1.CForce[0]) > Math.Abs(entity1.CForce[1]))
                            {
                                entity1.CForce[0] = 0;
                            }
                        } 
                    }
                }       
            }

        }
        public static void BottomIntersection(IEntity entity1, IEntity entity2)
        {
            if ((entity1.Position[1] + entity1.Size[1] > entity2.Position[1]) &
                (entity1.Position[1] + entity1.Size[1]/2 < entity2.Position[1]) &&
                entity1.Position[0] < entity2.Position[0] + entity2.Size[0] &&
                entity1.Position[0] + entity1.Size[0] > entity2.Position[0])

            {
                entity1.CForce[1] = -(entity1.Position[1] + entity1.Size[1] - entity2.Position[1]) * RestitutionCo;
            }
            
        }
        public static void TopIntersection(IEntity entity1, IEntity entity2)
        {
            if ((entity1.Position[1] < entity2.Position[1] + entity2.Size[1]) &&
                (entity1.Position[1] + entity1.Size[1] / 2 > entity2.Position[1] + entity2.Size[1]) &&
                entity1.Position[0] < entity2.Position[0] + entity2.Size[0] &&
                entity1.Position[0] + entity1.Size[0] > entity2.Position[0])
            {
                entity1.CForce[1] = -(entity1.Position[1] - entity2.Position[1] - entity2.Size[1]) * RestitutionCo;
            }
        }
        public static void LeftIntersection(IEntity entity1, IEntity entity2)
        {
            if ((entity1.Position[0] < entity2.Position[0] + entity2.Size[0]) &&
                (entity1.Position[0] + entity1.Size[0] / 2 > entity2.Position[0] + entity2.Size[0]) &&
                entity1.Position[1] < entity2.Position[1] + entity2.Size[1] &&
                entity1.Position[1] + entity1.Size[1] > entity2.Position[1])
            {
                entity1.CForce[0] = -(entity1.Position[0] - entity2.Position[0] - entity2.Size[0]) * RestitutionCo;
            }

        }
        public static void RightIntersection(IEntity entity1, IEntity entity2)
        {
            if ((entity1.Position[0] + entity1.Size[0] > entity2.Position[0]) &&
                (entity1.Position[0] + entity1.Size[0] / 2 < entity2.Position[0]) &&
                entity1.Position[1] < entity2.Position[1] + entity2.Size[1] &&
                entity1.Position[1] + entity1.Size[1] > entity2.Position[1])
            {
                entity1.CForce[0] = -(entity1.Position[0] + entity1.Size[0] - entity2.Position[0]) * RestitutionCo;
            }
        }
    }
}
