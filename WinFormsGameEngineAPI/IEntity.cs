
namespace WinFormsGameEngineAPI
    
{
    public interface IEntity
    {
        public static int Total;
        public string Name { get; set; }
        public int Id { get; set; }
        public float[] Position {  get; set; }
        public float[] Velocity { get; set; }
        public float[] Acceleration { get; set; }
        public float Mass { get; set; }
        public float[] Size { get; set; }
        public float[] RForce { get; set; }
        public float[] AForce { get; set; }
        public float[] CForce { get; set; }
        public bool Collisions { get; set; }
        public float[] Centre { get; }
        public float[] InversePosition { get; }
        public void Simulate(float deltaT);
        public void WhenCollided(IEntity entity);
        public void CollisionsCalc();
    }
}
