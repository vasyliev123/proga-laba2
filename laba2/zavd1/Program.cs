using System;
using Newtonsoft.Json;
namespace zavd1
{
    class Program
    {
        //Скласти опис класу для подання комплексних чисел з можливістю задавання дійсної
        //і уявної частин як числами з типом double, так і цілими числами. Забезпечити
        //виконання операцій додавання, віднімання і множення комплексних чисел.

        //Cтворити у попередньому завданні два методи з використанням серіалізації та десеріалізації JSON. 
        //Метод 1. Зберігає створений об’єкт класу з Завдання 1 у JSON файл
        //Метод 2. Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.

        static void Main(string[] args)
        {
            int a = 99;
            double r = 88.7;
            Complex first = new Complex(r, a);
            Complex second = new Complex(4, -5.9);
            first.Add(second);
            first.Sub(second);
            first.Multi(second);
            //first.Divide(second);
            serialize(first);
            Complex third = deserialize();
            first.Add(third);
        }

        public static void serialize(Complex a)
        {
            string jsonser = JsonConvert.SerializeObject(a);
            System.IO.File.WriteAllText(@"D:\ProgaLabi\laba2\zavd1\serialized.json", jsonser);
        }
        public static Complex deserialize()
        {
            string jsondeser =
            System.IO.File.ReadAllText(@"D:\ProgaLabi\laba2\zavd1\deserialized.json");
            return JsonConvert.DeserializeObject<Complex>(jsondeser);

        }
    }
    class Complex
    {
        public double A;
        public double B;
        public Complex(double a,double b)
        {
            A = a;
            B = b;
        }
        
       
        public void Add(Complex b)
        {
            if (B + b.B >= 0)
                Console.WriteLine($"{A + b.A} + {B + b.B}i");
            else
                Console.WriteLine($"{A + b.A} - {Math.Abs(B + b.B)}i");
        }
        public void Sub(Complex b)
        {
            if(B - b.B>=0)
                Console.WriteLine($"{A - b.A} + {B - b.B}i");
            else
                Console.WriteLine($"{A - b.A} - {Math.Abs(B - b.B)}i");
        }
        public void Multi(Complex b)
        {
            if (A * b.A - B * b.B >= 0)
                Console.WriteLine($"{A * b.A - B * b.B} + {A * b.B + B * b.A}i");
            else
                Console.WriteLine($"{A * b.A - B * b.B} - {Math.Abs(A * b.B + B * b.A)}i");
        }
        /*
        public void Divide(Complex b)
        {
            if (B * b.A - A * b.B >= 0)
                Console.WriteLine($"({A * b.A + B * b.B} + {B * b.A-A * b.B}i)/{Math.Pow(b.A,2)+Math.Pow(b.B,2)}");
            else
                Console.WriteLine($"({A * b.A + B * b.B} - {Math.Abs(B * b.A - A * b.B)}i)/{Math.Pow(b.A, 2) + Math.Pow(b.B, 2)}");

        }

        */
    }
}
