using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    //derived from post class and adds a property imageURL
    class imagePost:post
    {
        public string imageURL
        {
            get;
            set;
        }


        public imagePost() { }

        public imagePost(string title, string sendbyUserName, string imageURL, bool isPublic)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUserName = sendbyUserName;
            this.IsPublic = isPublic;
            this.imageURL = imageURL;
        }

        //override from post base class
        public override string ToString()
        {
            return String.Format("{0}-----{1} ------{2}-----by {3} ", this.ID, this.imageURL, this.Title, this.SendByUserName);
        }
    }
}
