using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using EmojiLibrary;
using System.Xml.Linq;

namespace EmojiLibrary
{
    public class Smiling : Face
    {
        protected string smileReason;

        static string[] SmileReasons = { "Хорошая погода", "Хороший настрой", "Успешный день", "Приятное общение", "Праздничное настроение", "Успех в работе", "Хорошие новости", "Вдохновляющий проект", "Творческий успех", "Успешный трудовой день", "Позитивные эмоции" };
        public Smiling() : base()
        {
            SmileReason = "NoReason";
        }


        public Smiling(string name, string tag, double power, string expression, string smileReason) : base(name, tag, power, expression)
        {
            SmileReason = smileReason;
        }

        public string SmileReason { get; set; }


        public override string ToString()
        {
            return Name + ", " + Tag + ", " + Power + ", " + Expression + ", " + SmileReason;
        }

        public override void Show()
        {
            Console.WriteLine($"Улыбающееся эмодзи: Название = {Name}, тэг = {Tag}, сила эмодзи = {Power}, описание символами = {Expression}, причина улыбки = {SmileReason}");
        }

        public override void Init()
        {
            base.Init();
            Console.Write("Введите причину улыбки: ");
            SmileReason = Console.ReadLine();
        }
        public override bool Equals(object obj)
        {
            Smiling f = obj as Smiling;
            if (f != null)
                return f.Name == this.Name
                    && f.Tag == this.Tag
                    && f.Power == this.Power
                    && f.Expression == this.Expression
                    && f.SmileReason == this.SmileReason;
            else
                return false;
        }
        public override void RandomInit()
        {
            base.RandomInit();
            SmileReason = SmileReasons[rnd.Next(SmileReasons.Length)];
        }
        public object Clone()
        {
            return new Smiling(Name, Tag, Power, Expression, SmileReason);
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
