﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assembler.UnitTests
{
    [TestClass]
    public class FileManagerTest
    {
        private readonly string workingDir = Environment.GetFolderPath(
                         System.Environment.SpecialFolder.DesktopDirectory);

        private string GetFullPath(string fileName)
        {
            return System.IO.Path.Combine(workingDir, fileName);
        }

        [TestMethod]
        public void FileManagerTester_WriteFile_Success()
        {
            var textLines = new string[] { "Hello", "World" };

            string filePath = GetFullPath("mock.txt");

            Console.WriteLine(filePath);

            var result = FileManager.Instance.ToWriteFile(filePath, textLines);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FileManagerTester_WriteFile_Error()
        {
            var result = FileManager.Instance.ToWriteFile(GetFullPath("mock.txt"), null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FileManagerTester_ReadFile_Success()
        {
            var textLines = new string[] { "Hello", "World" };

            FileManager.Instance.ToWriteFile(GetFullPath("mock.txt"), textLines);

            var readLines = FileManager.Instance.ToReadFile(
                GetFullPath("mock.txt")
            );

            foreach(string line in readLines)
            {
                Console.WriteLine(line);
            }

            Assert.IsNotNull(readLines);
        }

        [TestMethod]
        public void FileManagerTester_ReadFile_Error()
        {
            var readLines = FileManager.Instance.ToReadFile(null);

            Assert.IsNull(readLines);
        }

        [TestMethod]
        public void FileManagerTester_WriteWritable_Success()
        {

            AssemblyLogger logger = new AssemblyLogger();

            string txt = "Started Parsing.";
            string msg = "Memory Overwrite";
            string adrs = "0x45";
            string old = "3524";
            string line = "54";

            logger.StatusUpdate(txt);
            logger.Warning(msg, line, adrs, old);
            logger.Error("Wrong syntax", "34", "JUMP");

            var result = FileManager.Instance.ToWriteFile(logger, workingDir);

            Console.WriteLine(result);

            Assert.IsTrue(result);

            string filepath = System.IO.Path.Combine(workingDir, logger.FileName);

            string[] logLines = FileManager.Instance.ToReadFile(filepath);

            Assert.AreEqual(4, logLines.Length);

            foreach (string log in logLines)
                Console.WriteLine(log);
        }
    }
}