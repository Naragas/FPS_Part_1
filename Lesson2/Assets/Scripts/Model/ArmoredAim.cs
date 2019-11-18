using System;
using UnityEngine;

namespace Geekbrains
{
    public class ArmoredAim : MonoBehaviour, ISetDamage, ISelectObj
    {
        public event Action OnPointChange;

        public float Hp = 100;
        public float Armor = 50;
        private bool _isDead;
        //todo дописать поглащение урона
        public void SetDamage(InfoCollision info)
        {
            if (_isDead) return;
            if (Armor > 0)
            {
                if (Armor > info.Damage)
                {
                    Armor -= info.Damage;
                    return;
                }
                else
                {
                    Hp -= (info.Damage - Armor);
                    Armor = 0;
                }

            }
            if (Hp > 0)
            {
                Hp -= info.Damage;
            }

            if (Hp <= 0)
            {
                if (!GetComponent<Rigidbody>())
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                Destroy(gameObject, 10);

                OnPointChange?.Invoke();
                _isDead = true;
            }
        }

        public string GetMessage()
        {
            return gameObject.name;
        }
    }
}
