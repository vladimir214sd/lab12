using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmojiLibrary;
using System.Xml.Linq;

namespace EmojiLibrary
{
    public class Face : Emoji
    {
        static string[] Expressions = { ":-)", "^_^", ":-|", "\\o/", "\\o\\", "XD", "<3", ":-D", ":*", "O_o", ":-P", ":-)" };

        public Face() : base()
        {
            Power = 0;
            Expression = ":)";

        }
        public Face(string name, string tag, double power, string expression) : base(name, tag)
        {
            Power = power;
            Expression = expression;
        }


        protected double power;
        protected string expression;

        public string Expression { get; set; }
        public double Power
        {
            get => power;
            set
            {
                if (value < 0)
                    power = 0;
                else if (value > 10)
                    power = 10;
                else
                    power = value;
            }
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите описание символами: ");
            Expression = Console.ReadLine();
            Power = IO.InputValidNumber(0, 10, "Введите силу эмодзи(от 0 до 10): ");

        }
        public override void RandomInit()
        {
            base.RandomInit();
            Expression = Expressions[rnd.Next(Expressions.Length)];
            Power = rnd.Next(0, 11);
        }
        public override bool Equals(object obj)
        {
            Face f = obj as Face;
            if (f != null)
                return f.Name == this.Name
                    && f.Tag == this.Tag
                    && f.Power == this.Power
                    && f.Expression == this.Expression;
            else
                return false;
        }
        public override string ToString()
        {
            return Name + ", " + Tag + ", " + Power + ", " + Expression;
        }

        public override void Show()
        {
            Console.WriteLine($"Лицевое эмодзи: Название = {Name}, тэг = {Tag}, сила эмодзи = {Power}, описание символами = {Expression}");
        }
        public object Clone()
        {
            return new Face(Name, Tag, Power, Expression);
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
        public Emoji GetBase
        {
            get => new Emoji(Name, Tag);//возвращает объект базового класса
        }

    }
}
