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
            for (int i = 0; i < 1000; i++)
            {
                AnimalEmoji e = new AnimalEmoji();
                e.RandomInit();
                stack1.Push(e);
            }

            stack2 = new Stack<string>();
            for (int i = 0; i < 1000; i++)
            {
                AnimalEmoji e = new AnimalEmoji();
                e.RandomInit();
                stack2.Push(e.ToString());
            }

            dictionary1 = new Dictionary<Emoji, AnimalEmoji>();
            for(int i = 0;i < 1000; i++)
            {
                try
                {
                    AnimalEmoji animalEmoji = new AnimalEmoji();
                    animalEmoji.RandomInit();
                    Emoji emoji = new Emoji(animalEmoji.Name, animalEmoji.Tag, animalEmoji.id.number);
                    dictionary1.Add(emoji, animalEmoji);
                }
                catch(Exception ex)
                {
                    i--;
                }
            }

            dictionary2 = new Dictionary<string, AnimalEmoji>();
            for (int i = 0; i < 1000; i++)
            {
                try
                {
                    AnimalEmoji animalEmoji = new AnimalEmoji();
                    animalEmoji.RandomInit();
                    Emoji emoji = new Emoji(animalEmoji.Name, animalEmoji.Tag, animalEmoji.id.number);
                    dictionary2.Add(emoji.ToString(), animalEmoji);
                }
                catch (Exception ex)
                {
                    i--;
                }
            }
        }

        public void Get1Time()
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Получение первого элемента (последнего добавленного элемента)
            Emoji firstElement = stack1.Peek();

            // Получение последнего элемента (первого добавленного элемента)
            Emoji lastElement = stack1.ToArray()[0];

            // Получение центрального элемента
            Emoji centralElement = stack1.ToArray()[stack1.Count / 2];

            long all = 0;

            Console.WriteLine("Время поиска (среднее за 100 замеров) в стеке 1");

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack1.Contains(firstElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Первый найден за {(double)all / 100}");
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack1.Contains(lastElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Последний найден за {(double)all / 100}");
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack1.Contains(lastElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Средний найден за {(double)all / 100}");
        }

        public void Get2Time()
        {
            Stopwatch sw = Stopwatch.StartNew();

            // Получение первого элемента (последнего добавленного элемента)
            string firstElement = stack2.Peek();

            // Получение последнего элемента (первого добавленного элемента)
            string lastElement = stack2.ToArray()[0];

            // Получение центрального элемента
            string centralElement = stack2.ToArray()[stack1.Count / 2];

            long all = 0;

            Console.WriteLine("Время поиска (среднее за 100 замеров) в стеке 2");

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack2.Contains(firstElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Первый найден за {(double)all / 100}");
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack2.Contains(lastElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Последний найден за {(double)all / 100}");
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();
                stack2.Contains(lastElement);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            Console.WriteLine($"Средний найден за {(double)all / 100}");
        }

        public void Get3Time()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Emoji firstKey = dictionary1.Keys.FirstOrDefault();
            Emoji lastKey = dictionary1.Keys.LastOrDefault();
            Emoji midKey = dictionary1.Keys.ElementAt(dictionary1.Count/2);
            long all = 0;
            bool ok1 = true;

            Console.WriteLine("Среднее время поиска по ключу(100 замеров) в словаре 1:");

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary1.ContainsKey(firstKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            if (ok1)
            {
                Console.WriteLine($"Первый найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"Первый не найден за {(double)all / 100}");
            }
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary1.ContainsKey(lastKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            if (ok1)
            {
                Console.WriteLine($"Последний найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"Последний не найден за {(double)all / 100}");
            }
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary1.ContainsKey(midKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            if (ok1)
            {
                Console.WriteLine($"В середине найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"В середине не найден за {(double)all / 100}");
            }

        }

        

        public void Get4Time()
        {
            Stopwatch sw = Stopwatch.StartNew();
            string firstKey = ((Emoji)dictionary1.Values.FirstOrDefault()).ToString();
            string lastKey = ((Emoji)dictionary1.Values.LastOrDefault()).ToString();
            string midKey = ((Emoji)dictionary1.Values.ElementAt(dictionary1.Count / 2)).ToString();
            long all = 0;
            bool ok1 = true;

            Console.WriteLine("Среднее время поиска по ключу(100 замеров) в словаре 2:");

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary2.ContainsKey(firstKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }

            if (ok1)
            {
                Console.WriteLine($"Первый найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"Первый не найден за {(double)all / 100}");
            }
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary2.ContainsKey(lastKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            if (ok1)
            {
                Console.WriteLine($"Последний найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"Последний не найден за {(double)all / 100}");
            }
            all = 0;

            for (int i = 0; i < 100; i++)
            {
                sw.Restart();

                // Проверяем наличие первого ключа в словаре
                ok1 = dictionary2.ContainsKey(midKey);
                sw.Stop();

                all += sw.ElapsedTicks; ;
            }
            if (ok1)
            {
                Console.WriteLine($"В середине найден за {(double)all / 100}");
            }
            else
            {
                Console.WriteLine($"В середине не найден за {(double)all / 100}");
            }

        }
    }
}
