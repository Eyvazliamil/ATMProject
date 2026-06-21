using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office.CustomUI;
using SocialMediaManagementSystem;
using SocialMediaManagementSystem.PostNameSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagementSystem.NetworkNamespace;

namespace SocialMediaManagementSystem.Instagram
{
    internal class InstagramApp
    { 
        public InstagramApp()
        {

        } 

        Post post = new Post();
        Notification notification = new Notification();

        public void AddPost()
        {
            Console.Clear();
            Console.WriteLine("=== Add Post ===");
            Console.Write("Include Content: ");
            post.setContent(Console.ReadLine());

            File.AppendAllText("posts.txt", post.getContent() + "\n" + $"Like: {post.getLikeCount()}     View: {post.getViewCount()}" + "\n");
            Console.WriteLine("Post added!");
        }

        public short ShowPosts()
        {
            string[] lines = File.ReadAllLines("posts.txt");
            if (lines.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("===== Your Posts =====");
                Console.WriteLine("No posts yet.");
                Console.ReadKey(true); return -1;
            }
            else
            {
                short selected = 0;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===== Your Posts =====");
                    for (short i = 0; i < lines.Length - 1; i += 2)
                    {
                        if (i == selected)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"    {lines[i]}      ");
                            Console.WriteLine($"    {lines[i + 1]}  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"    {lines[i]}      ");
                            Console.WriteLine($"    {lines[i + 1]}  ");
                        }
                        Console.WriteLine("\n======================================\n");
                    }
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow && selected > 0) selected -= 2;
                    if (key.Key == ConsoleKey.DownArrow && selected < lines.Length - 2) selected += 2;
                    if (key.Key == ConsoleKey.Enter) return selected;
                }
            }
        }
        public void DeletePost()
        {
            var lines = File.ReadAllLines("posts.txt").ToList();
            if (lines.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("===== Your Posts =====");
                Console.WriteLine("No posts yet.");
                Console.ReadKey(true); return;
            }
            else
            {
                short ind = ShowPosts();
                if (ind == -1) return;

                lines.RemoveRange(ind, 2);

                File.WriteAllLines("posts.txt", lines);
                Console.Clear();
                Console.WriteLine("=== Delete Post ===");
                Console.Write("Post was deleted.");
            }
        } 

        public void DeleteAllPosts()
        {
            string[] lines = File.ReadAllLines("posts.txt");
            if (lines.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("===== Your Posts =====");
                Console.WriteLine("No posts yet.");
                Console.ReadKey(true); return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("================================");
                File.WriteAllText("posts.txt", "");
                Console.WriteLine("Posts Successfully deleted.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any button to continue...");
                Console.ResetColor();
            }
        }

        public void likePost()
        {
            string[] lines = File.ReadAllLines("posts.txt");

            if (lines.Length == 0)
            {
                Console.Clear();
                Console.WriteLine("===== Your Posts =====");
                Console.WriteLine("No posts yet.");
                Console.ReadKey(true);
            }
            else
            {
                short selected = 0;
                short postIndex = 0;
                string[] igButtons = { "Give Like", "Next Reel", "Back" };

                bool checkLike = true;
                bool checkView = true;

                while (true)
                {
                    string[] parts = lines[postIndex + 1].Split("     ");
                    post.setLikeCount(long.Parse(parts[0].Replace("Like: ", "")));
                    post.setViewCount(long.Parse(parts[1].Replace("View: ", "")));

                    if (checkView)
                    {
                        checkView = false;
                        post.AddView();
                        lines[postIndex + 1] = $"Like: {post.getLikeCount()}     View: {post.getViewCount()}";
                        File.WriteAllLines("posts.txt", lines);
                    }

                    Console.Clear();
                    Console.WriteLine("===== Reels =====");
                    Console.WriteLine($"    {lines[postIndex]}      ");
                    Console.WriteLine($"    {lines[postIndex + 1]}  ");
                    Console.WriteLine();

                    for (short k = 0; k < igButtons.Length; k++)
                    {
                        if (k == selected)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.WriteLine($"  << {igButtons[k]} >> ");
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine($"     {igButtons[k]}    ");
                    }

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow && selected > 0) selected--;
                    if (key.Key == ConsoleKey.DownArrow && selected < igButtons.Length - 1) selected++;

                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (selected == 0)
                        {
                            if (checkLike)
                            {
                                checkLike = false;
                                post.AddLike();
                                lines[postIndex + 1] = $"Like: {post.getLikeCount()}     View: {post.getViewCount()}";
                                File.WriteAllLines("posts.txt", lines);
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("     You gave a like");
                                Console.ResetColor();
                                notification.sendMessage("Someone liked your post!");
                                Console.ReadKey(true);

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("You already liked this video.");
                                Console.ResetColor();
                                Console.ReadKey(true);
                            }
                        }
                        else if (selected == 1)
                        {
                            if (postIndex + 2 < lines.Length)
                                postIndex += 2;
                            else
                                postIndex = 0;

                            checkLike = true;
                            checkView = true;
                        }
                        else if (selected == 2) return;
                    }

                    if (key.Key == ConsoleKey.Escape) break;
                }
            }
        }

        public void SaveLike()
        {
            post.AddLike();
        }
         
    }
}
