using System;
using System.Diagnostics;


namespace ConsoleApp2
{ public class FirstClass
{
    public virtual void ShowInDebug(params object[] args)
    {
        Debug.Indent();
        Debug.WriteLine("Arguments:");
        Debug.WriteLine("");
        Debug.Unindent();

        foreach (var i in args)
        {
            Debug.WriteLine($"* {i}");
        }
        Debug.WriteLine("");
    }
}
public class SecondClass : FirstClass
{
    public override void ShowInDebug(params object[] args)
    {
        Debug.Indent();
        Debug.WriteLine("Arguments in Second Class:");
        Debug.WriteLine("");
        Debug.Unindent();

        foreach (var i in args)
        {
            Debug.WriteLine($"* {i.GetType()}: {i}");
        }
        Debug.WriteLine("");
    }
}
class Program
{
    static void Main(string[] args)
    {
        FirstClass[] classes = new[]
        {
                new FirstClass(),
                new SecondClass()
            };

        foreach (FirstClass test in classes)
            test.ShowInDebug(
                DateTime.Now,
                19877891,
                1.987f,
                19.87d,
                19.87m,
                new object(),
                "Хз"

            );

        Console.ReadLine();
    }
}
}