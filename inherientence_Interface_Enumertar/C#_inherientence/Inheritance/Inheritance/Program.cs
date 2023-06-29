using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            post post1 = new post("Thanks for the birthday wishes", true, "Yingwei Liu");
            videoPost video1 = new videoPost("failvideo", "Yingwei", "https://www.youtube.com", true, 10);
            Console.WriteLine(video1.ToString());
            Console.WriteLine(post1.ToString());
            Console.ReadLine();
        }
    }
}
