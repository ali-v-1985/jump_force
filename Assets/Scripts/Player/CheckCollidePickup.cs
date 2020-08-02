using GameState;
using Pickup;
using UnityEngine;
using Utils;

namespace Player
{
    public class CheckCollidePickup : MonoBehaviour
    {
        private EffectsController _effectsControllerScript;

        private PlayerController _playerControllerScript;

        // Start is called before the first frame update
        void Start()
        {
            _effectsControllerScript = gameObject.GetComponent<EffectsController>();
            _playerControllerScript = gameObject.GetComponent<PlayerController>();
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Tags.Pickup))
            {
                var pickupPowerScript = other.gameObject.GetComponent<PickupPower>();
                _effectsControllerScript.PlayExplosion();
                Destroy(other.gameObject);
                _effectsControllerScript.PlayPickupSound();
                ImproveAbility(pickupPowerScript);
            }
        }

        private void ImproveAbility(PickupPower pickupPower)
        {
            switch (pickupPower.Ability)
            {
                case Ability.Jump:
                    _playerControllerScript.IncreaseJumpAmount(pickupPower.Power, pickupPower.LifeTime);
                    break;
                case Ability.Speed:
                    _playerControllerScript.IncreaseSpeedAmount(pickupPower.Power, pickupPower.LifeTime);
                    break;
                case Ability.MultiJump:
                    _playerControllerScript.IncreaseMultiJumpAmount(pickupPower.Power, pickupPower.LifeTime);
                    break;
            }
        }
    }
}