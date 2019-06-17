using System;
using System.IO;
using System.IO.Compression;

namespace DL_test
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.WriteLine("Please enter path to zip file");
            string zipStr = Console.ReadLine();
            string zipPath = @""+$"{zipStr}";
            Console.WriteLine(zipPath);


            var testPath = Environment.CurrentDirectory + "tmp";
            Directory.CreateDirectory(testPath);

            string zipTmp = testPath;
            DirectoryInfo tmpDir = new DirectoryInfo(zipTmp);

            try
            {
                ZipArchive archive = ZipFile.OpenRead(zipPath);

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    {
                        string destinationPath = Path.GetFullPath(Path.Combine(zipTmp, entry.FullName));

                        if (destinationPath.StartsWith(zipTmp, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath);


                    }


                }

            }
            catch (FileNotFoundException e) {

                Console.WriteLine("file does not exist");
            }

            foreach (var file in Directory.EnumerateFiles(zipTmp, "*", SearchOption.AllDirectories))
            {
               string res = Path.GetFileName(file);

                ClassB classB = new ClassB();

                classB.SomeFunc(res);
                               
                
            }

            foreach (FileInfo fi in tmpDir.GetFiles())
            {
                fi.Delete();
            }

        }
    }
}
