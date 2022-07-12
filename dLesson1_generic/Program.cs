// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

Console.WriteLine("Coздaниe очереди с приоритетами : ");
PriorityQueue<Package> pq = new PriorityQueue<Package>();
Console.WriteLine("Дoбaвляeм случайное количество (0 - 20) случайных пакетов в очередь: " );
Package pack;
PackageFactory fact = new PackageFactory();
// Нам нужно случайное число , которое меньше 20
Random rand = new Random();
// Случайное число в диапазоне 0-20
int numToCreate = rand.Next(20);
Console.WriteLine(" \tCoздaниe {0} пакетов : ", numToCreate);
for (int i = 0; i < numToCreate; i++)
{
    Console.Write(" \t\tГeнepaция и добавление  случайного пакета {0} ", i);
    pack = fact.CreatePackage();
    Console.WriteLine(" с приоритетом {0} и доставкой в {1}", pack.Priority, pack.ShipTo);
    pq.MyEnqueue(pack);
}
Console.WriteLine("Чтo получилось: ");
int total = pq.Count;
Console.WriteLine( "Получено пакетов : {0} ", total);
Console.WriteLine("Извлeкaeм случайное количество пакетов : 0-20 : ");
int numToRemove = rand.Next(20);
Console.WriteLine("======Извлeкaeм {0} пакетов=====", numToRemove);
for (int i = 0; i < numToRemove; i++)
{
    pack = pq.MyDequeue();
    if (pack != null)
    {
        Console.WriteLine(" \tДocтaвкa пакета " + "с приоритетом {0} в город {1}", pack.Priority, pack.ShipTo);
    }
    // Сколько пакетов " доставлено"
    Console.WriteLine("Дocтaвлeнo {0} пакетов ", total - pq.Count);
}
// Ожидаем подтверждения пользователя
//Console.WriteLine("Haжмитe <Enter> для завершения программы . . . ");
//Console.Read();


//Priority - вместо числовых приоритетов наподобие
// 1 , 2 , 3 . . . используем приоритеты с именами
enum PriorityType // Об enum мы поговорим позже
{
    Low, Medium, High
}
enum CityEnum
{
    Gubkin,Muhozhopsk,Koln,Makeevka,Pyatihuevka
}

// IPrioritizable - определяем пользовательский интерфейс :
// классы, которые могут быть добавлены в PriorityQueue,
// должны реализовывать этот интерфейс
interface IPrioritizable
{
    // Пример свойства в интерфейсе
    PriorityType Priority { get; }
}

// PriorityQueue - обобщенньм класс очереди с приоритетами;
// типы данных, добавляемых в очередь, обязаны
// реализовывать интерфейс IPrioritizaЬle
class PriorityQueue<T> where T : IPrioritizable
{
    //Queues - три внутренние ( обобщенные ! ) очереди
    private Queue<T> _queueHigh = new();
    private Queue<T> _queueMedium = new();
    private Queue<T> _queueLow = new();
    // MyEnqueue - добавляет Т в очередь в соответствии с приоритетом
    public void MyEnqueue(T item)
    {
        switch (item.Priority) // Требует реализации IPrioritizable
        {
            case PriorityType.High:
                _queueHigh.Enqueue(item);
                break;
            case PriorityType.Low:
                _queueLow.Enqueue(item);
                break;
            case PriorityType.Medium:
                _queueMedium.Enqueue(item);
                break;
            default:
                //throw new ArgumentOutOfRangeException(item.Priority.ToString(), "Неверный приоритет в PriorityQueue.Enqueue");
                break;
        };
    }
    // MyDequeue - извлечение Т из очереди с наивысшим приоритетом
    public T MyDequeue()
    { // Просматриваем очередь с наивысшим приоритетом
        Queue<T> queueTop = TopQueue();
        // Очередь не пуста
        if (queueTop != null && queueTop.Count > 0)
        {
            return queueTop.Dequeue(); // Возвращаем первый элемент
        }
         // Если все очереди пусты, возвращаем null
         // (здесь можно сгенерировать исключение )
        return default(T); // Что это - мы рассмотрим позже
    }
    //TopQueue - непустая очередь с наивысшим приоритетом
    private Queue<T> TopQueue()
    {
        //Очередь с высоким приоритетом пуста?
        if (_queueHigh.Count > 0) return _queueHigh;
        //Очередь со средним приоритетом пуста?
        if (_queueMedium.Count > 0) return _queueMedium;
        //Все старшие очереди пусты
        return _queueLow;
    }
    // IsEmpty - Проверка, пуста ли очередь
    public bool IsEmpty()
    {
        // true, если все очереди пусты
        return (_queueHigh.Count == 0) & (_queueMedium.Count == 0) & (_queueLow.Count == 0);
    }
    //Count - Сколько всего элементов во всех очередях?
    public int Count // Реализуем как свойство только для чтения
    {
        get
        {
            return _queueHigh.Count + _queueMedium.Count + _queueLow.Count;
        }
    }
}

// Package - пример класса, который может быть размещен в очереди с приоритетами
class Package : IPrioritizable
{
    private PriorityType priority;
    private CityEnum shipTo;
    // Конструктор
    public Package(PriorityType priority, CityEnum city)
    {
        this.priority = priority;
        this.shipTo = city;
    }

    // Priority - возвращает приоритет пакета; только для чтения
    public PriorityType Priority
    {
        get
        {
            return priority;
        }
    }
    public CityEnum ShipTo
    {
        get
        {
            return shipTo;
        }
    }
    // А также методы ToAddress, FromAddress , Insurance,
    // и другие. . 
}

// PackageFactory - класс , который знает, как создать
// новьм пакет Package любого требуемого типа ;
// такой класс называется классом-фабрикой.
class PackageFactory
{
    // Генератор случайных чисел.
    Random _randGen = new();
    // CreatePackage - метод фабрики, который выбирает
    // случайньм приоритет и затем создает пакет с этим
    // приоритетом. Может быть реализован как блок итератора.
    public Package CreatePackage()
    {
        // Случайным образом выбранный приоритет пакета.
        // Может иметь значение 0, 1 или 2 (значения, которые меньше 3).
        int randPriority = _randGen.Next(3);
        // Случайным образом выбранный город пакета.
        //int count = CityEnum.Count;
        int randCity = _randGen.Next(5);
        // Используем для генерации нового пакета; приведение
        // типа позволяет использовать значение в конструкции switch .
        return new Package((PriorityType)randPriority,(CityEnum)randCity);
    }
}