using System;
using System.Collections;
using GameState;
using UnityEngine;

namespace Movements
{
    public class FloatObject : MonoBehaviour
    {
        private float _speed = 5;
        private float _initialY;
        private bool _goingUp = true;

        [SerializeField] private int range;

        // Start is called before the first frame update
        void Start()
        {
            _initialY = transform.position.y;
            StartCoroutine(FloatMovement());
        }

        // Update is called once per frame
        void Update()
        {
        }

        private IEnumerator FloatMovement()
        {
            while (!GameStateData.GameOver)
            {
                var deltaY = transform.position.y - _initialY;
                if ((int) Math.Abs(deltaY) - range == 0)
                {
                    _goingUp = !_goingUp;
                }

                _speed = Math.Abs(deltaY) - range <= 1 ? 5 : 2;

                if (_goingUp)
                {
                    transform.Translate(Vector3.up * (_speed * Time.deltaTime));
                }
                else
                {
                    transform.Translate(Vector3.down * (_speed * Time.deltaTime));
                }
                yield return null;
            }
        }
    }
}