using UnityEngine;

namespace Geekbrains
{
    public class Inventory : IInitialization
    {
        private Weapon[] _weapons = new Weapon[2];
        public int _currentWeaponNumber;

        public Weapon[] Weapons => _weapons;

        public FlashLightModel FlashLight { get; private set; }

        public void OnStart()
        {
            _weapons = Main.Instance.Player.GetComponentsInChildren<Weapon>();

            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }

            FlashLight = Object.FindObjectOfType<FlashLightModel>();
        }

        //todo Добавить функционал
        public int PreviousWeapon()
        {
            _currentWeaponNumber--;
            if (_currentWeaponNumber < 0)
            {
                _currentWeaponNumber = 0;
            }
            return _currentWeaponNumber;
        }
        public int NextWeapon()
        {
            _currentWeaponNumber++;
            if (_currentWeaponNumber > _weapons.Length)
            {
                _currentWeaponNumber = _weapons.Length - 1;
            }

            return _currentWeaponNumber;
        }
        public void RemoveWeapon(Weapon weapon)
        {

        }
    }
}