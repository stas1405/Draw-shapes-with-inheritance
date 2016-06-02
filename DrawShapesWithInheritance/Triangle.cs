using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
    class Triangle:BaseShape
    {
        Point[] Points;

        public Triangle()
        {
            Type = "triangle";
        }
        public Triangle(string type, int size, Color color,  bool isFilled, Point position): base(type, size, color, isFilled, position)
        {
            Points = new Point[3];
            Points[0] = new Point(Position.X, Position.Y);
            Points[1] = new Point(Position.X, Position.Y + Size);
            Points[2] = new Point(Position.X + Size, Position.Y);
        }

        
        public override void Draw(System.Drawing.Graphics graphicContext)
        {
            if (IsFilled == true)
            {
                SolidBrush brush = new SolidBrush(Color);

                graphicContext.FillPolygon(brush, Points);
            }
            Pen Pen = new Pen(Color);
            graphicContext.DrawPolygon(Pen, Points);
        }
        public override void Deserialize(List<NameValue> list)
        {
            base.Deserialize(list);
            Points = new Point[3];
            Points[0] = new Point(Position.X, Position.Y);
            Points[1] = new Point(Position.X, Position.Y + Size);
            Points[2] = new Point(Position.X + Size, Position.Y);

        }
    }
}
