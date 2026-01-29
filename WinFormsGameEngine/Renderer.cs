using WinFormsGameEngineAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WinFormsGameEngine
{
    public static class Renderer
    {
        public static Panel Window { get; set; } = null;
        private static float _zoom = 1;
        public static float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; 
            UpdateSizes(); }
        }
        public static float[] Pan { get; set; } = [0, 0];
        public static int CurrentFocus { get; set; } = 0;
        public static List<Button> Entities { get; set; } = new List<Button>();

        public static void NewEntity()
        {
            IEntity entity = EntityFactory.CreateEntity(EntityType.Default);
            Engine.Entities.Add(entity);
            CreateButton(entity);
        }
        public static void NewEntity(EntityType entityType, String name)
        {
            IEntity entity = EntityFactory.CreateEntity(entityType, name);
            Engine.Entities.Add(entity);
            CreateButton(entity);
        }
        public static void NewEntity(EntityType entityType, string name, float mass, float[] size, float[] position)
        {
            IEntity entity = EntityFactory.CreateEntity(entityType, name, mass, size, position);
            Engine.Entities.Add(entity);
            CreateButton(entity);
        }
        public static void NewEntity(EntityType entityType, string name, float mass, float[] size, float[] position, float[] velocity)
        {
            IEntity entity = EntityFactory.CreateEntity(entityType, name, mass, size, position, velocity);
            Engine.Entities.Add(entity);
            CreateButton(entity);
        }
        public static void NewEntity(EntityType entityType, string name, float mass, float[] size, float[] position, float[] velocity, bool collisions)
        {
            IEntity entity = EntityFactory.CreateEntity(entityType, name, mass, size, position, velocity, collisions);
            Engine.Entities.Add(entity);
            CreateButton(entity);
        }

        private static void CreateButton(IEntity entity)
        {
            Button button = new()
            {
                Name = Convert.ToString(entity.Id),
                Size = EntitySize(entity),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.DarkGray,
                Location = EntityPoint(entity),
                Font = new System.Drawing.Font("Cascadia Code", 12 * Zoom, System.Drawing.FontStyle.Bold)
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += WhenClicked;
            Entities.Add(button);
            Window.Controls.Add(button);
        }
        public static void Initialise(Panel window)
        {
            Window = window;
            Engine.EngineTimer.Elapsed += new ElapsedEventHandler(Render);
            Engine.Enabled = true;
        }

        public static void Render(object source, ElapsedEventArgs e)
        {
            Engine.Tick();
            UpdatePositions();
        }
        public static void UpdatePositions()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Invoke((MethodInvoker)delegate
                {
                    Entities[i].Location = EntityPoint(Engine.Entities[i]);
                    //...Entities[i].Text = $"{Engine.Entities[i].Position[0].ToString("F")}, {Engine.Entities[i].Position[1].ToString("F")}";
                    //Entities[i].Text = Engine.Entities[i].Name;
                    //Entities[0].Text = Engine.IsBottomInstersecting(Engine.Entities[0], Engine.Entities[1]).ToString();
                });
            }
        }
        public static void UpdateSizes()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Invoke((MethodInvoker)delegate
                {
                    Entities[i].Size = EntitySize(Engine.Entities[i]);
                    Entities[i].Font = new System.Drawing.Font("Cascadia Code", 10 * Zoom, System.Drawing.FontStyle.Bold);
                });
            }
        }
        private static Point EntityPoint(IEntity entity)
        {
            float x = ((entity.Position[0] - Pan[0]) * 100 * Zoom) + Window.Width / 2;
            float y = ((entity.Position[1] - Pan[1]) * 100 * Zoom) + Window.Height / 2;
            return new Point(Convert.ToInt32(x), Convert.ToInt32(y));
        }
        private static Size EntitySize(IEntity entity)
        {
            return new Size(Convert.ToInt32(entity.Size[0] * 100 * Zoom), Convert.ToInt32(entity.Size[1] * 100 * Zoom));
        }
        public static void WhenClicked(object source, EventArgs e)
        {
            var button = (Button)source;
            CurrentFocus = Convert.ToInt32(button.Name) - 1;
        }
    }
}
