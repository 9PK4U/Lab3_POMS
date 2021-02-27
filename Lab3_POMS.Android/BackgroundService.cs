﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Lab3_POMS.Droid
{
    [Service(Label = "BackgroundService")]
    public class BackgroundService : Service
    {
        int counter = 0;
        bool isRunningTimer = true;

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            
 
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    MessagingCenter.Send<string>(counter.ToString(), "counterValue");

                    if (counter == 10)
                    {
                        var manager = new AndroidNotificationManager();
                        manager.SendNotification("Таймер", "Таймер закончил работу");
                        StopService(intent);
    
                    }
                    else
                    {
                        counter++;
                        
                    }
                    return isRunningTimer;
                });
            return StartCommandResult.Sticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            counter = 0;
            isRunningTimer = false;
            base.OnDestroy();
        }
    }
}