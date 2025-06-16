namespace pr1;

public interface IEatable
{
    public void Cook();
    public void AddSauce();
    public void FindOutInformation();
    public void GetName();
    public void Recept();
}

class Menu3
{
    public static void Start()
    {
        int choise;
        do
        {
            Console.Clear();
            Console.WriteLine("Выберите, что хотите создать:\n" +
                              "1. Манты\n" +
                              "2. Вонтоны\n" +
                              "3. Варенники\n" +
                              "4. Буззы\n" +
                              "5. Равиоли\n" +
                              "6. Пицца\n"
            );
        } while (!Int32.TryParse(Console.ReadLine(), out choise) || choise < 1 || choise > 6);

        int weight, meat;
        (weight, meat) = ReadTwoNumbers();

        switch (choise)
        {
            case 1:
                IEatable mant = new Third.Mantas(weight, meat, "Манты");
                Global.Eatable.Add(mant);
                break;
            case 2:
                IEatable wont = new Third.Wontons(weight, meat, "Вонтоны");
                Global.Eatable.Add(wont);
                break;
            case 3:
                IEatable varen = new Third.Vareniki(weight, meat, "Вареники");
                Global.Eatable.Add(varen);
                break;
            case 4:
                IEatable buuz = new Third.Buuzi(weight, meat, "Буззы");
                Global.Eatable.Add(buuz);
                break;
            case 5:
                IEatable ravi = new Third.Ravioli(weight, meat, "Равиоли");
                Global.Eatable.Add(ravi);
                break;
            case 6:
                IEatable pizz = new Third.Pizza();
                Global.Eatable.Add(pizz);
                break;
        }

        Console.Clear();
        StartMenu();
    }

    public static (int, int) ReadTwoNumbers()
    {
        int number1 = 0, number2 = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.Clear();
            Console.WriteLine("Введите параметры: общий вес и вес мяса");
            Console.Write("Введите два числа через пробел: ");
            string? input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            if (numbers.Length == 2 && int.TryParse(numbers[0], out number1) &&
                int.TryParse(numbers[1], out number2) && (number1 > number2) && number1 > 0 && number2 > 0)
            {
                validInput = true;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, введите два числа через пробел.");
            }
        }

