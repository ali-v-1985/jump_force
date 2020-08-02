using GameState;
using UnityEngine;

namespace Background
{
    public class RepeatBackground : MonoBehaviour
    {
        private Vector3 _initialPosition;

        private float _resetPoint;
        // Start is called before the first frame update
        void Start()
        {
            _initialPosition = transform.position;
            _resetPoint = GetComponent<BoxCollider>().size.x / 2;
        }

        // Update is called once per frame
        void Update()
        {
            if (!GameStateData.GameOver)
            {
                if (transform.position.x <= _initialPosition.x - _resetPoint)
                {
                    gameObject.transform.position = _initialPosition;
                }
            }
        }
    }
}
