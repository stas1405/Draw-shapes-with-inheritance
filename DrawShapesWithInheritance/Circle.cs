using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DrawShapesWithInheritance
{
    
    class Circle : BaseShape
    {
        public Circle()
        {
            Type = "circle";
        }
        public Circle(string type, int size, Color color, bool isFilled, Point position): base(type, size, color, isFilled, position)
        {
            
        }
        public override void Draw(System.Drawing.Graphics graphicContext)
        {
            if (IsFilled == true)
            {
                SolidBrush brush = new SolidBrush(Color);

                graphicContext.FillEllipse(brush, Position.X, Position.Y, Size, Size);
            }
            Pen Pen = new Pen(Color);
            graphicContext.DrawEllipse(Pen, Position.X, Position.Y, Size, Size);

        }
    }
}
