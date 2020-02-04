using System;
using static System.Console;
using System.IO;


namespace DataProcessor
{
    internal class FileProcessor
    {

        private static readonly string BackupDirectoryName = "backup";
        private static readonly string InProgressDirectoryName = "processing";
        private static readonly string CompletedDirectoryName = "complete";

        public string InputFilePath { get; }
        public FileProcessor(string filePath)
        {
            InputFilePath = filePath;
        }

        public void Process()
        {
            WriteLine($"Begin process of InputFilePath = {InputFilePath}");
            //throw new NotImplementedException();

            //Check if file exists
            if (!File.Exists(InputFilePath))
            {
                WriteLine($"ERROR: file InputFilePath = {InputFilePath} does not exist");
                return;
            }

            string rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent.Parent.FullName;
            WriteLine($"rootDirectoryPath = {rootDirectoryPath}");
            //rootDirectoryPath = new DirectoryInfo(InputFilePath).Root.FullName;
            //WriteLine(rootDirectoryPath);

            //Check if backup dir exixtes
            string inputfileDirectoryPath = Path.GetDirectoryName(InputFilePath);
            WriteLine($"inputfileDirectoryPath = {inputfileDirectoryPath}");


            string backipDirectoryPath = Path.Combine(rootDirectoryPath,BackupDirectoryName);

            if (!Directory.Exists(backipDirectoryPath))
            {
                WriteLine($"Creating backupDirectoryPath = {backipDirectoryPath}");
                Directory.CreateDirectory(backipDirectoryPath);
            }
        }
    }
}