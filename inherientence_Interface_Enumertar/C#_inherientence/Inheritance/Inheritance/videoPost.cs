using System;
using System.Threading;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class videoPost:post
    {
        //advanace level-member fields
        protected bool isPlaying = false;
        protected int currDuration = 0;
        Timer timer;

        public string videoURL { get; set; }
        public int length  { get; set; }


        public videoPost(string title, string sendbyUserName, string videoURL, bool isPublic, int length)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUserName = sendbyUserName;
            this.IsPublic = isPublic;
            this.videoURL = videoURL;
            this.length = length;
        }


        public void play()
        {
            isPlaying = true;
            Console.WriteLine("Playing");
            timer = new Timer(TimerCallback, null, 0, 1000);
        }

        private void TimerCallback(Object o)
        {
            if (currDuration < length)
            {
                currDuration++;
                Console.WriteLine("video at {0}", currDuration);
                //garbage collect
                GC.Collect();
            }
            else
            {
                stop();
            }
        }
        public void stop()
        {
            if (isPlaying)
            {
                isPlaying = false;
                Console.WriteLine("Stopped at {0}s ", currDuration);
                currDuration = 0;
                timer.Dispose();
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-----{1}------{2}----- by {3} is {4} long", this.ID, this.videoURL, this.Title, this.SendByUserName, this.length);
        }
    }
}
