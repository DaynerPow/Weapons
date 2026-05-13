using System;
using System.Collections.Generic;
using System.Linq;
using Weapons.Types;

namespace Weapons.Entities
{
    internal class Magazine
    {
        private static int autoInc = 1;

        public int Id { get; private set; }
        public CaliberType Caliber { get; private set; }
        public int Bullets { get; private set; }
        public int MaxBullets { get; }

        public Magazine(CaliberType newCaliber, int newMaxBullets)
        {
            Id = autoInc++;
            Caliber = newCaliber;
            MaxBullets = newMaxBullets;
            Bullets = newMaxBullets;
        }

        public void RemoveBullet()
        {
            if (Bullets <= 0)
                throw new Exception("Magazine is empty");
            Bullets--;
        }
    }
}
