using System;
using System.Collections.Generic;
using System.Linq;

namespace Weapons.Entities
{
    internal class Player
    {
        public string Name { get; private set; }
        public Weapon ActiveWeapon { get; private set; }
        public List<Weapon> Weapons { get; private set; }
        public List<Magazine> Magazines { get; private set; }

        private int currentWeaponIndex = 0;

        public Player(string newName, List<Weapon> newWeapons, List<Magazine> newMagazines)
        {
            Name = newName;
            Weapons = newWeapons;
            Magazines = newMagazines;
            if (Weapons.Count > 0) ActiveWeapon = Weapons[0];
        }

        public void AddWeapon(Weapon newWeapon)
        {
            if (newWeapon == null)
                throw new Exception("Weapon can't be null");
            Weapons.Add(newWeapon);
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
