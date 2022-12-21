using AdventOfCode.Day19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AdventOfCode.Day20
{
    class Day20
    {
        static LinkedListNode<(int, long)> GetNodeByIndex(LinkedList<(int, long)> list, long index)
        {
            LinkedListNode<(int, long)> node = list.First;
            while (node.Value.Item1 != index)
            {
                if (node.Next == null)
                    node = list.First;
                else
                    node = node.Next;
            }
            return node;
        }

        static LinkedListNode<(int, long)> GetNodeByValue(LinkedList<(int, long)> list, long value)
        {
            LinkedListNode<(int, long)> node = list.First;
            while (node.Value.Item2 != value)
            {
                if (node.Next == null)
                    node = list.First;
                else
                    node = node.Next;
            }
            return node;
        }

        static LinkedListNode<(int, long)> GetPreviousNode(LinkedList<(int, long)> list, LinkedListNode<(int, long)> startNode, long position)
        {
            LinkedListNode<(int, long)> node = startNode;
            position = Math.Abs(position);
            while (position > 0)
            {
                if (node.Previous == null)
                    node = list.Last;
                else
                    node = node.Previous;
                if(startNode != node)
                    position--;
            }
            return node;
        }

        static LinkedListNode<(int, long)> GetNextNode(LinkedList<(int, long)> list, LinkedListNode<(int, long)> startNode, long position)
        {
            LinkedListNode<(int, long)> node = startNode;
            while (position > 0)
            {
                if (node.Next == null)
                    node = list.First;
                else
                    node = node.Next;
                if (startNode != node)
                    position--;
            }
            return node;
        }

        static long GetValue(LinkedList<(int, long)> list, LinkedListNode<(int, long)> node, int position)
        {
            while (position > 0)
            {
                if (node.Next == null)
                    node = list.First;
                else
                    node = node.Next;
                position--;
            }
            return node.Value.Item2;
        }

        static void Mix(ref LinkedList<(int, long)> decryptedFile, List<long> encryptedFile)
        {
            for (int i = 0; i < encryptedFile.Count; i++)
            {
                if (encryptedFile[i] == 0)
                    continue;

                LinkedListNode<(int, long)> currentNode = GetNodeByIndex(decryptedFile, i);
                LinkedListNode<(int, long)> prevNodeNewPos;
                if (encryptedFile[i] > 0)
                    prevNodeNewPos = GetNextNode(decryptedFile, currentNode, encryptedFile[i] % (encryptedFile.Count - 1));
                else
                    prevNodeNewPos = GetPreviousNode(decryptedFile, currentNode, (encryptedFile[i] - 1) % (encryptedFile.Count - 1));
                decryptedFile.Remove(currentNode);
                LinkedListNode<(int, long)> newNode = new LinkedListNode<(int, long)>((i, encryptedFile[i]));
                decryptedFile.AddAfter(prevNodeNewPos, newNode);
            }
        }

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../Day20/Day20.txt");
            List<long> encryptedFile = new List<long>();
            LinkedList<(int index, long value)> decryptedFile = new LinkedList<(int index, long value)>();
            foreach (var line in lines)
            {
                encryptedFile.Add(int.Parse(line));
            }
            for (int i = 0; i < encryptedFile.Count; i++)
            {
                decryptedFile.AddLast((i, encryptedFile[i]));
            }
            Mix(ref decryptedFile, encryptedFile);
            LinkedListNode<(int, long)> nodeWithZero = GetNodeByValue(decryptedFile, 0);
            long sum = GetValue(decryptedFile, nodeWithZero, 1000) + GetValue(decryptedFile, nodeWithZero, 2000) + GetValue(decryptedFile, nodeWithZero, 3000);
            Console.WriteLine(sum);

            int decryptionKey = 811589153;
            List<long> encryptedFile2 = new List<long>();
            LinkedList<(int index, long value)> decryptedFile2 = new LinkedList<(int index, long value)>();          
            foreach (var line in lines)
            {
                encryptedFile2.Add((long.Parse(line) * decryptionKey));
            }
            for (int i = 0; i < encryptedFile2.Count; i++)
            {
                decryptedFile2.AddLast((i, encryptedFile2[i]));
            }
            for (int i = 0; i < 10; i++)
            {
                Mix(ref decryptedFile2, encryptedFile2);
            }
            nodeWithZero = GetNodeByValue(decryptedFile2, 0);
            sum = (GetValue(decryptedFile2, nodeWithZero, 1000) + GetValue(decryptedFile2, nodeWithZero, 2000) + GetValue(decryptedFile2, nodeWithZero, 3000));
            Console.WriteLine(sum);
        }
    }
}
