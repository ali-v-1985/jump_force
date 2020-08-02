using System.Threading.Tasks;
using Events;
using GameState;
using UnityEngine;

namespace Movements
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField]
        private float speed = 10;
        private float _initialSpeed;
        // Start is called before the first frame update
        void Start()
        {
            _initialSpeed = speed;
            EventRepo.ChangeSpeed.Register(HandleChangeSpeedEvent);
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameStateData.GameOver)
            {
                transform.Translate(Vector3.left * (speed * Time.deltaTime));
            }
        }
        
        void HandleChangeSpeedEvent(object sender, ChangeSpeedEventArgs e)
        {
            speed += speed * e.Speed;
            Task.Delay(e.EffectiveTime * 1000).ContinueWith(t=> ReturnToRegularSpeed());
        }
        
        private void ReturnToRegularSpeed()
        {
            speed = _initialSpeed;
        }
    }
}
