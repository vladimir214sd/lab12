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
            MyList<Emoji> list = new MyList<Emoji>();
            int answer = 0; 
            while (answer != 9)
            {
                PrintMenu();
                try
                {
                    answer = IO.InputValidNumber(1, 9, "Введите пункт меню: "); // Считываем ответ пользователя
                    switch (answer)
                    {
                        case 1:
                            int size = IO.InputValidNumber(1, 1000, "Введите длину списка: ");
                            list = new MyList<Emoji>(size);
                            Console.WriteLine("Лист успешно создан");
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
                            list.AddToBegin(add);
                            Console.WriteLine("\nЭлемент успешно добавлен в начало!\n");
                            break;
                        case 4:
                            Emoji add2 = new Emoji();
                            add2.Init();
                            list.AddToEnd(add2);
                            Console.WriteLine("\nЭлемент успешно добавлен в конец!\n");
                            break;
                        case 5:
                            Emoji e1 = new Emoji();
                            e1.Init();
                            list.RemoveAllItems(e1);
                            Console.WriteLine("\nВсе элементы успешно удалены!\n");
                            break;
                        case 6:
                            int K = IO.InputValidNumber(1, 100, "Введите кол-во элементов K: ");
                            list.AddKItemsToBeg(K);
                            Console.WriteLine($"{K} случайных элементов успешно добавлены в начало списка!");
                            break;
                        case 7:
                            MyList<Emoji> clonedList = list.DeepClone();
                            Console.WriteLine("Глубокая копия списка успешно создана!");
                            break;
                        case 8:
                            list = null;
                            Console.WriteLine("Список был успешно удален!.");
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
            Console.WriteLine("\nРабота с двунаправленным меню\n" +
                "\n1. Создание коллекции" +
                "\n2. Вывод коллекции" +
                "\n3. Добавить злемент с заданным именем в начало" +
                "\n4. Добавить злемент с заданным именем в конец" +
                "\n5. Удалить все элементы с заданным именем" +
                "\n6. Добавить K случайных элементов в начало списка" +
                "\n7. Выполнить глубокую копию" +
                "\n8. Удалить список из памяти" +
                "\n9. Выход\n");
        }

    }
}