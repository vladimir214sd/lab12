using System.Diagnostics;
using System.Collections;
using System;
using EmojiLibrary;
using System.Diagnostics.CodeAnalysis;

namespace la12
{
    public class Program
    {
        static bool isTreeCreated;
        static bool isFindTreeCreated = false;
        static void Main(string[] args)
        {
            MyTree<Emoji> list = new MyTree<Emoji>(0);
            MyTree<Emoji> findTree = new MyTree<Emoji>(0);
            int answer = 0;
            while (answer != 8)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 8, "Введите пункт меню: "); // Считываем ответ пользователя
                    switch (answer)
                    {
                        case 1:
                            int length = IO.InputValidNumber(0, 30, "Введите кол-во элементов бинарного дерева: ");
                            list = new MyTree<Emoji>(length);
                            isTreeCreated = true;
                            Console.WriteLine("ИС дерево успешно создано");
                            break;
                        case 2:
                            if (!isTreeCreated || list == null)
                                {
                                Console.WriteLine("\nДерево пустое или не существует\n");
                            }
                            else
                            {
                                list.ShowTree();
                            }
                            break;
                        case 3:
                            if (!isTreeCreated || list == null)
                            {
                                Console.WriteLine("\nДерево пустое или не существует\n");
                            }
                            else
                            {
                                Console.WriteLine($"\nВысота дерева: {list.TreeHeight()}\n");
                            }
                            
                            break;
                        case 4:
                            if (!isTreeCreated || list == null)
                            {
                                Console.WriteLine("\nДерево пустое или не существует\n");
                            }
                            else
                            {
                                findTree = list.CloneTree();
                                findTree.TransformToBinarySearchTree();
                                isFindTreeCreated = true;
                                Console.WriteLine("Дерево поиска успешно создано");
                            }
                            break;
                        case 5:
                            if (!isFindTreeCreated || findTree == null)
                            {
                                Console.WriteLine("\nДерево поиска пустое или не существует\n");
                            }
                            else
                            {
                                findTree.ShowTree();
                            }
                            break;
                        case 6:

                            if (!isFindTreeCreated || findTree == null)
                            {
                                Console.WriteLine("\nДерево поиска пустое или не существует\n");
                            }
                            else
                            {
                                Emoji e = new Emoji();
                                e.Init();
                                findTree.Remove(e);
                            }
                            break;
                        case 7:
                            if (!isTreeCreated || list == null)
                            {
                                Console.WriteLine("\nДерево пустое или не существует\n");
                            }
                            else
                            {
                                list = null;
                                isTreeCreated = false;
                                Console.WriteLine("ИС дерево успешно удалено");
                            }

                            if (!isFindTreeCreated || findTree == null)
                            {
                                Console.WriteLine("\nДерево поиска пустое или не существует\n");
                            }
                            else
                            {
                                findTree = null;
                                isFindTreeCreated = false;
                                Console.WriteLine("Дерево поиска успешно удалено");
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
            Console.WriteLine("\nРабота с бинарным деревом\n" +
                "\n1. Создание дерева" +
                "\n2. Вывод ИС дерева" +
                "\n3. Узнать высоту дерева" +
                "\n4. Создать дерево поиска из ИС дерева" +
                "\n5. Вывести дерево поиска" +
                "\n6. Удалить из дерева поиска элемент с заданным ключом" +
                "\n7. Удалить оба дерева из памяти" +
                "\n8. Выход\n");
        }

    }
}