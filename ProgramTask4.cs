using System;

namespace ConsoleApp6
{
    public enum LicenseType
    {
        Trial = 0,
        Pro,
        Ultimate
    }
    public class ApplicationLicense
    {
        public LicenseType License
        {
            get;
            private set;
        } = LicenseType.Trial;

        private const string ProKey = "BR2246-56FZ-3F78VU-8984-NJFKZF-99QWKL-H338-JPC2CT-3N9W-5CY75F";
        private const string UltimateKey = "9W0JASD-LEQC-90QYK5-NX2J-DYD7PZ-4BV9ZZ-LD9N-QZ0KLK-WHJE-G9UG7F";

        public LicenseType ChangeLicense(string key)
        {
            if (key == ProKey)
                AllowPro();
            else if (key == UltimateKey)
                AllowUltimate();
            else
                AllowTrial();

            return License;
        }

        private void AllowUltimate()
        {
            License = LicenseType.Ultimate;
        }
        private void AllowTrial()
        {
            License = LicenseType.Trial;
        }
        private void AllowPro()
        {
            License = LicenseType.Pro;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var license = new ApplicationLicense();

            Console.WriteLine("Введите лицензионный ключ или просто нажмите Enter");
            license.ChangeLicense(Console.ReadLine());

            Console.WriteLine($"Ваша лицензия: {license.License}");

            Console.WriteLine("Доступные операции:");
            Console.WriteLine(@"Сложение - '+' (Trial+)");
            Console.WriteLine(@"Умножение - '*' (Pro+)");
            Console.WriteLine(@"Возведение в степень - '^' (Ultimate+)");
            Console.WriteLine();

            Console.WriteLine("Введите первый аргумент");
            double firstArgument = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите знак операции");
            char operation = Console.ReadLine()[0];

            Console.WriteLine("Введите второй аргумент");
            double secondArgument = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine($"Ваша лицензия: {license.License}");
            switch (operation)
            {
                case '+':
                    Console.WriteLine("Операция сложения доступна");
                    Console.WriteLine($"Ответ: {firstArgument + secondArgument}");
                    break;

                case '*':
                    if (license.License >= LicenseType.Pro)
                    {
                        Console.WriteLine("Операция умножения доступна");
                        Console.WriteLine($"Ответ: {firstArgument * secondArgument}");
                    }
                    else
                        Console.WriteLine("Не имеет функции умножения");

                    break;

                case '^':
                    if (license.License >= LicenseType.Ultimate)
                    {
                        Console.WriteLine("Операция возведения встепень доступна");
                        Console.WriteLine($"Ответ: {Math.Pow(firstArgument, secondArgument)}");
                    }
                    else
                        Console.WriteLine("Не имеет функции возведение в степень");

                    break;
            }

            Console.ReadLine();
        }
    }
}