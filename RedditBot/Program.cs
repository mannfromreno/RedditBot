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
        List<Comment> commentList = new List<Comment>();

        static void Main(string[] args)
        {            
            Reddit reddit = new Reddit();
            string loggedInUser = DoLogin(reddit);
            GetLockedPosts(reddit);

            Console.ReadLine();


        }

        private static string DoLogin(Reddit redditSession)
        {            
            string username = string.Empty;
            string password = string.Empty;
            Console.Write("Please enter your username: ");
            username = Console.ReadLine();
            Console.Write("Please enter your password: ");
            password = Console.ReadLine();
            if (username == null || password == null)
            {
                Console.Write("Invalid username and/or password, please re-enter credentials");
                return username;
            }
            try 
            {
                redditSession.LogIn(username, password);    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: {0}\n", e);
                return null;
            }
            Console.WriteLine("Successfully logged in as {0}", username);
            return username;
        }

        protected static void GetLockedPosts(Reddit redditObj)
        {
            Subreddit test = redditObj.GetSubreddit("UnlockedBotSandbox");

            foreach (Post p in test.Posts.Take(50))
            {
                Console.WriteLine("Posting titles: {0}", p.Title);
                foreach (Comment c in p.Comments)
                {
                    Console.WriteLine("**** Comments for {0} ****", p.Title);
                    
                    Console.WriteLine(c.Body.ToString());
                }
                
                try
                {
                    //p.Comment("Hello, I am UnlockedBot!");
                }
                catch (RateLimitException rle)
                {
                    Console.WriteLine("Exception occurred: {0}", rle.ToString());
                }
                if (p.CommentCount != 0)
                {

                }
            }   
        }

        protected void GetAllChildComments(Comment parentComment)
        {
            if (parentComment.Comments.Count != 0)
            {
                foreach (Comment c in parentComment.Comments)
                {
                    commentList.Add(c);
                }
            }
            
        }


    }
}
