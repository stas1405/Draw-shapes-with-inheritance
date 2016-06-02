using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
  abstract  class BaseShape: Shape, Drawable, Serializable
    {
        public string Type { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; }
        public bool IsFilled { get; set; }
        public Point Position { get; set; }
        public BaseShape()
        { 
        }
        public BaseShape(string type, int size, Color color, bool isFilled, Point position)
        {
            Type = type;
            Size = size;
            Color = color;
            IsFilled = isFilled;
            Position = position;
        }
       
        public string Serialize()
        {
            StringBuilder strBld = new StringBuilder();
            string shapeType = "type:" + Type + "; ";
            string shapePosition = "X:" +  Position.X.ToString() + "; " + "Y:" + Position.Y.ToString() + "; ";

            string shapeColor = "A:" + Color.A.ToString() + "; " + "R:" + Color.R.ToString()
                + "; " + "G:" + Color.G.ToString() + "; " + "B:" + Color.B.ToString() + "; ";
            string isShapeFilled = IsFilled.ToString();
            string shapeSize = Size.ToString();

            strBld.Append(shapeType).Append(shapePosition).Append(shapeColor).
                    Append("Filled:" + isShapeFilled + "; ").
                    Append("Size:" + shapeSize + ";");
            return strBld.ToString();
        }

        public virtual void Deserialize(List<NameValue> list)
        {
            Point pos = new Point();
                 
                    int a = -1;
                    int r = -1;
                    int g = -1;
                    int b = -1;
                    int size = -1;
                    bool filled = false;
            foreach(NameValue curNameVal in list)
            {
                        if (curNameVal.Name == " X")
                        {
                            int x = -1;
                            int.TryParse(curNameVal.Value, out x);
                            pos.X = x;
                            this.Position = pos;
                        }
                        if (curNameVal.Name == " Y")
                        {
                            int y = -1;
                            int.TryParse(curNameVal.Value, out y);
                            pos.Y = y;
                            this.Position = pos;
                        }
                        if (curNameVal.Name == " A")
                        {
                            int.TryParse(curNameVal.Value, out a);
                            this.Color = Color.FromArgb(a, 0, 0, 0);
                           
                        }
                        if (curNameVal.Name == " R")
                        {
                            int.TryParse(curNameVal.Value, out r);
                            this.Color = Color.FromArgb(a, r, 0, 0);
                        }
                        if (curNameVal.Name == " G")
                        {
                            int.TryParse(curNameVal.Value, out g);
                            this.Color = Color.FromArgb(a, r, g, 0);
                        }
                        if (curNameVal.Name == " B")
                        {
                            int.TryParse(curNameVal.Value, out b);
                            this.Color = Color.FromArgb(a, r, g, b);
                        }
                        if (curNameVal.Name == " Filled")
                        {
                            bool.TryParse(curNameVal.Value, out filled);
                            this.IsFilled = filled;
                        }
                        if (curNameVal.Name == " Size")
                        {
                            int.TryParse(curNameVal.Value, out size);
                            this.Size = size;
                            
                        }
                    }
                }
        abstract public void Draw(System.Drawing.Graphics ctx);
       



    }


}
