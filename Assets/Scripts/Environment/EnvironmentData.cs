using UnityEngine;

namespace Environment
{
    public static class EnvironmentData
    {
        public const float GravityForce = 9.8f;
        public static readonly Vector3 InitialGravity = Physics.gravity;
    }
}