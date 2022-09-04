﻿using AbstractClassesVsInterface;
using Packt.Shared;
using static System.Console;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Marry" };
Person jill = new() { Name = "Jill" };

//call instance method
Person baby1 = mary.ProcreateWith(harry);
baby1.Name = "Gary";
//call static method
Person baby2 = Person.Procreate(harry, jill);
// call an operator
Person baby3 = mary * jill;
WriteLine($"{harry.Name} hass {harry.Children.Count} children.");
WriteLine($"{mary.Name} has {mary.Children.Count} child");
WriteLine($"{jill.Name} has {jill.Children.Count} child");
WriteLine(
    format: "{0}'s first child is named \"{1}\".",
    arg0: harry.Name,
    arg1: harry.Children[0].Name);
// local function
WriteLine($"5! is {Person.Factorial(5)}");

//delegate
static void Harry_Shout(object? sender, EventArgs e)
{
    if (sender is null) return;
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

harry.Shout += Harry_Shout;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

// making types safely reusablw with generics
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; // lookup the value that has 2 as its key
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupObject[key]);
// lookup the value that has harry as its key
WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookupObject[harry]);

// generic lookup collection    
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupIntString[key]);

//Implementing interfaces

Person[] people =
{
    new() {Name = "Simon"},
    new() {Name = "Jenny"},
    new() {Name = "Adam"},
    new() {Name = "Richard"}
};
WriteLine("Initial list of people:");
foreach (Person p in people)
{
    WriteLine($"  {p.Name}");
}
WriteLine("Use Person's IComparable implementation to sort:");
Array.Sort(people);
foreach (Person p in people)
{
    WriteLine($"  {p.Name}");
}

WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach(Person p in people)
{
    WriteLine($"  {p.Name}");
}

// struc type

DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;
WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

//inheriting from classes
Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.WriteToConsole();

//Extending classes to add functionality
john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

//overriding members
WriteLine(john.ToString());


// inheriting from abstract classes

FullyImplemented a = new();
// all the other types give compile errors
//PartiallyImplemented b = new(); // compile error!
//ISomeImplementation c = new(); // compile error!
//INoImplementation d = new(); // compile error!

// Understanding polymorphism
Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;

aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

//Casting within inheritance hierarchies
// explicit casting
//if (aliceInPerson is Employee)//check the type of an object 
//{
//    WriteLine($"{nameof(aliceInPerson)} IS an Employee");
//    Employee explicitAlice = (Employee)aliceInPerson;
//} 

if (aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee");
}


Employee? aliceAsEmployee = aliceInPerson as Employee;
if (aliceAsEmployee != null)
{
    WriteLine($"{nameof(aliceInPerson)} AS an Employee");
}

//inheriting exceptions
try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));

}
catch(PersonException ex)
{
    WriteLine(ex.Message);
}

//Using static methods to reuse functionality

string email1 = "vuvietquang90@gmail.com";
string email2 = "ian&test.com";
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail()); //extenstions
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail()); // extenstions