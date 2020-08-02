using System;
using Events;
using GameState;
using UnityEngine;
using Utils;

namespace Player
{
    public class CheckCollideObstacle : MonoBehaviour
    {
        private EffectsController _effectsControllerScript;
        // Start is called before the first frame update
        void Start()
        {
            _effectsControllerScript = gameObject.GetComponent<EffectsController>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Tags.Obstacle))
            {
                EventRepo.HitToObstacle.OnRaiseHitToObstacleEvent(this);
                _effectsControllerScript.PlayExplosion();
                if (!GameStateData.GameOver)
                {
                    Destroy(other.gameObject);
                    _effectsControllerScript.PlayCrashSound();
                }
                else
                {
                    _effectsControllerScript.PlayDeathSound();
                }
            }
        }
    }
}
