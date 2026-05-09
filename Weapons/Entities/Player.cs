using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weapons.Entities
{
    internal class Player
    {
        public string Name;
        public Weapon ActiveWeapon;
        public List<Weapon> Weapons;
        public List<Magazine> Magazines;

        private int currentWeaponIndex = 0;

        public Player(string NewName, List<Weapon> NewWeapons, List<Magazine> NewMagazines)
        {
            this.Name = NewName;
            this.Weapons = NewWeapons;
            this.Magazines = NewMagazines;
            if (Weapons.Count > 0) ActiveWeapon = Weapons[0];
        }

        public void AddWeapon(Weapon NewWeapon)
        {
            if (NewWeapon == null)
                throw new Exception("Weapon can`t be null");
            Weapons.Add(NewWeapon);
        }

        public void SelectNextWeapon()
        {
            if (Weapons == null || Weapons.Count == 0)
                throw new Exception("You have no weapon");

            currentWeaponIndex = (currentWeaponIndex + 1) % Weapons.Count;
            ActiveWeapon = Weapons[currentWeaponIndex];
        }

        public void Reload()
        {
            if (ActiveWeapon == null)
                throw new InvalidOperationException("You don`t have weapon");

            CaliberType currentWeaponCaliber = ActiveWeapon.Caliber;
            Magazine foundMag = Magazines.FirstOrDefault(m => m.Caliber == currentWeaponCaliber);
            if (foundMag == null)
                return;

            ActiveWeapon.ChangeMagazine(foundMag);
            Magazines.Remove(foundMag);
        }
    }
}
