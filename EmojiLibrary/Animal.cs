using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmojiLibrary;
using System.Xml.Linq;

namespace EmojiLibrary
{
    public class Animal : Emoji
    {
        protected string partOfBody;
        static string[] BodyParts = { "Голова", "Шея", "Плечо", "Рука", "Грудь", "Живот", "Спина", "Нога", "Стопа", "Палец", "Колено" };

        public Animal() : base()
        {
            PartOfBody = "NoPart";

        }
        public Animal(string name, string tag, string partOfBody) : base(name, tag)
        {
            PartOfBody = partOfBody;
        }


        public string PartOfBody { get; set; }



        public override void Init()
        {
            base.Init();
            Console.Write("Введите часть тела: ");
            PartOfBody = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            PartOfBody = BodyParts[rnd.Next(BodyParts.Length)];
        }
        public override bool Equals(object obj)
        {
            Animal f = obj as Animal;
            if (f != null)
                return f.Name == this.Name
                    && f.Tag == this.Tag
                    && f.PartOfBody == this.PartOfBody;

            else
                return false;
        }
        public override string ToString()
        {
            return Name + ", " + Tag + ", " + PartOfBody;
        }

        public override void Show()
        {
            Console.WriteLine($"Животное эмодзи: Название = {Name}, тэг = {Tag}, часть тела = {PartOfBody}");
        }
        public object Clone()
        {
            return new Animal(Name, Tag, PartOfBody);
        }
        public override int GetHashCode()
        {
            unchecked // Предотвращает переполнение при вычислении хэш-кода
            {
                int hash = 17; // Начальное значение хэш-кода

                // Умножаем на простое число и прибавляем хэш-код каждого свойства
                hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
                hash = hash * 23 + (Tag != null ? Tag.GetHashCode() : 0);

                return hash;
            }

        }
    }
}
