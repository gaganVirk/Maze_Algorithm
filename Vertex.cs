using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Algorithm
{
    class Vertex
    {
        public int Id { get; set; }
        public Vertex Parent { get; set; }
        public int Status { get; set; }

        public List<Vertex> adj = new List<Vertex>();
        public Vertex(int id)
        {
            Id = id;
            Parent = null;
            Status = -1;
        }

        public void AddNeighbour(Vertex other)
        {
            adj.Add(other);
        }
    }
}
