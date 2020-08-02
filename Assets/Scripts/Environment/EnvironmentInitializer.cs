using UnityEngine;

namespace Environment
{
    public class EnvironmentInitializer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Physics.gravity = EnvironmentData.InitialGravity * EnvironmentData.GravityForce;
        }
    }
}
