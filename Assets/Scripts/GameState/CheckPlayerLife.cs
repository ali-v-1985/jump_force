using System;
using System.Threading.Tasks;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace GameState
{
    public class CheckPlayerLife : MonoBehaviour
    {

        [SerializeField]
        private int playerMaxLife = 5;

        [SerializeField] private Slider playerLifeBar;
        private int _playerLife;

        private bool _isInvulnerable = false;
        
        
        
        // Start is called before the first frame update
        void Start()
        {
            _playerLife = playerMaxLife;
            playerLifeBar.value = _playerLife;
            EventRepo.HitToObstacle.Register(HandleHitToObstacleEvent);
            EventRepo.ChangeSpeed.Register(HandleChangeSpeedEvent);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        void HandleHitToObstacleEvent(object sender)
        {
            if (!_isInvulnerable)
            {
                _playerLife--;
            }
            playerLifeBar.value = _playerLife;
            if (_playerLife <= 0)
            {
                GameStateData.GameOver = true;
            }
        }
        
        void HandleChangeSpeedEvent(object sender, ChangeSpeedEventArgs e)
        {
            _isInvulnerable = true;
            Task.Delay(e.EffectiveTime * 1000).ContinueWith(t=> _isInvulnerable = false);
        }
    }
}
