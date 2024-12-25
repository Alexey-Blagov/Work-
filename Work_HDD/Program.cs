using System;
using System.IO;
using System.Runtime;
using System.Text;

namespace Work_HDD
{
    internal class Program
    {
        //Создать директории c:\Otus\TestDir1 и c:\Otus\TestDir2 с помощью класса DirectoryInfo.
        //В каждой директории создать несколько файлов File1...File10 с помощью класса File.
        //В каждый файл записать его имя в кодировке UTF8.Учесть, что файл может быть удален, либо отсутствовать права на запись.
        //Каждый файл дополнить текущей датой(значение DateTime.Now) любыми способами: синхронно и\или асинхронно.
        //Прочитать все файлы и вывести на консоль: имя_файла: текст + дополнение.

        static void Main(string[] args)
        {
            string path1 = @"c:\Otus\TestDir1";
            var path2 = @"c:\Otus\TestDir2";

            var dir1 = new DirectoryInfo(path1);
            var dir2 = new DirectoryInfo(path2);
            if (!dir1.Exists)
            {
                dir1.Create();
            }
            if (!dir2.Exists)
            {
                dir2.Create();
            }

            WriteFile(path1, "File1.txt");
            //ReadFile(path1, "File1.txt");
        }
        public static async Task WriteFile(string path, string nameFile)
        {
            try
            {
                byte[] info = new UTF8Encoding(true).GetBytes(nameFile);

                ////using ()
                //{
                    if (File.Exists(path + nameFile))    
                        await File.WriteAllBytesAsync(path + nameFile, info);


                    //fs.Write(info, 0, info.Length);
                    //await fs.WriteAsync(info, 0, info.Length);
                //}
                //// Open the stream and read it back.
                //using (StreamReader sr = File.OpenText(path))
                //{
                //    string s = "";
                //    while ((s = sr.ReadLine()) != null)
                //    {
                //        Console.WriteLine(s);
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static async Task ReadFile(string path, string nameFile)
        {
            try
            {
                if (File.Exists(path + nameFile)) 
                    byte[] buffer = new byte[File.ReadAllBytes(path + nameFile).Length];
                await File.ReadAllBytesAsync(path + nameFile, info);
                using (StreamReader sr = File.OpenText(path + nameFile))
                {
                    string? s;
                   
                    //await sr.ReadAsync(s, 0);
                    //while ((s = sr.ReadLine()) != null)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
