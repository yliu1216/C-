using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class post
    {
        private static int currentPostId;

        //properties
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string SendByUserName { get; set; }
        protected bool IsPublic { get; set; }

        //default constructor
        public post()
        {
            ID = 0;
            Title = "My first Post";
            SendByUserName = "Yingwei Liu";
            IsPublic = true;
        }

        //instance constructor that has three parameters
        public post(string title, bool ispublic, string senddbyusername)
        {
            this.ID = 0;
            this.Title = title;
            this.IsPublic = ispublic;
            this.SendByUserName = senddbyusername;
        }

        protected int GetNextID()
        {
            return ++currentPostId;
        }

        public void update(string title, bool ispublic)
        {
            this.Title = title;
            this.IsPublic = ispublic;
        }

        public override string ToString()
        {
            return String.Format("{0}-----{1}-----by{2}", this.ID, this.Title, this.SendByUserName);
        }

    }
}
