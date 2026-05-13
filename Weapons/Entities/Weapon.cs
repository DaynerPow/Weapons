using System;
using System.Collections.Generic;
using System.Linq;
using Weapons.Types;

namespace Weapons.Entities
{
    internal class Weapon
    {
        private static int autoInc = 1;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public CaliberType Caliber { get; private set; }
        public Magazine ActiveMagazine { get; private set; }
        public bool IsMagazineIn
        {
            get { return ActiveMagazine != null; }
        }

        public Weapon(string newName, CaliberType type)
        {
            Id = autoInc++;
            Name = newName;
            Caliber = type;
        }

        public void ChangeMagazine(Magazine newMagazine)
        {
            if (newMagazine == null)
                throw new Exception("Magazine can't be null");
            if (newMagazine.Caliber != Caliber)
                throw new Exception("Wrong caliber");

            ActiveMagazine = newMagazine;
        }

        public void Shoot()
        {
            if (ActiveMagazine == null)
                throw new Exception("No magazine inserted");

            ActiveMagazine.RemoveBullet();
        }
    }
}
