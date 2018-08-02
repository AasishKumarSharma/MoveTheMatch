using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAppToMoveMatchedFilesBetweenTwoFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Move The Match - Developed By: Aasish Kr. Sharma. All rights reserved.\n");
            Console.WriteLine("==========================================================\n");
            Console.Write("This program will move the matched files only after comparing\n");
            Console.Write("between source and destination folders into a third folder. \n");
            Console.Write("The path detials are specified by the user.\n");
            Console.Write("The movement of files will be from source folder into matched folder.\n");
            Console.Write("Input details required:\n");
            Console.Write("1. Source folder path\n");
            Console.Write("2. Destination folder path\n");
            Console.Write("3. Folder path to store matched files.\n");
            Console.WriteLine("\n==========================================================\n");
            Console.WriteLine("==========================================================\n");

            Console.WriteLine("Enter the source folder path:");
            string sourceFolderPath = Console.ReadLine();
            Console.WriteLine("\nEnter the destination folder path:");
            string destinationFolderPath = Console.ReadLine();
            Console.WriteLine("\nEnter the folder path to store matched files:");
            string storageFolderPath = Console.ReadLine();

            try
            {
                if (!System.IO.Directory.Exists(sourceFolderPath))
                {
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Source directory does not exists.");
                    Console.WriteLine("Please check the specified paths.");
                    Console.WriteLine("==========================================================\n");
                }
                else if (!System.IO.Directory.Exists(destinationFolderPath))
                {
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Destination directory does not exists.");
                    Console.WriteLine("Please check the specified paths.");
                    Console.WriteLine("==========================================================\n");
                }
                else if (!System.IO.Directory.Exists(storageFolderPath))
                {
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Match store directory does not exists.");
                    Console.WriteLine("Please check the specified paths.");
                    Console.WriteLine("==========================================================\n");
                }
               else if (
                    System.IO.Directory.Exists(sourceFolderPath)
                    && System.IO.Directory.Exists(destinationFolderPath)
                    && System.IO.Directory.Exists(storageFolderPath)
                    )
                {
                    string[] sourceFilesArray = Directory.GetFiles(sourceFolderPath); //@"c:\", "c*"
                    bool isMatchFound = false;

                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Files Moved:");
                    Console.WriteLine("==========================================================\n");

                    foreach (string sourceFile in sourceFilesArray)
                    {
                        if (File.Exists(sourceFile.Replace(sourceFolderPath, destinationFolderPath)))
                        {
                            isMatchFound = true;
                            System.IO.File.Move(sourceFile, sourceFile.Replace(sourceFolderPath, storageFolderPath));
                            Console.WriteLine(sourceFile.Replace((sourceFolderPath + "\\"), string.Empty));
                        }
                    }

                    if (!isMatchFound)
                    {
                        Console.WriteLine("No match found.");
                    }
                }
                else
                {
                    Console.WriteLine("\n==========================================================");
                    Console.WriteLine("Please check the specified paths.");
                    Console.WriteLine("Any of the directory does not exists (Source, Destination or Match store directory).");
                    Console.WriteLine("==========================================================\n");
                }
                Console.WriteLine("\n==========================================================");
                Console.WriteLine("End Of Program");
                Console.WriteLine("==========================================================\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Console.ReadKey(true);
            }
        }
    }
}
