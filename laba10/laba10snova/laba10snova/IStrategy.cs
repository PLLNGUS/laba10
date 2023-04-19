using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10snova
{
    public interface IStrategy
    {
        int[] Algorithm(int[] mas, bool flag = true);
    }


    abstract public class Sort
    {
        public int iterationCount = 0;
        public int permutationCount = 0;
        public static Form1 form1;
    }


    public class BubbleSort : Sort, IStrategy
    {


        public int[] Algorithm(int[] mas, bool flag = true)
        {

           
            IOFile.FillContent();
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();
            
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length - 1; j++)
                {
                    iterationCount++;
                    IOFile.content += this.iterationCount.ToString() + " итерация: " + '\n';
                    IOFile.InputInfoAboutComparison(mas[i], mas[j]);

                    if (mas[j] > mas[j + 1])
                    {
                        IOFile.InputInfoAboutTransposition(mas[j], mas[j + 1]);
                        temp = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = temp;
                        permutationCount++;
                        IOFile.FillContent();
                        form1.AddItemsRichTextBox(mas[j], mas[j + 1]);


                    }
                }
            }
            
            myStopwatch.Stop();
            var resultTime = myStopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            resultTime.Hours,
            resultTime.Minutes,
            resultTime.Seconds,
            resultTime.Milliseconds);
            form1.label6.Text = Convert.ToString(iterationCount);
            form1.label7.Text = Convert.ToString(permutationCount);
            form1.label8.Text = elapsedTime;
            
            Analys.AnalisSorts.Add(new AnalisSort("Пузырь", mas.Length, iterationCount, permutationCount, elapsedTime));

            return mas;
        }
    }


}
