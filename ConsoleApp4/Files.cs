using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Globalization;

[Serializable]
public struct toys
{
    public string Name;
    public int Price;
    public int Minage;
    public int Maxage;
    public toys(string name, int price, int minage, int maxage)
    {
        Name = name;
        Price = price;
        Minage = minage;
        Maxage = maxage;
    }
}

class Files
{
    static Random R = new Random();
    //Задание 4
    public static void first()
    {
        string input = "input.bin";
        string output = "output.bin";
        using (FileStream f = new FileStream(input, FileMode.OpenOrCreate))
        {
            BinaryWriter file = new BinaryWriter(f);
            int n = R.Next(5, 20);
            Console.WriteLine("Входной файл: ");
            for (int i = 0; i < n; i++)
            {
                int a = R.Next(0, 10);
                Console.Write(a + "\t");
                file.Write(a);
            }
            Console.WriteLine();
        }
        string[] lines = File.ReadAllLines(input);
        int[] numbers;
        using (FileStream fs = new FileStream(input, FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                numbers = new int[fs.Length / sizeof(int)];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = reader.ReadInt32();
                }
            }
        }
        int[] result = new int[numbers.Length - 1];
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            result[i] = numbers[i] * numbers[i + 1];
        }
        using (FileStream fs = new FileStream(output, FileMode.Create))
        {
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (int i in result)
                {
                    writer.Write(i);
                }
            }
        }

        using (FileStream fs = new FileStream(output, FileMode.Open))
        {
            using (BinaryReader reader = new BinaryReader(fs))
            {
                Console.WriteLine("Выходной файл: ");
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.Write(number + "\t");
                }
                Console.WriteLine();
            }
        }
    }
    //задание 5
    public static void TouchToysFile()
    {
        toys[] toy = new toys[]
        {
            new toys { Name = "Конструктор", Price = 1500, Minage = 2, Maxage = 5 },
            new toys { Name = "Кубики", Price = 800, Minage = 1, Maxage = 3 },
            new toys { Name = "Пазлы", Price = 1200, Minage = 3, Maxage = 6 },
            new toys { Name = "Лего", Price = 2000, Minage = 5, Maxage = 10 }
        };

        using (FileStream fs = new FileStream("toys.xml", FileMode.Create))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(toys[]));
            serializer.Serialize(fs, toy);
        }
    }
    public static void readtoys()
    {
        toys[] toy;
        using (FileStream fs = new FileStream("toys.xml", FileMode.Open))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(toys[]));
            toy = (toys[])serializer.Deserialize(fs);
        }
        foreach (toys i in toy)
        {
            if (i.Name == "Конструктор")
            {
                Console.WriteLine($"Конструктор предназначен для детей от {i.Minage} до {i.Maxage}");
            }
        }
    }
    public static void zapforsix()
    {
        string input2 = "input6.txt";
        using (FileStream f = new FileStream(input2, FileMode.OpenOrCreate))
        {
            using (StreamWriter ff = new StreamWriter(f))
            {
                int a = R.Next(10, 30);
                for (int i = 0; i < a; i++)
                {
                    int k = R.Next(10, 1000);
                    ff.WriteLine(k);
                }
            }
        }
    }
    public static void six()
    {
        string input = "input6.txt";
        string output = "output6.txt";
        using (StreamReader reader = new StreamReader(input))
        using (StreamWriter writer = new StreamWriter(output))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                int number = int.Parse(line);
                writer.WriteLine(number + 1);
            }
        }
    }
    public static void zapfor7()
    {
        string input7 = "input7.txt";
        using (FileStream f = new FileStream(input7, FileMode.OpenOrCreate))
        {
            using (StreamWriter fs = new StreamWriter(f))
            {
                int lines = R.Next(3, 10);
                int rows = R.Next(3, 10);
                for (int i = 0; i < lines; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        int rand = R.Next(1, 100);
                        fs.Write(rand);
                        if (j < rows - 1)
                        {
                            fs.Write(" ");
                        }
                    }
                    fs.WriteLine();
                }
            }
        }
    }
    public static void calc7()
    {
        string input7 = "input7.txt";
        using (StreamReader fs = new StreamReader(input7))
        {
            string firstline = fs.ReadLine();
            int min = 9999999;
            string[] firstlineel = firstline.Split(" ");
            int one = int.Parse(firstlineel[0]);
            while (!fs.EndOfStream)
            {
                string line = fs.ReadLine();
                string[] num = line.Split(" ");
                foreach (string nubmer in num)
                {
                    int curr = int.Parse(nubmer);
                    if (curr < min)
                    {
                        min = curr;
                    }
                }
            }
            Console.WriteLine("\n Первое плюс минимальное: " + (one += min));
        }
    }
    public static void eight()
    {
        string input = "input8.txt";
        string output = "output8.txt";
        using (StreamReader reader = new StreamReader(input))
        {
            using (StreamWriter writer = new StreamWriter(output))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (b(line))
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
    private static bool b(string line)
    {
        if (line.Length == 0)
        {
            return false;
        }
        char last = line[line.Length - 1];
        return last == 'б';
    }
}