        return (number1, number2);
    }

    static void StartMenu()
    {
        int command;
        while (true)
        {
            MenuVisualiser();
            while (!(int.TryParse(Console.ReadLine(), out command)))
            {
                Console.Clear();
                MenuVisualiser();
            }

            Console.Clear();
            switch (command)
            {
                case 1:
                    MenuFirst();
                    return;
                case 2:
                    MenuSecond();
                    break;
                case 3:
                    MenuThird();
                    break;
                case 4:
                    MenuFourth();
                    break;
                case 0:
                    return;
            }
        }
    }

    static void MenuVisualiser()
    {
        Console.WriteLine("1. Добавить объект");
        Console.WriteLine("2. Вывод параметров");
        Console.WriteLine("3. Имя?");
        Console.WriteLine("4. Приготовить и добавить соус");
        Console.WriteLine("0. Выход");
        Console.WriteLine("Напишите цифру пункта меню для выбора");
    }

    static void MenuFirst()
    {
        Start();
    }

    static void MenuSecond()
    {
        foreach (IEatable curr in Global.Eatable)
        {
            curr.FindOutInformation();
        }
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuThird()
    {
        foreach (IEatable curr in Global.Eatable)
        {
            curr.GetName();
        }
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuFourth()
    {
        foreach (IEatable curr in Global.Eatable)
        {
            curr.Cook();
            curr.AddSauce();
        }
        Console.ReadKey();
        Console.Clear();
    }
}

class Third
{
    public abstract class Dumplings
    {
        private readonly Size _size;

        private string Name { get; set; }
        private bool _addedSauce = false;
        private int Weight { get; set; }
        public bool Cooked { get; set; } = false;
        private int AmountOfMeat { get; set; }
        private bool PresenceOfCilantro { get; set; }
        private int NumberOfFolds { get; set; }

        private enum Size
        {
            Small,
            Medium,
            Large
        }


        protected Dumplings()
        {
            Name = "";
            _size = Size.Small;
            _addedSauce = false;
            Weight = 0;
            Cooked = false;
            AmountOfMeat = 0;
            PresenceOfCilantro = false;
            NumberOfFolds = 0;
        }

        protected Dumplings(int weight, int meat, string name)
        {
            Weight = weight;
            AmountOfMeat = meat;
            PresenceOfCilantro = true;
            Name = name;

            switch (Weight)
            {
                case <= 75 and > 0:
                    _size = Size.Small;
                    break;
                case > 75 and <= 150:
                    _size = Size.Medium;
                    break;
                case > 150:
                    _size = Size.Large;
                    break;
            }
        }

        public virtual void Cook()
        {
            Cooked = true;
            Console.WriteLine($"{Name} готовы");
        }


        public void AddSauce()
        {
            if (_addedSauce)
            {
                Console.WriteLine("А не много будет соуса???");
                return;
            }

            Console.WriteLine("Соус добавлен");
            _addedSauce = true;
        }

        public virtual void FindOutInformation()
        {
            Console.WriteLine(ToString());
            Console.WriteLine($"Начинка: {AmountOfMeat}г, тесто: {Weight - AmountOfMeat}г");

            if (PresenceOfCilantro)
            {
                Console.WriteLine("Кинза на месте, отвечаю");
                return;
            }

            Console.WriteLine("Кинзы нет:(");
        }

        public override string ToString()
        {
            return $"{Name}: вес - {Weight}, размер - {_size}, наличие соуса - {_addedSauce}";
        }

        protected void GetBaseName()
        {
            Console.Write(GetType().BaseType.Name + ": ");
        }
    }

    public sealed class Vareniki : Dumplings, IEatable
    {
        private string _name = "Вареники";

        private void getName()
        {
            Console.WriteLine(_name);
        }

        public Vareniki(int weight, int meat, string name) : base(weight, meat, name)
        {
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт вареников");
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void GetName()
        {
            GetBaseName();
            Console.WriteLine(GetType().Name);
        }
    }

    public class Mantas : Dumplings, IEatable
    {
        private string _name = "Манты";

        private void getName()
        {
            Console.WriteLine(_name);
        }

        public Mantas(int weight, int meat, string name) : base(weight, meat, name)
        {
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт мант");
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void GetName()
        {
            GetBaseName();
            Console.WriteLine(GetType().Name);
        }
    }

    public class Buuzi : Dumplings, IEatable
    {
        private string _name = "Буззы";

        private void getName()
        {
            Console.WriteLine(_name);
        }

        public Buuzi(int weight, int meat, string name) : base(weight, meat, name)
        {
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт буззов");
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void GetName()
        {
            GetBaseName();
            Console.WriteLine(GetType().Name);
        }
    }

    public class Wontons : Dumplings, IEatable
    {
        private string _name = "Вонтоны";

        private void getName()
        {
            Console.WriteLine(_name);
        }

        public Wontons(int weight, int meat, string name) : base(weight, meat, name)
        {
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт вонтонов");
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void GetName()
        {
            GetBaseName();
            Console.WriteLine(GetType().Name);
        }
    }

    public class Ravioli : Dumplings, IEatable
    {
        private string _name = "Равиоли";

        private void getName()
        {
            Console.WriteLine(_name);
        }

        public Ravioli(int weight, int meat, string name) : base(weight, meat, name)
        {
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт равиолей");
        }

        public override void Cook()
        {
            base.Cook();
        }

        public void GetName()
        {
            GetBaseName();
            Console.WriteLine(GetType().Name);
        }
    }

    public class Pizza : IEatable
    {
        private string _name;

        public Pizza()
        {
            _name = "Пицца";
        }

        private void getName()
        {
            Console.WriteLine(_name);
        }
        public void Cook()
        {
            Console.WriteLine("Cook");
        }

        public void AddSauce()
        {
            Console.WriteLine("AddSauce");
        }

        public void Recept()
        {
            Console.WriteLine("Тут должен быть рецепт пиццы");
        }

        public string ToString()
        {
            return $"{_name}: вес - неизвестен, размер - 30 см, наличие соуса - а какая пицца без соуса ????";
        }
        public void FindOutInformation()
        {
            Console.WriteLine(ToString());
            Console.WriteLine($"Начинка: вроде есть, тесто: тонкое");
        }
        public void GetName()
        {
            Console.WriteLine(GetType().Name);
        }
    }
}
