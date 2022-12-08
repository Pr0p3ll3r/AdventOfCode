using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day07
{
    class Day07
    {
        private class Directory
        {
            public string name = "";
            public int size = 0;
            public Directory outerDirectory;
            public List<Directory> subDirectories;
            public Directory()
            {
            }
            public Directory(string name, int size, Directory outerDirectory, List<Directory> subDirectories)
            {
                this.name = name;
                this.size = size;
                this.outerDirectory = outerDirectory;
                this.subDirectories = subDirectories;
            }
            public void Show()
            {
                Console.WriteLine($"Name: {name} Size: {size}");
                foreach (var item in subDirectories)
                {
                    item.Show();
                }
            }
            public void Sum()
            {
                foreach (var item in subDirectories)
                {
                    item.Sum();
                    size += item.size;
                }
            }
            public void SolvePart1(ref int result)
            {
                if (size <= 100000)
                    result += size;
                foreach (var item in subDirectories)
                {      
                    item.SolvePart1(ref result);
                }
            }
            public void SolvePart2(int neededUnusedSpace, ref Directory directoryToDelete)
            {
                if (size >= neededUnusedSpace && size < directoryToDelete.size)
                    directoryToDelete = this;
                foreach (var item in subDirectories)
                {
                    item.SolvePart2(neededUnusedSpace, ref directoryToDelete);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day07/Day07.txt");
            Directory currentDirectory = new Directory();
            foreach (var line in lines)
            {
                string[] split = line.Split(' ');
                if (split[0] == "$") //if command
                {
                    if (split[1] == "cd") //change directory
                    {
                        if (split[2] == "..") //go to outer directory
                            currentDirectory = currentDirectory.outerDirectory;
                        else if (split[2] == "/") //the outermost directory
                            currentDirectory = new Directory("/", 0, new Directory(), new List<Directory>());
                        else //go to directory "split[2]"
                        {
                            currentDirectory = currentDirectory.subDirectories.Find(x => x.name == split[2]);
                        }
                    }
                }
                else if (split[0] == "dir") //add new subdirectory
                {
                    currentDirectory.subDirectories.Add(new Directory(split[1], 0, currentDirectory, new List<Directory>()));
                }
                else //add size from files
                {
                    currentDirectory.size += int.Parse(split[0]);
                }
            }
            while(currentDirectory.outerDirectory.name != "") //go to the outermost directory
            {
                currentDirectory = currentDirectory.outerDirectory;
            }
            currentDirectory.Sum();
            currentDirectory.Show();
            int result = 0;
            currentDirectory.SolvePart1(ref result);
            Console.WriteLine(result);
            int neededUnusedSpace = 30000000 - (70000000 - currentDirectory.size);
            Directory directoryToDelete = new Directory("", int.MaxValue, new Directory(), new List<Directory>());
            currentDirectory.SolvePart2(neededUnusedSpace, ref directoryToDelete);
            Console.WriteLine(directoryToDelete.size);
        }
    }
}
