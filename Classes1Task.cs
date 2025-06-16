namespace pr1;

class Menu1
{
    public static void Start()
    {
        int weight, meat;
        (weight, meat) = ReadTwoNumbers();
        Global.Khin = new Khinkali(weight, meat);
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
            Console.WriteLine("Введите параметры хинкали: общий вес и вес мяса");
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
                case 0 :
                    return;
            }
        }
    }
        
    static void MenuVisualiser()
    {
        Console.WriteLine("1. Поменять");
        Console.WriteLine("2. Вывод параметров хинкали");
        Console.WriteLine("3. Рецепт хинкалей");
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
        Global.Khin.FindOutInformation();
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuThird()
    {
        Khinkali.Recept();
        Console.ReadKey();
        Console.Clear();
    }

    static void MenuFourth()
    {
        Global.Khin.Cook();
        Global.Khin.AddSauce();
        Console.ReadKey();
        Console.Clear();
    }
}
public class Khinkali
{
//Также здесь используется сокращённое описание свойства, позволяющее не прописывать явно название поля
    public enum Size
    {
        Small,
        Medium,
        Large
    }

    private readonly Size _size;

    public bool AddedSauce = false;
    public int Weight { get; set; }
    public bool Cooked { get; set; } = false;
    public int AmountOfMeat { get; set; }
    public bool PresenceOfCilantro { get; set; }
    public int NumberOfFolds { get; set; }

    public Khinkali()
    {
        _size = Size.Small;
        AddedSauce = false;
        Weight = 0;
        Cooked = false;
        AmountOfMeat = 0;
        PresenceOfCilantro = false;
        NumberOfFolds = 0;
    }

    public Khinkali(int weight, int meat, bool cooked, bool sauce):this(weight, meat)
    {
        Cooked = cooked;
        AddedSauce = sauce;
    }

    public Khinkali(int weight, int meat)
    {
        Weight = weight;
        AmountOfMeat = meat;
        PresenceOfCilantro = true;
            
            
        switch (weight)
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

        NumberOfFolds = _size switch
        {
            Size.Small => 12,
            Size.Medium => 18,
            Size.Large => 25,
            _ => NumberOfFolds
        };
    }

    public void Cook()
    {
        Cooked = true;
        Console.WriteLine("Хинкали готовы!");
    }
        
    public void AddSauce()
    {
        if (AddedSauce)
        {
            Console.WriteLine("А не много будет соуса???");
            return;
        }

        Console.WriteLine("Соус добавлен");
        AddedSauce = true;
    }

    public void FindOutInformation()
    {
        Console.WriteLine(ToString());
        Console.WriteLine($"Мясо: {AmountOfMeat}г, тесто: {Weight - AmountOfMeat}г");
            
        if (PresenceOfCilantro){
            Console.WriteLine("Кинза на месте, отвечаю");
            return;
        }
        Console.WriteLine("Кинзы нет:(");
    }

    public static void Recept()
    {
        Console.WriteLine("Тесто для хинкали готовится как с яйцами, так и без яиц — так же, как для пельменей. Чтобы хинкали не рвались, следует соблюдать соотношение 1:2, то есть на одну часть воды добавляется две части муки (250 мл воды — 500 г муки)\nИдеальная толщина раскатки теста, чтобы оно получилось упругим и удерживало бульон, — 2 мм. В общем, тонкие, как можно тоньше. Слишком толстые лепешки из теста плохо проварятся, а чрезмерно тонкие могут порваться.\nЧтобы начинка была сочной, соотношение мяса и репчатого лука должно составлять 1:3, то есть на 1 кг мяса понадобится 330 г лука. Если взять слишком мало, начинка получится суховатой, а если переборщить, то лук перебьет вкус мяса.\nКоличество теста и начинки должно быть примерно равным, соотношение 1:1, то есть на 40 г теста понадобится 40 г мяса (1 столовая ложка). Тогда изделия проварятся равномерно, вкус будет гармоничным.\nЗначимое место в приготовлении занимает работа над формой. Чем больше складочек у «хвостика» хинкали, тем опытнее считается лепщик. Некоторые мехинкле (так называются повара, которые готовят хинкали) могут собрать 28 и даже 32 складочки. Уходит традиция в языческие времена. Хвостик хинкали символизирует солнце, а складочки — его лучи.");
    }
        
    public override string ToString()
    {
        return $"Хинкаля: вес - {Weight}, складок - {NumberOfFolds}, размер - {_size}";
    }
        
    public static Khinkali operator +(Khinkali khinkaliLeft, Khinkali khinkaliRight)
    {
        return new Khinkali(khinkaliLeft.Weight + khinkaliRight.Weight, khinkaliLeft.AmountOfMeat + khinkaliRight.AmountOfMeat);
    }

    public static bool operator ==(Khinkali khinkaliLeft, Khinkali khinkaliRight)
    {
        return khinkaliLeft.Weight == khinkaliRight.Weight;
    }

    public static bool operator !=(Khinkali khinkaliLeft, Khinkali khinkaliRight)
    {
        return khinkaliLeft.Weight != khinkaliRight.Weight;
    }
}
