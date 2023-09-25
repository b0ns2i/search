using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Searcher searcher = new Searcher();
           




            string path = Console.ReadLine();
            int d = 0;
            path = path.Replace("*.", "#.");


            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == '*')
                {
                    d++;
                }
            }

            string main_path = path.Substring(0, path.IndexOf('*'));
            

            DirectoryInfo main_path_directoryInfo = new DirectoryInfo(main_path);
            if(d == 1)
            {
                
                string subpath = path.Substring(path.IndexOf('*') + 1);
                string[] folder_and_file = subpath.Trim().Split('\\');
                folder_and_file[2] = folder_and_file[2].Replace("#.", "*.");
                searcher.Basic_search(main_path_directoryInfo, folder_and_file);
               
            }
            if (d == 2)
            {
                string subpath = path.Substring(path.IndexOf('*') + 2);
                string[] folder_and_file = subpath.Trim().Split('\\');
                folder_and_file[2] = folder_and_file[2].Replace("#.", "*.");
                Console.WriteLine();
                searcher.Recursive_search(main_path_directoryInfo, folder_and_file);
            }

            Console.WriteLine("Программа завершила работу!");

           Console.ReadLine();
        }



    }
}
