using SocialMediaManagementSystem.AdminNamespace;
using SocialMediaManagementSystem.EmailSpace;
using SocialMediaManagementSystem.NetworkNamespace;
using SocialMediaManagementSystem.PostNameSpace;
using System;
using SocialMediaManagementSystem.Instagram; 

namespace SocialMediaManagementSystem
{
    public class main
    {
        static public short showMenu(string[] menu, string header = "")
        {
            short selected = 0;

            while (true)
            {
                Console.Clear(); 
                if (header != "") Console.WriteLine(header);

                for (short i = 0; i < menu.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor= ConsoleColor.DarkBlue;
                        Console.WriteLine($" << {menu[i]} >>");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"    {menu[i]}   ");
                    }
                } 
                ConsoleKeyInfo key = Console.ReadKey(true);
                 
                if (key.Key == ConsoleKey.UpArrow && selected > 0) selected--;
                if (key.Key == ConsoleKey.DownArrow && selected < menu.Length - 1) selected++;
                if (key.Key == ConsoleKey.Enter) return selected;
            }
        }
        static void Main(string[] args)
        {

            var admin = new Admin();
            var ig = new InstagramApp();
            var user = new User();
            var loginRegter = new LoginAndRegter();
            var mail = new Mail();
            var notification = new Notification();

            string[] user_or_admin = { "Admin", "User", "Exit" };
            string[] logRegMenu = { "Log in", "Register", "Back" };
            string[] userMenu = { "Watch Post", "Back" };
            string[] adminMenu = { "Add Post", "Your Posts", "Delete Post", "Delete All Posts", "E-mail", "Delete E-mail", "Notification", "Back"}; 


            while (true)
            {
                short uoaInd = showMenu(user_or_admin, "=== Panel ===");

                if (uoaInd == 0)
                {
                    short lgInd = showMenu(logRegMenu, "=== Account ==="); 

                    if (lgInd == 0)
                    {
                        bool isTrue = LoginAndRegter.Login("admin.txt");
                        Console.ReadKey(true);

                        if (true)
                        {
                            short adInd = showMenu(adminMenu, "=== Admin Section ===");
                            switch (adInd)
                            {
                                case 0: ig.AddPost(); Console.ReadKey(true); break;
                                case 1: ig.ShowPosts(); break;
                                case 2: ig.DeletePost(); Console.ReadKey(true); break;
                                case 3: ig.DeleteAllPosts(); Console.ReadKey(true); break;
                                case 4: mail.showEmail(); Console.ReadKey(true); break;      
                                case 5: mail.DeleteMail(); Console.ReadKey(true); break;     
                                case 6: notification.showNotification(); Console.ReadKey(true); break;
                                case 7: break;
                            }
                        } 
                    }
                    else if (lgInd == 1)
                    {
                        loginRegter.Register("admin.txt");
                        Console.ReadKey(true);
                    } 
                }
                else if(uoaInd == 1)
                {
                    short lgInd = showMenu(logRegMenu, "=== Account ===");

                    if (lgInd == 0)
                    {
                        bool isTrue = LoginAndRegter.Login("user.txt");
                        Console.ReadKey(true); 

                        if (true)
                        {
                            short usInd = showMenu(userMenu, "=== User Section ===");
                            switch (usInd)
                            {
                                case 0: ig.likePost(); break;
                                case 1: break; 
                                default: break;
                            }
                        }
                    }
                    else if (lgInd == 1)
                    {
                        loginRegter.Register("user.txt");
                        Console.ReadKey(true);
                    } 
                }
                else if(uoaInd == 2) break;
            }
        }
    }
}
