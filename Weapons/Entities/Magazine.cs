using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapons.Entities
{
    internal class Magazine
    {
        public int Id;
        public static int autoInc = 1;

        public CaliberType Caliber;
        public int bullets;


    }
}
