using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using RedditSharp;

namespace RedditBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Reddit reddit = new Reddit();
            string username = "I_am_danny_tanner";
            string password = "austin316";
            reddit.LogIn(username, password);
            
            //reddit.ComposePrivateMessage("test message subject", "test message body", "chewbaccaPenis");
            

            Subreddit test = reddit.GetSubreddit("DannyTannerTesting");
            Listing<Post> posts = test.Posts;
            List<Post> postList = posts.ToList();
            foreach (Post p in postList)
            {
                Console.WriteLine("Posting titles: {0}\n", p.Title);
                if (p.CommentCount != 0)
                { 
                    
                }
            }

            Console.ReadLine();


        }


    }
}
