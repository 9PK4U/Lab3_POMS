using Android.App;
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
using System.IO;
using Environment = System.Environment;

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
            writeToFile(DateTime.Now.ToString() + " " + "Таймер начал работу");

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

        public override void OnCreate()
        {
            base.OnCreate();
        }
        public override bool StopService(Intent name)
        {
            counter = 0;
            isRunningTimer = false;
            return base.StopService(name);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            writeToFile(DateTime.Now.ToString() + " " + "Таймер закончил работу");
            counter = 0;
            isRunningTimer = false;
            base.OnDestroy();
        }

        private void writeToFile(string textLine)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            

            string filename = "file.txt";
            if (String.IsNullOrEmpty(filename)) return;

            StreamWriter fileStream = new StreamWriter(new FileStream(Path.Combine(folderPath, filename), FileMode.Append));


            fileStream.WriteLine(textLine);

            fileStream.Close();
        }
    }
}