using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
    class Engine
    {
        private static Engine _Instance = null;

        public List<BaseShape> BaseShapes;
        private Engine()
        {
            BaseShapes = new List<BaseShape>();
        }

        public static Engine GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new Engine();
            }

            return _Instance;
        }
        internal List<NameValue> LineToList(string line)
        {
            List<NameValue> shapes = new List<NameValue>();
            var pares = line.Split(new char[] { ';' });
            foreach (var pare in pares)
            {
                var value = pare.Split(new char[] { ':' });
                if (value[0] == "type")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " X")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " Y")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " A")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " R")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " G")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " B")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " Filled")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
                if (value[0] == " Size")
                {
                    shapes.Add(new NameValue(value[0], value[1]));
                }
            }
            return shapes;
        }

        internal Dictionary<string, string> LineToDictionary(string line)
        {
            Dictionary<string, string> shapes = new Dictionary<string, string>();
            var pares = line.Split(new char[] { ';' });
            foreach (var pare in pares)
            {
                var value = pare.Split(new char[] { ':' });
                if (value[0] == "type")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " X")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " Y")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " A")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " R")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " G")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " B")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " Filled")
                {
                    shapes.Add(value[0], value[1]);
                }
                if (value[0] == " Size")
                {
                    shapes.Add(value[0], value[1]);
                }
            }
            return shapes;
        }
    }
}
