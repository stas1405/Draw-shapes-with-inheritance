using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
    interface Shape
    {
       string Type { get; set; }
       int Size { get; set; }
       Color Color { get; set; }
       bool IsFilled { get; set; }
       Point Position { get; set; }

        
    }
}
