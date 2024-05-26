using System.Diagnostics;
using System.Collections;
using System;
using EmojiLibrary;
using System.Diagnostics.CodeAnalysis;

namespace la12
{
    public class Program
    {
        static bool isListCreated;
        static void Main(string[] args)
        {
            MyCollection<Emoji> list = new MyCollection<Emoji>();
            MyCollection<Emoji> copied = new MyCollection<Emoji>();
            int answer = 0;
            while (answer != 12)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 12, "Введите пункт меню: "); // Считываем ответ пользователя
                    switch (answer)
                    {
                        case 1:
                            int length = IO.InputValidNumber(0, 30, "Введите кол-во элементов в коллекции: ");
                            list = new MyCollection<Emoji>(length);
                            isListCreated = true;
                            Console.WriteLine("Коллекция успешно создана");
                            break;
                        case 2:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                foreach(Emoji e in list)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                            break;
                        case 3:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                copied = new MyCollection<Emoji>(list);
                                foreach (Emoji e in copied)
                                { Console.WriteLine(e); }
                            }
                            break;
                        case 4:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Emoji add = new Emoji();
                                add.Init();
                                list.Add(add);
                                Console.WriteLine("Элемент успешно добавлен");
                            }
                            break;
                        case 5:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Console.Write("Введите индекс элемента, который хотите удалить: ");
                                int indexToRemove = int.Parse(Console.ReadLine());
                                try
                                {
                                    list.RemoveAt(indexToRemove);
                                    Console.WriteLine("Элемент успешно удален");
                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            break;
                        case 6:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Console.Write("Введите элемент для поиска: ");
                                Emoji itemToFind = new Emoji();
                                itemToFind.Init();
                                int index = list.IndexOf(itemToFind);
                                if (index != -1)
                                {
                                    Console.WriteLine($"Элемент найден на позиции {index}");
                                }
                                else
                                {
                                    Console.WriteLine("Элемент не найден");
                                }
                            }
                            break;
                        case 7:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Console.Write("Введите элемент для удаления: ");
                                Emoji itemToRemove = new Emoji();
                                itemToRemove.Init(); 
                                list.Remove(itemToRemove);
                                Console.WriteLine("Все элементы с заданным значением успешно удалены из коллекции");
                            }
                            break;
                        case 8:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                list.Clear();
                            }
                            break;
                        case 9:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Emoji contains = new Emoji();
                                contains.Init(); 
                                Console.WriteLine(list.Contains(contains));
                            }
                            break;
                        case 10:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Emoji indexOf = new Emoji();
                                indexOf.Init();
                                Console.WriteLine(list.IndexOf(indexOf));
                            }
                            break;
                        case 11:
                            if (!isListCreated || list == null)
                            {
                                Console.WriteLine("\nКоллекция пустая или не существует\n");
                            }
                            else
                            {
                                Emoji insert = new Emoji();
                                insert.Init();
                                int insertIndex = IO.InputValidNumber(1, list.Count, "Введите позицию для вставки элемента: ");
                                list.Insert(insertIndex, insert);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("\nРабота с коллекцией\n" +
                "\n1. Создание коллекции" +
                "\n2. Вывод колекции" +
                "\n3. Скопировать коллекцию и вывести на экран" +
                "\n4. Добавить элемент в коллекцию" +
                "\n5. Удалить элемент по индексу" +
                "\n6. Поиск элемента" + 
                "\n7. Удалить элемент" +
                "\n8. Очистить коллекцию" +
                "\n9. Узнать входит ли элемент в коллекцию" +
                "\n10. Узнать позицию элемента в коллекции" +
                "\n11. Вставить элемент в коллекцию на определенную позицию" +
                "\n12. Выход\n");
        }

    }
}