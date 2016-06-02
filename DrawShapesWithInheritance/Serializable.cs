using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawShapesWithInheritance
{
    interface Serializable
    {
        string Serialize();
        void Deserialize(List<NameValue> list);
    }
}
