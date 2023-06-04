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

            
            string path = Console.ReadLine();
            int d = 0;
            string substring = "*.";
            int indexOfSubstring = substring.IndexOf(substring);
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
                Basic_search(main_path_directoryInfo, folder_and_file);
               
            }
            if (d == 2)
            {
                string subpath = path.Substring(path.IndexOf('*') + 2);
                string[] folder_and_file = subpath.Trim().Split('\\');
                folder_and_file[2] = folder_and_file[2].Replace("#.", "*.");
                Console.WriteLine();
                Recursive_search(main_path_directoryInfo, folder_and_file);
            }

            Console.WriteLine("Программа завершила работу!");

           Console.ReadLine();
        }

        static void Basic_search(DirectoryInfo main_path, string[] folder_and_file)
        {
            DirectoryInfo[] directoryInfo = null;
            DirectoryInfo[] subDirectoryInfo = null;
            FileInfo[] filesInfo = null;

            try
            {
                directoryInfo = main_path.GetDirectories();
            }
            catch { }

            for (int i = 0; i < directoryInfo.Length; i++)
            {

                try
                {
                    subDirectoryInfo = directoryInfo[i].GetDirectories();
                }
                catch { }

                for (int j = 0; j < subDirectoryInfo.Length; j++)
                {

                

                     if (Convert.ToString(subDirectoryInfo[j]) == folder_and_file[1])
                     {
                          try
                          {
                            filesInfo = subDirectoryInfo[j].GetFiles(folder_and_file[2]);
                          }
                          catch { }

                         if (filesInfo != null)
                         {
                             for (int k = 0; k < filesInfo.Length; k++)
                             {
                                    
                                 

                                Console.WriteLine("Найден файл: " + filesInfo[k].FullName);
                             }
                         }

                     }
                }
            }

        } 

        static void Recursive_search(DirectoryInfo main_path, string[] folder_and_file)
        {
            DirectoryInfo[] directoryInfo = null;
            FileInfo[] filesInfo = null;


            try
            {
                directoryInfo = main_path.GetDirectories();
            }
            catch { }
          
            if (directoryInfo != null)
            {

                for (int i = 0; i < directoryInfo.Length; i++ )
                {
                    if (Convert.ToString(directoryInfo[i]) == folder_and_file[1])
                    {

                        //
                        try
                        {
                            filesInfo = directoryInfo[i].GetFiles(folder_and_file[2]);
                        }
                        catch { }

                        if (filesInfo != null)
                        {
                            for (int k = 0; k < filesInfo.Length; k++)
                            {

                                Console.WriteLine("Найден файл: " + filesInfo[k].FullName);
                            }
                        }
                        else
                        {

                            Recursive_search(directoryInfo[i], folder_and_file); 
                        }
                    }
                    else
                    {
                        Recursive_search(directoryInfo[i], folder_and_file);
                    }
                }


               
                
            }

        }
    }
}
