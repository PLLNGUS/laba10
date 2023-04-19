using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10snova
{
    public static class Analys
    {
        public static List<AnalisSort> AnalisSorts = new List<AnalisSort>();

    }

    public class AnalisSort
    {
        public string name;
        public int size;
        public int iteration;
        public int permutation;
        public string time;

        public AnalisSort(string name, int size, int iteration, int permutation, string time)
        {
            this.name = name;
            this.size = size;
            this.iteration = iteration;
            this.permutation = permutation;
            this.time = time;
        }
    }
}
