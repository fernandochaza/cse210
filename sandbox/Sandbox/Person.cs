class Person
{
    private string _name;
    private int _age;
    private string _address;


    public Person()
    {
        _name = "";
        _age = 0;
        _address = "";
    }


    public Person(string name)
    {
        _name = name;
        _age = 0;
        _address = "";
    }


    public Person(string name, int age)
    {
        _name = name;
        _age = age;
        _address = "";
    }


    public Person(string name, int age, string address)
    {
        _name = name;
        _age = age;
        _address = address;
    }


    public string Name
    {
        get {return _name;}
        set {_name = value;}
    }


    public int Age
    {
        get {return _age;}
        set {_age = value;}
    }


    public string Address
    {
        get {return _address;}
        set {_address = value;}
    }
}