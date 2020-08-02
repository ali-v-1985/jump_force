using UnityEngine;

namespace Movements
{
    public class DestroyOutOfBounds : MonoBehaviour
    {
        [SerializeField] private float lowBound = -15;
    
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (IsOutOfBounds())
            {
                Destroy(gameObject);
            }
        }

        private bool IsOutOfBounds()
        {
            return transform.position.x <= lowBound;
        }
    }
}
