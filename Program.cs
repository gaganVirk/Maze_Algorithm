using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader stdIn = Console.In;
            Console.SetIn(new StreamReader("data.txt"));

            int end;
            int size = int.Parse(Console.ReadLine());
            end = size - 1;
            List<Vertex> vertices = new List<Vertex>();

            for (int i = 0; i < size; i++)
            {
                vertices.Add(new Vertex(i));
            }

            string input = Console.ReadLine();

            while (input != null)
            {
                string[] array = input.Split(' ');
                int enterRoom = int.Parse(array[0]);
                int exitRoom = int.Parse(array[1]);

                vertices[enterRoom].AddNeighbour(vertices[exitRoom]);
                vertices[exitRoom].AddNeighbour(vertices[enterRoom]);
                input = Console.ReadLine();
            }

            List<Vertex> startingList = new List<Vertex>();
            startingList.Add(vertices[0]);

            while (startingList.Count > 0)
            {
                Vertex tmp = startingList[0];
                startingList.RemoveAt(0);
                tmp.Status = 1;

                foreach (var vert in tmp.adj)
                {
                    if (vert.Status == -1)
                    {
                        vert.Parent = tmp;
                        startingList.Add(vert);
                    }
                }
            }

                Stack<Vertex> stack = new Stack<Vertex>();
                Vertex v = vertices[end];

            while (v != null) {
                stack.Push(v);
                v = v.Parent;
            }

            foreach (Vertex v1 in stack)
            {
                Console.Write("{0} ",v1.Id);
            }

            Console.SetIn(stdIn);
            Console.ReadLine();
        }
    }
}
