namespace Events
{
    public static class EventRepo
    {
        public static class HitToObstacle
        {
            public delegate void HitToObstacleEventHandler(object sender);

            public static event HitToObstacleEventHandler RaiseHitToObstacleEvent;

            public static void OnRaiseHitToObstacleEvent(object sender)
            {
                RaiseHitToObstacleEvent?.Invoke(sender);
            }

            public static void Register(HitToObstacleEventHandler handler)
            {
                RaiseHitToObstacleEvent += handler;
            }

            public static void Deregister(HitToObstacleEventHandler handler)
            {
                RaiseHitToObstacleEvent -= handler;
            }

            public static void DeregisterAll()
            {
                RaiseHitToObstacleEvent = null;
            }
        }

        public static class ChangeSpeed
        {
            public delegate void ChangeSpeedEventHandler(object sender, ChangeSpeedEventArgs e);

            public static event ChangeSpeedEventHandler RaiseChangeSpeedEvent;

            public static void OnRaiseChangeSpeedEvent(object sender, ChangeSpeedEventArgs e)
            {
                RaiseChangeSpeedEvent?.Invoke(sender, e);
            }

            public static void Register(ChangeSpeedEventHandler handler)
            {
                RaiseChangeSpeedEvent += handler;
            }

            public static void Deregister(ChangeSpeedEventHandler handler)
            {
                RaiseChangeSpeedEvent -= handler;
            }

            public static void DeregisterAll()
            {
                RaiseChangeSpeedEvent = null;
            }
        }

        public static void DeregisterAll()
        {
            HitToObstacle.DeregisterAll();
            ChangeSpeed.DeregisterAll();
        }
    }
}