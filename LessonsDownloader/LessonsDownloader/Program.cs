using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsDownloader
{
    class Program
    {

        const string link = "https://www.ou.org/content/themes/ou-theme/lib/direct_download.php?url=https%3A%2F%2Fmedia.ou.org%2Fdaf%2F{0}%2F{0}_{1}.mp3";
        
        static string GetLink(string name, int number)
        {
            return string.Format(link, name, number);
        }

        static void Download(string link, int i, string name)
        {
            using (var client = new System.Net.WebClient())
            {
                client.DownloadFile(link, string.Format("{0} {1}.mp3", i, name));
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter number of dapim:");
            int amount = Convert.ToInt32(Console.ReadLine());
            for (int i = 2; i <= amount; i++)
            {
                string link = GetLink(name, i);
                Console.WriteLine("Downloading daf " + i + "...");
                Download(link, i, name);
            }
        }
    }
}
