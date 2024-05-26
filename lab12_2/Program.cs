using System.Diagnostics;
using System.Collections;
using System;
using EmojiLibrary;
using System.Diagnostics.CodeAnalysis;

namespace la12
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyHashTable<Emoji> list = new MyHashTable<Emoji>();
            int answer = 0;
            while (answer != 6)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 6, "Введите пункт меню: "); // Считываем ответ пользователя
                    switch (answer)
                    {
                        case 1:
                            list = new MyHashTable<Emoji>();
                            Console.WriteLine("Хэш-таблица успешно создана");
                            break;
                        case 2:
                            if (list == null)
                            {
                                Console.WriteLine("\nСписок пустой\n");
                            }
                            else
                            {
                                list.PrintList();
                            }
                            break;
                        case 3:
                            Emoji add = new Emoji();
                            add.Init();
                            list.AddItem(add);
                            Console.WriteLine("\nЭлемент успешно добавлен!\n");
                            break;
                        case 4:
                            Emoji e1 = new Emoji();
                            e1.Init();
                            list.RemoveItem(e1);
                            break;
                        case 5:
                            Emoji find = new Emoji();
                            find.Init();
                            Console.WriteLine();
                            if (list.FindItem(find))
                                Console.WriteLine("Элемент найден");
                            else
                                Console.WriteLine("Элемент не найден");
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
            Console.WriteLine("\nРабота с хэш-таблицей с открытой адресацией меню\n" +
                "\n1. Создание коллекции" +
                "\n2. Вывод коллекции" +
                "\n3. Добавление элемента" +
                "\n4. Удаление элемента" +
                "\n5. Поиск элемента" +
                "\n6. Выход\n");
        }

    }
}