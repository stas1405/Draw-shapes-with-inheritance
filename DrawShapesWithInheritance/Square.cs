using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
    class Square: BaseShape
    {
        public Square()
        {
            Type = "square";
        }
        public Square(string type, int size, Color color, bool isFilled, Point position) : base(type, size, color, isFilled, position)
        {

        }


        public override void Draw(System.Drawing.Graphics graphicContext)
        {
            if (IsFilled == true)
            {
                SolidBrush brush = new SolidBrush(Color);

                graphicContext.FillRectangle(brush, Position.X, Position.Y, Size, Size);
            }
            Pen Pen = new Pen(Color);
            graphicContext.DrawRectangle(Pen, Position.X, Position.Y, Size, Size);

        }
    }
}
