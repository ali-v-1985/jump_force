using UnityEngine;

namespace Pickup
{
    public class PickupPower : MonoBehaviour
    {
        [SerializeField] private Ability ability;

        [SerializeField] [Range(0.25f, 2.0f)] private float power = 0.25f;

        [SerializeField] [Range(2, 8)] private int lifeTime = 3;

        public Ability Ability
        {
            get => ability;
            set => ability = value;
        }

        public float Power
        {
            get => power;
            set => power = value;
        }

        public int LifeTime
        {
            get => lifeTime;
            set => lifeTime = value;
        }
    }
}