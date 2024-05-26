using System;

namespace EmojiLibrary
{
    public class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>[] table;
        public int Capacity => table.Length;

        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];

            Random rnd = new Random();
            for (int i = 0; i < length * 0.7; i++) // 70% 
            {
                T randomData = MakeRandomItem();
                AddItem(randomData);
            }
        }

        private int Count()
        {
            return table.Count(p => p != null);
        }

        public void AddItem(T data)
        {
            if ((double)Count() / Capacity >= 0.7)
            {
                ResizeTable(Capacity * 2);
            }

            int index = GetHashIndex(data);
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
            }
            else
            {
                int i = (index + 1) % Capacity;
                while (i != index && table[i] != null)
                {
                    i = (i + 1) % Capacity;
                }
                if (i != index)
                {
                    table[i] = new Point<T>(data);
                }
                else
                {
                    throw new Exception("HashTable is full");
                }
            }
        }
        private void ResizeTable(int newLength)
        {
            Point<T>[] newTable = new Point<T>[newLength];

            foreach (var point in table.Where(p => p != null))
            {
                int index = Math.Abs(point.Data.GetHashCode()) % newLength;
                if (newTable[index] == null)
                {
                    newTable[index] = point;
                }
                else
                {
                    int i = (index + 1) % newLength;
                    while (i != index && newTable[i] != null)
                    {
                        i = (i + 1) % newLength;
                    }
                    if (i != index)
                    {
                        newTable[i] = point;
                    }
                    else
                    {
                        throw new Exception("Hash table is full");
                    }
                }
            }

            table = newTable;
        }



        public bool FindItem(T data)
        {
            int index = GetHashIndex(data);
            if (table == null)
               throw new Exception("empty table");
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
                return true;
            else
            { 
                Point<T>? current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
            }
            return false;
        }
        public void RemoveItem(T data)
        {
            int index = GetHashIndex(data);
            if (table == null)
                throw new Exception("Empty table");
            if (table[index] == null)
                throw new Exception("Item not found");

            if (table[index].Data.Equals(data))
            {
                table[index] = table[index].Next;
                return;
            }

            Point<T> current = table[index];
            while (current.Next != null)
            {
                if (current.Next.Data.Equals(data))
                {
                    current.Next = current.Next.Next;
                    return;
                }
                current = current.Next;
            }

            throw new Exception("Item not found");
        }

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }

        private int GetHashIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public void PrintList()
        {
            for (int i = 0; i < table.Length; i++)
            {
                Console.Write($"{i}: ");
                if (table[i] != null)
                {
                    Console.WriteLine(table[i].Data);
                }
                else
                {
                    Console.WriteLine("empty slot");
                }
            }
        }
    }
}