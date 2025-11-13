using System;

delegate void NameChangeEventHandler(object sender, NameChangeEventArg args);

class NameChangeEventArg : EventArgs
{
    public string Name { get; private set; }

    public NameChangeEventArg(string name)
    {
        Name = name;
    }
}

class Dispatcher
{
    private string name;
    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get { return name; }
        set
        {
            if (value != name)
            {
                name = value;
                OnNameChange(new NameChangeEventArg(value));
            }
        }
    }

    protected void OnNameChange(NameChangeEventArg args)
    {
        NameChange?.Invoke(this, args);
    }
}

class Handler
{
    public void OnDispatcherNameChange(object sender, NameChangeEventArg args)
    {
        Console.WriteLine($"Dispather`s name changed to {args.Name}");
    }
}

class Program
{
    static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler hander = new Handler();

        dispatcher.NameChange += hander.OnDispatcherNameChange;

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                dispatcher.Name = input;
            }
        }
    }
}