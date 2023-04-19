using System;
using System.Collections;
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
        public int iteration;
        public int perestanovka;
        public static Form1 form;
    }
    public class BubbleSort : Sort, IStrategy
    {
        public int[] Algorithm(int[] mas, bool flag = true)
        {
            if (flag)
            {
                IOFile.FillContent();
                System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                myStopwatch.Start();
                int temp;
                for (int i = 0; i < mas.Length; i++)
                {
                    for (int j = i + 1; j < mas.Length; j++)
                    {
                        this.iteration++;
                        IOFile.content += this.iteration.ToString() + " итерация: " + '\n';
                        IOFile.InputInfoAboutComparison(mas[i], mas[j]);
                        iteration++;
                        if (mas[i] > mas[j])
                        {
                            IOFile.InputInfoAboutTransposition(mas[i], mas[j]);
                            temp = mas[i];
                            mas[i] = mas[j];
                            mas[j] = temp;
                            perestanovka++;
                            IOFile.FillContent();
                            form.AddItemsRichTextBox(mas[i], mas[j]);
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
                form.textBox1.Text = Convert.ToString(iteration);
                form.textBox2.Text = Convert.ToString(perestanovka);
                form.textBox3.Text = elapsedTime;
                AnalisSort analis = new AnalisSort("Пузырьковая", iteration, perestanovka, mas.Length, elapsedTime);
                Analys.AnalisSorts.Add(analis);
                return mas;
            }
            return null;
        }
    }
    public class Porazrad : Sort, IStrategy
    {
        public int iterationCount = 0;
        public int[] Algorithm(int[] mas, bool flag = true)
        {
            if (flag)
            {
                {
                    IOFile.FillContent();
                    System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
                    myStopwatch.Start();
                    int temp;
                    ArrayList[] lists = new ArrayList[10];
                    for (int i = 0; i < 10; ++i)
                        lists[i] = new ArrayList();
                    for (int step = 0; step < 4; ++step)
                    {
                        //распределение по спискам
                        for (int i = 0; i < mas.Length; ++i)
                        {
                            temp = (mas[i] % (int)Math.Pow(10, step + 1)) / (int)Math.Pow(10, step);
                            lists[temp].Add(mas[i]);
                            iteration++;
                            perestanovka++;
                            //form.AddItemsRichTextBox((int)lists[temp][step]);

                        }
                        //сборка
                        int k = 0;
                        for (int i = 0; i < 10; ++i)
                        {

                            for (int j = 0; j < lists[i].Count; ++j)
                            {
                                mas[k++] = (int)lists[i][j];

                                //iteration++;
                            }
                        }
                        form.AddItemsRichTextBox();
                        for (int i = 0; i < 10; ++i)
                            lists[i].Clear();
                    }

                    myStopwatch.Stop();
                    var resultTime = myStopwatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                    resultTime.Hours,
                    resultTime.Minutes,
                    resultTime.Seconds,
                    resultTime.Milliseconds);
                    form.textBox1.Text = Convert.ToString(iteration);
                    form.textBox2.Text = Convert.ToString(perestanovka);
                    form.textBox3.Text = elapsedTime;
                    AnalisSort analis = new AnalisSort("Поразрядная", iteration, perestanovka, mas.Length, elapsedTime);
                    Analys.AnalisSorts.Add(analis);
                    return mas;
                }

            }
            return null;
        }

    }

}
