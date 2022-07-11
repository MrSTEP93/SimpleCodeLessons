// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Human chuvak = new("chuvak");
Console.WriteLine("Student count = {0}", Student._studentCount);
Console.WriteLine("humans= {0}", Human.humanCount);
Student student1 = new("Chuvak");
Console.WriteLine("Student count = {0}", Student._studentCount);
student1.Career();
Console.WriteLine("humans = {0}", Human.humanCount);
Student student2 = new("Shket");
Console.WriteLine("Student count = {0}", Student._studentCount);
Console.WriteLine("humans = {0}", Human.humanCount);
Student student3 = new("Patcan");
Console.WriteLine("Student count = {0}", Student._studentCount);
student3.Sleep(3);
student3.Eat();
Console.WriteLine("humans = {0}", Human.humanCount);

public abstract class Human
{
    public static int humanCount;
    public string name;
    static Human()
    {
        humanCount = 0;
    }
    public Human(string name) {
        humanCount++;
        this.name = name;
        Console.WriteLine("Constructor of class ==Human==, instance name " + this.name);
    }
    public abstract void Career();
    public virtual void Eat()
    {
        Console.WriteLine("__human {0} is eating", name);
    }
    public virtual void Sleep(int hours)
    {
        Console.WriteLine("Zzzzz...... for {0} hours", hours);
    }
}
public class Student : Human
{
    //public string name;
    public static int _studentCount;
    static Student()
    {
        _studentCount = 0;
        Console.WriteLine("Static constructor of class ===Student===");
    }
    public Student(string studName) : base(studName)
    {
        //this.name = studName;
        _studentCount++;
        Console.WriteLine("Constructor of object of class =Student=, instance name={0}", this.name);
    }

    public override void Career()
    {
        Console.WriteLine("_____student {0} is studying, xuli emy esche delat'", this.name);
    }
    public override void Eat()
    {
        Console.WriteLine("__human {0} is sucks his hand, 'cause he is a poor student", name);
    }
    public override void Sleep(int hours)
    {
        if (hours > 4)
        {
            Console.WriteLine("Student can't cleep more than 4 hours");
        } else
        {
            base.Sleep(hours);
        }
    }
}
