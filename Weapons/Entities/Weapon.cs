using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weapons.Entities
{
    internal class Weapon
    {
        public int Id;
        private static int autoInc = 1;

        public string Name;
        public CaliberType Caliber;
        public bool IsMagazineIn;
        public Magazine ActiveMagazine;

        public Weapon(string NewName, CaliberType Type, bool isMagazineIn)
        {
            this.Id = autoInc++;

            this.Name = NewName;
            this.Caliber = Type;
            this.IsMagazineIn = isMagazineIn;
        }

        public void ChangeMagazine(Magazine newMagazine)
        {
            if (newMagazine != null && newMagazine.Caliber == this.Caliber)
            {
                this.ActiveMagazine = newMagazine;
                this.IsMagazineIn = true;
            }
            else throw new Exception("Magazine can`t be null");
        }

        public void Shoot()
        {
            if (!IsMagazineIn || ActiveMagazine == null)
                throw new Exception("Magazine is null");

            if (ActiveMagazine.bullets <= 0)
                throw new Exception("Magazine is empty");

            ActiveMagazine.bullets--;
        }
    }
}
