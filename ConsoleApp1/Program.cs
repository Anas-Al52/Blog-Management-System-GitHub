using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<string[]> blogPosts = new List<string[]>();

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nBlogg Meny:");
                Console.WriteLine("1. Lägg till inlägg");
                Console.WriteLine("2. Visa alla inlägg");
                Console.WriteLine("3. Sök inlägg efter exakt titel");
                Console.WriteLine("4. Redigera inlägg");
                Console.WriteLine("5. Ta bort inlägg");
                Console.WriteLine("6. Sortera inlägg efter titel");
                Console.WriteLine("7. Avsluta programmet");
                Console.Write("Välj ett alternativ (1-7): ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddPost();
                        break;
                    case "2":
                        ShowPosts();
                        break;
                    case "3":
                        BinarySearchPosts();
                        break;
                    case "4":
                        EditPost();
                        break;
                    case "5":
                        DeletePost();
                        break;
                    case "6":
                        SortPostsByTitle();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt alternativ. Försök igen.");
                        break;
                }
            }
        }

        static void AddPost()
        {
            Console.Write("Ange titel: ");
            string title = Console.ReadLine();
            Console.Write("Ange meddelande: ");
            string message = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            blogPosts.Add(new string[] { title, message, date });
            Console.WriteLine("Inlägg tillagt.");
        }

        static void ShowPosts()
        {
            Console.WriteLine("\nAlla blogginlägg:");
            int index = 0;
            foreach (var post in blogPosts)
            {
                Console.WriteLine($"Index: {index++}");
                Console.WriteLine($"Titel: {post[0]}");
                Console.WriteLine($"Meddelande: {post[1]}");
                Console.WriteLine($"Datum: {post[2]}\n");
            }
        }

        static void BinarySearchPosts()
        {
            // Ensure the posts are sorted before searching
            SortPostsByTitle();

            Console.Write("Ange titel att söka efter: ");
            string searchTerm = Console.ReadLine();
            int low = 0, high = blogPosts.Count - 1;
            bool found = false;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                string midTitle = blogPosts[mid][0];

                int result = string.Compare(midTitle, searchTerm, StringComparison.OrdinalIgnoreCase);

                if (result == 0)  // Title exactly matches the search term
                {
                    Console.WriteLine($"\nTitel: {blogPosts[mid][0]}");
                    Console.WriteLine($"Meddelande: {blogPosts[mid][1]}");
                    Console.WriteLine($"Datum: {blogPosts[mid][2]}");
                    found = true;
                    break;
                }
                else if (result < 0) // Title is less than the search term, search the right half
                {
                    low = mid + 1;
                }
                else  // Title is greater than the search term, search the left half
                {
                    high = mid - 1;
                }
            }

            if (!found)
            {
                Console.WriteLine("Inga inlägg hittades med den exakta titeln.");
            }
        }

        static void EditPost()
        {
            Console.Write("Ange index för inlägg att redigera: ");
            int index;
            if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < blogPosts.Count)
            {
                string[] post = blogPosts[index];
                Console.Write("Ny titel (lämna tomt för att behålla nuvarande): ");
                string title = Console.ReadLine();
                Console.Write("Nytt meddelande (lämna tomt för att behålla nuvarande): ");
                string message = Console.ReadLine();

                if (!string.IsNullOrEmpty(title))
                    post[0] = title;
                if (!string.IsNullOrEmpty(message))
                    post[1] = message;

                Console.WriteLine("Inlägg uppdaterat.");
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
            }
        }

        static void DeletePost()
        {
            Console.Write("Ange index för inlägg att ta bort: ");
            int index;
            if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < blogPosts.Count)
            {
                blogPosts.RemoveAt(index);
                Console.WriteLine("Inlägg borttaget.");
            }
            else
            {
                Console.WriteLine("Ogiltigt index.");
            }
        }

        static void SortPostsByTitle()
        {
            // Insertion sort by title
            for (int i = 1; i < blogPosts.Count; i++)
            {
                string[] current = blogPosts[i];
                string currentTitle = current[0];
                int j = i - 1;

                while (j >= 0 && blogPosts[j][0].CompareTo(currentTitle) > 0)
                {
                    blogPosts[j + 1] = blogPosts[j];
                    j--;
                }
                blogPosts[j + 1] = current;
            }
            Console.WriteLine("Blogginlägg har sorterats efter titel.");
        }
    }
}
