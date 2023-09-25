using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search
{
    public  class Searcher
    {


        public void Basic_search(DirectoryInfo main_path, string[] folder_and_file)
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

        public void Recursive_search(DirectoryInfo main_path, string[] folder_and_file)
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

                for (int i = 0; i < directoryInfo.Length; i++)
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
                           
                                for (int k = 0; k < filesInfo.Length; k++) // 
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
