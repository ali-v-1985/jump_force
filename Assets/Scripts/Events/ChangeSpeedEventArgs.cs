﻿using System;

 namespace Events
 {
     public class ChangeSpeedEventArgs : EventArgs
     {
         public ChangeSpeedEventArgs(float speed, int effectiveTime)
         {
             this.Speed = speed;
             this.EffectiveTime = effectiveTime;
         }

         public float Speed { get; set; }

         public int EffectiveTime { get; set; }
     }
 }