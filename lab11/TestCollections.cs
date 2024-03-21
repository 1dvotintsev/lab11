using CustomLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace lab11
{
    internal class TestCollections
    {
        public Stack<Emoji> stack1;
        public Stack<string> stack2;
        public Dictionary<Emoji, AnimalEmoji> dictionary1;
        public Dictionary<string, AnimalEmoji> dictionary2;

        public TestCollections()
        {
            stack1 = new Stack<Emoji>();
            stack2 = new Stack<string>();
            dictionary1 = new Dictionary<Emoji, AnimalEmoji>();
            dictionary2 = new Dictionary<string, AnimalEmoji>();

            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    AnimalEmoji animalEmoji = new AnimalEmoji();
                    animalEmoji.RandomInit();
                    Emoji emoji = new Emoji(animalEmoji.Name, animalEmoji.Tag, animalEmoji.id.number);
                    dictionary1.Add(emoji, animalEmoji);
                    dictionary2.Add(emoji.ToString(), animalEmoji);
                    stack1.Push(animalEmoji);
                    stack2.Push(animalEmoji.ToString());
                }
                catch(Exception e)
                {
                    i--;
                }
            }
        }

        public double AveregeStackTime(string element)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long all = 0;

            for (int i = 0; i < 1000; i++)
            {
                sw.Restart();
                this.stack2.Contains(element);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            return (double)all / 1000;
        }

        public double AveregeStackTime(Emoji element)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long all = 0;

            for (int i = 0; i < 1000; i++)
            {
                sw.Restart();
                this.stack1.Contains(element);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            return (double)all / 1000;
        }

        public double AveregeDictionaryTime(Emoji element)
        {
            long all = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                sw.Restart();
                dictionary1.ContainsKey(element);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            return (double)all / 1000;
        }

        public double AveregeDictionaryTime(string element)
        {
            long all = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                sw.Restart();
                dictionary2.ContainsKey(element);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            return (double)all / 1000;
        }

        public double AveregeDictionaryTimeV(AnimalEmoji element)
        {
            long all = 0;
            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
            {
                sw.Restart();
                dictionary1.ContainsValue(element);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            return (double)all / 1000;
        }

        public void Get1Time()
        {
            // Получение первого элемента (последнего добавленного элемента)
            Emoji firstElement = (Emoji)stack1.Peek().Clone();

            // Получение последнего элемента (первого добавленного элемента)
            Emoji lastElement = (Emoji)stack1.ToArray()[0].Clone();

            // Получение центрального элемента
            Emoji centralElement = (Emoji)stack1.ToArray()[stack1.Count / 2].Clone();

            long all = 0;

            Console.WriteLine("Время поиска (среднее за 1000 замеров) в стеке 1");
            Console.WriteLine($"Первый найден за {this.AveregeStackTime(firstElement)}");
            Console.WriteLine($"Последний найден за {this.AveregeStackTime(lastElement)}");
            Console.WriteLine($"Средний найден за {this.AveregeStackTime(centralElement)}");
        }

        public void Get2Time()
        {
            // Получение первого элемента (последнего добавленного элемента)
            string firstElement = (string)stack2.Peek();

            // Получение последнего элемента (первого добавленного элемента)
            string lastElement = (string)stack2.ToArray()[0];

            // Получение центрального элемента
            string centralElement = (string)((stack2.ToArray()[stack2.Count / 2]));


            Console.WriteLine("Время поиска (среднее за 1000 замеров) в стеке 2");
            Console.WriteLine($"Первый найден за {this.AveregeStackTime(firstElement)}");
            Console.WriteLine($"Последний найден за {this.AveregeStackTime(lastElement)}");
            Console.WriteLine($"Средний найден за {this.AveregeStackTime(centralElement)}");
        }

        public void Get3Time()
        {
            Emoji firstKey = (Emoji)dictionary1.Keys.FirstOrDefault().Clone();
            Emoji lastKey = (Emoji)dictionary1.Keys.LastOrDefault().Clone();
            Emoji midKey = (Emoji)dictionary1.Keys.ElementAt(dictionary1.Count/2).Clone();

            AnimalEmoji firstValue = (AnimalEmoji)dictionary1[firstKey].Clone();
            AnimalEmoji lastValue = (AnimalEmoji)dictionary1[lastKey].Clone();
            AnimalEmoji midValue = (AnimalEmoji)dictionary1[midKey].Clone();    

            Console.WriteLine("Среднее время поиска по ключу(1000 замеров) в словаре 1:");
            Console.WriteLine($"Первый ключ найден за {this.AveregeDictionaryTime(firstKey)}");
            Console.WriteLine($"Последний ключ найден за {this.AveregeDictionaryTime(lastKey)}");
            Console.WriteLine($"В середине ключ найден за {this.AveregeDictionaryTime(midKey)}");
            Console.WriteLine($"Первое значение найдено за {this.AveregeDictionaryTimeV(firstValue)}");
            Console.WriteLine($"Последнее значение найдено за {this.AveregeDictionaryTimeV(lastValue)}");
            Console.WriteLine($"Среднее значение найдено за {this.AveregeDictionaryTimeV(midValue)}");
        }

        public void Get4Time()
        {
            string firstKey = dictionary2.Keys.FirstOrDefault().ToString();
            string lastKey = dictionary2.Keys.LastOrDefault().ToString();
            string midKey = dictionary2.Keys.ElementAt(dictionary1.Count / 2).ToString();

            AnimalEmoji firstValue = (AnimalEmoji)dictionary2[firstKey].Clone();
            AnimalEmoji lastValue = (AnimalEmoji)dictionary2[lastKey].Clone();
            AnimalEmoji midValue = (AnimalEmoji)dictionary2[midKey].Clone();

            Console.WriteLine("Среднее время поиска по ключу(1000 замеров) в словаре 1:");
            Console.WriteLine($"Первый ключ найден за {this.AveregeDictionaryTime(firstKey)}");
            Console.WriteLine($"Последний ключ найден за {this.AveregeDictionaryTime(lastKey)}");
            Console.WriteLine($"В середине ключ найден за {this.AveregeDictionaryTime(midKey)}");
            Console.WriteLine($"Первое значение найдено за {this.AveregeDictionaryTimeV(firstValue)}");
            Console.WriteLine($"Последнее значение найдено за {this.AveregeDictionaryTimeV(lastValue)}");
            Console.WriteLine($"Среднее значение найдено за {this.AveregeDictionaryTimeV(midValue)}");

        }
    }
}
