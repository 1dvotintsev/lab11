using CustomLibrary;
using System.Collections;
using System.Collections.Generic;

namespace lab11
{
    public class MyCollection
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАНИЕ 1

            Hashtable hashTable = new Hashtable();
            //Инициализация
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    SmileEmoji e = new SmileEmoji();
                    e.RandomInit();
                    Emoji emoji1 = new Emoji(e.Name, e.Tag, e.id.number);

                    hashTable.Add(emoji1, e);
                }
                catch (Exception e)
                {
                    i--;
                }
            }

            //вывод элементов
            foreach (var item in hashTable.Keys)
            {
                Console.WriteLine($"Ключ: {item}\nЗначение: {hashTable[item]} ");
            }

            //добавление
            Console.WriteLine("Введите элемент для добавления в таблицу");
            SmileEmoji newEmoji = new SmileEmoji();
            newEmoji.Init();
            try
            {
                Emoji key = new Emoji(newEmoji.Name, newEmoji.Tag, newEmoji.id.number);
                hashTable.Add(key, newEmoji);
            }
            catch (Exception e)
            {
                Console.WriteLine("Такой элемент уже есть, добавление невозможно");
            }

            //поиск
            Console.WriteLine("Введите элемент для поиска:");
            Emoji smile = new Emoji();
            smile.Init();

            if (hashTable.ContainsKey(smile))
            {
                Console.WriteLine("Элемент найден");
            }
            else
                Console.WriteLine("Такого элемента нет");

            //удаление
            Console.WriteLine("Введите значение ключа удаляемого элемента");
            Emoji target = new Emoji();
            target.Init();

            if (hashTable.ContainsKey(target))
            {
                hashTable.Remove(target);
                Console.WriteLine("Элемент удален");
            }
            else
                Console.WriteLine("Такого элемента нет");

            //клонирование
            Hashtable deepClone = new Hashtable();

            foreach (var item in hashTable.Keys)
            {
                // Получаем ключ и значение из оригинальной Hashtable
                Emoji originalKey = (Emoji)item;
                SmileEmoji originalValue = (SmileEmoji)hashTable[item];

                // Клонируем ключ и значение
                Emoji clonedKey = (Emoji)originalKey.Clone();
                SmileEmoji clonedValue = (SmileEmoji)originalValue.Clone();

                // Добавляем клонированные объекты в новую Hashtable
                deepClone.Add(clonedKey, clonedValue);
            }

            // Выводим клонированную Hashtable
            Console.WriteLine("Клон:");
            foreach (DictionaryEntry entry in deepClone)
            {
                Console.WriteLine($"Ключ: {entry.Key}\nЗначение: {entry.Value}");
            }

            //сортировка

            /// Создаем копию ключей
            ArrayList keys = new ArrayList(hashTable.Keys);
            // Сортируем список ключей
            keys.Sort();

            // Создаем новую Hashtable для хранения отсортированных элементов
            Hashtable sortedHashTable = new Hashtable();

            // Для каждого отсортированного ключа добавляем значение из исходной Hashtable в новую Hashtable
            foreach (var key in keys)
            {
                sortedHashTable.Add(key, hashTable[key]);
            }

            Console.WriteLine("Сортированная копия Hashtable:");
            foreach (var entry in sortedHashTable.Keys)
            {
                Console.WriteLine($"Ключ: {entry}\nЗначение: {sortedHashTable[entry]}");
            }

            Console.WriteLine(FindCountOfSmile(hashTable));

            Console.WriteLine(PrintSmile(hashTable));

            Console.WriteLine(PrintByName(hashTable));
            //ЗАДАНИЕ 2

            //инициализация
            Queue<Emoji> queue = new Queue<Emoji>();

            for (int i = 0; i < 5; i++)
            {
                SmileEmoji smileEmoji = new SmileEmoji();
                smileEmoji.RandomInit();

                queue.Enqueue(smileEmoji);
            }
            for (int i = 0; i < 5; i++)
            {
                FaceEmoji faceEmoji = new FaceEmoji();
                faceEmoji.RandomInit();

                queue.Enqueue(faceEmoji);
            }
            foreach (Emoji item in queue)
            {
                Console.WriteLine(item);
            }

            //поиск
            Console.WriteLine("введите параметры поиска");
            Emoji find = new Emoji();
            find.Init();

            if (queue.Contains(find))
            {
                Console.WriteLine("такой объект есть");
            }
            else
                Console.WriteLine("Объект не найден");

            //удаление
            Console.WriteLine("введите параметры удаления");
            Emoji target1 = new Emoji();
            Queue<Emoji> temp = new Queue<Emoji>();

            if (queue.Contains(target1))
            {
                foreach (Emoji item in queue)
                {
                    if (item != target1)
                    {
                        temp.Enqueue(item);
                    }
                }
                queue.Clear();

                foreach (Emoji item in temp)
                {
                    queue.Enqueue(item);
                }

            }

            //сортировка

            // Сортируем элементы очереди
            Emoji[] sortedArray = queue.ToArray();
            Array.Sort(sortedArray);

            // Создаем новую очередь с отсортированными элементами
            Queue<Emoji> sortedQueue = new Queue<Emoji>(sortedArray);

            // Выводим отсортированные элементы
            Console.WriteLine("Отсортированная очередь:");
            foreach (var item in sortedQueue)
            {
                Console.WriteLine(item);
            }

            //добавление в лист
            Console.WriteLine("Введите элемент для добавления:");
            Emoji emoji = new Emoji();
            emoji.Init();

            queue.Enqueue(emoji);

            //клонирование
            Queue<Emoji> queueClone = new Queue<Emoji>();
            Queue<Emoji> temp1 = new Queue<Emoji>();

            foreach (var item in queue)
            {
                temp1.Enqueue(item);
            }

            foreach (var item in temp1)
            {
                if (item is SmileEmoji e)
                {
                    SmileEmoji s = (SmileEmoji)e.Clone();
                    queueClone.Enqueue(s);
                }
                if (item is AnimalEmoji a)
                {
                    AnimalEmoji s = (AnimalEmoji)a.Clone();
                    queueClone.Enqueue(s);
                }
                if (item is FaceEmoji f)
                {
                    FaceEmoji s = (FaceEmoji)f.Clone();
                    queueClone.Enqueue(s);
                }
                if (item is Emoji em)
                {
                    Emoji s = (Emoji)em.Clone();
                    queueClone.Enqueue(s);
                }

            }

            //демонстрация

            foreach (var item in queueClone)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(FindCountOfAnimal(queue));

            PrintSmile(queue);

            PrintFaceTag(queue);

            //ЗАДАНИЕ 3

            TestCollections test = new TestCollections();
            Console.WriteLine("ok");

            test.Get1Time();
            Console.WriteLine("");
            test.Get2Time();
            Console.WriteLine("");
            test.Get3Time();
            Console.WriteLine("");
            test.Get4Time();
        }

        //ФУНКЦИИ ЗАДАНИЯ 1

        //подсчет количества улыбающихся смайлов
        static string FindCountOfSmile(Hashtable ht)
        {
            int count = 0;
            foreach (var i in ht.Values)
            {
                if (i is SmileEmoji)
                {
                    count++;
                }
            }
            return ($"В листе {count} улыбыющихся эмоджи");
        }

        //вывод всех улыбающихся со степенью больше 5
        static string PrintSmile(Hashtable ht)
        {
            int count = 0;
            string result = "";
            foreach (var i in ht.Values)
            {
                if (i is SmileEmoji s && s.Grade>=5)
                {
                    result+=s.ToString();
                    count++;
                }
            }
            if (count == 0)
                return "В таблице нет улыбающихся эмоджи со степенью больше 5";
            else
                return result;
        }

        //вывод тэгов улыбающихся со степенью <3
        static string PrintByName(Hashtable ht)
        {
            int count = 0;
            foreach (var i in ht.Values)
            {
                if (i is SmileEmoji e && e.Name == "Улыбашка")
                {
                    Console.WriteLine(e.Tag);
                    count++;
                }
            }
            if (count == 0)
                return "В таблице нет SmileEmoji с именем Улыбашка";
            else
                return $"В таблице {count} SmileEmoji с именем Улыбашка";
        }

        //ФУНКЦИИ ЗАДАНИЯ 2

        //подсчет количества животных
        static string FindCountOfAnimal(Queue<Emoji> queue)
        {
            int count = 0;
            foreach (var i in queue)
            {
                if (i is AnimalEmoji)
                {
                    count++;
                }
            }
            return ($"В листе {count} животных - эмоджи");
        }

        //вывод всех улыбающихся
        static string PrintSmile(Queue<Emoji> list)
        {
            int count = 0;
            string result = "";
            foreach (var i in list)
            {
                if (i is SmileEmoji s)
                {
                    result+= s.ToString();
                    count++;
                }
            }
            if (count == 0)
                return "В листе нет улыбающихся эмоджи.";
            else
                return result;
        }

        //поиск всех тэгов животных
        static string PrintFaceTag(Queue<Emoji> list)
        {
            int count = 0;
            string result = "";
            foreach (var i in list)
            {
                if (i is FaceEmoji)
                {
                    result+=i.Tag + $"\n";
                    count++;
                }
            }
            if (count == 0)
                return "В листе нет FaceEmoji";
            else return result;
        }

       
    }
}
