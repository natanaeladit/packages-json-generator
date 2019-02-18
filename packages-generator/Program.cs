using System;
using System.Collections.Generic;
using System.IO;

namespace packages_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> packageFile = new List<string>();

            string currFolderPath = Directory.GetCurrentDirectory();
            Console.WriteLine("Reading nuget packages in folder: " + currFolderPath);

            Console.WriteLine("Reading all folders");
            packageFile.Add("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            packageFile.Add("<packages>");

            string[] folderList = Directory.GetDirectories(currFolderPath);
            foreach (var folderPath in folderList)
            {
                string folderName = Path.GetFileName(folderPath);

                string[] packageNameAndVer = GetNugetPackageNameAndVersionNumber(folderName);

                packageFile.Add("<package id=\"" + packageNameAndVer[0] + "\" version=\"" + packageNameAndVer[1] + "\" targetFramework=\"net452\" />");
            }
            packageFile.Add("</packages>");
            Console.WriteLine();

            foreach (string str in packageFile)
            {
                Console.WriteLine(str);
            }

            //foreach (var str in GetNugetPackageNameAndVersionNumber("Microsoft.SqlServer.SqlManagementObjects.140.17283.0"))
            //{
            //    Console.WriteLine(str);
            //}

            Console.WriteLine("packages.json file is generated successfully!");
            Console.ReadLine();
        }

        static string[] GetNugetPackageNameAndVersionNumber(string folderName)
        {
            int idx = 0;
            int number = 0;
            bool found = false;
            string str = folderName;

            while (!found)
            {
                idx = str.IndexOf('.');
                if (idx > -1)
                {
                    if (int.TryParse(str.Substring(idx + 1, 1), out number))
                    {
                        int lastDotIdx = str.IndexOf('.');
                        idx = folderName.IndexOf(str) + lastDotIdx;
                        found = true;
                    }
                    else
                    {
                        str = str.Substring(idx + 1, str.Length - idx - 1);
                    }
                }
                else
                {
                    return new string[2] { "", "" };
                }
            }
            string packageName = folderName.Substring(0, idx);
            string packageVer = folderName.Substring(idx + 1, folderName.Length - 1 - idx);

            return new string[2] { packageName, packageVer };
        }
    }
}
