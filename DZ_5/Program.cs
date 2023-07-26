using DZ_5;
using DZ_5.Generic;
using System;

List<int> list = new List<int>();
LinkedList<int> l = new LinkedList<int>();
IMyEnumerable filter;

#region [  MyList  ]
//////////////////////////MyList////////////////////////////
Console.WriteLine("\t!!!---MyList---!!!");
MyList<int> myList = new MyList<int>();
myList.Add(1);
myList.Add(2);
myList.Add(30);
myList.Add(4);
myList.Add(500);
myList.Add(6);
myList.Add(16);
myList.Add(19);
myList.Add(9);
myList.Add(10);
myList.Add(11);
myList.Add(12);
foreach (var item in myList)
{
    Console.Write(item + ", ");
}
Console.WriteLine();
foreach (var item in myList.MyTakeWhile_Yield(i => i < 100))
{
    Console.Write(item + ", ");
}

Console.WriteLine($"\n\nmyList.Sort()");
myList.Sort();
foreach (var item in myList)
{
    Console.Write(item + ", ");
}
Console.WriteLine($"\n\nmyList.BinarySearch(19) = {myList.BinarySearch(19)}");
Console.WriteLine("\nmyList.MySkip(3).MyWhere(i => i < 10)");
filter = myList.MySkip(3).MyWhere(i => i < 10);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
Console.WriteLine("\n\nmyList.MySkipWhile(i => i < 5)");
filter = myList.MySkipWhile(i => i < 5);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
Console.WriteLine($"\n\nmyList.MyFirst(i => i == 10) = {myList.MyFirst(i => i == 10)}");
Console.WriteLine($"myList.MyFirstOrDefault(i => i > 100) = {myList.MyFirstOrDefault(i => i > 100)}");
Console.WriteLine($"myList.MyLastOrDefault(i => i == 10) = {myList.MyLastOrDefault(i => i == 10)}");
Console.WriteLine($"myList.All(x => (x > 0 && x < 20)) = {myList.All(x => (x > 0 && x < 20))}");
Console.WriteLine($"myList.Any(x => (x == 10))) = {myList.Any(x => (x == 10))}");

Console.WriteLine("\nToList()");
list = myList.ToList();
foreach (int item in list)
{
    Console.Write(item + ", ");
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyList<Student> students  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyList<Student> students  ]
filter = myList.Select(x => x.ToString());
filter = from p in myList select p.ToString();
//foreach (var item in filter)
//{
//    Console.WriteLine(item.GetType());
//}

MyList<Student> students = new MyList<Student>();
students.Add(new Student(21, "Nick", 85.9f, "2A"));
students.Add(new Student(20, "Bob", 88.2f, "2A"));
students.Add(new Student(21, "Lisi", 80.5f, "2A"));
students.Add(new Student(21, "Joi", 95.9f, "2B"));
students.Add(new Student(23, "Ed", 93.9f, "2B"));
students[0]._books.Add(new Book("Проктология для любознательных", "Н.Е. Глубокий"));
students[0]._books.Add(new Book("Эксплуатация и ремонт северного оленя", "Г.В. Федосеев"));
students[0]._books.Add(new Book("Боевой бамбинтон. История и практика", "Г.К. Клейн"));
students[1]._books.Add(new Book("Руководство трофейного киборга Т-800", "T.T. Терминатор"));
students[1]._books.Add(new Book("Как пить каждый день", "З.А. Пой"));
students[1]._books.Add(new Book("Животные под бутиратом", "С.А. Маршак"));
students[2]._books.Add(new Book("Вайфай: правда или вымысел?", "А.И. Палий"));
students[3]._books.Add(new Book("Хищные грибы Узбекистана", "А.И. Палий"));
students[3]._books.Add(new Book("Организация общества трезвости на природе", "И.Б. Священник"));
students[3]._books.Add(new Book("Лечение колокольным звоном", "И.Б. Священник"));

var stud = students.Select(i => new
{
    name = i._name,
    age = i._age,
    group = i._group,
    rating = i._rating
});
Console.WriteLine("!!!Список студентов!!!");
foreach (var item in stud)
{
    Console.Write(item + "\n");
}
var books = students.SelectMany(i => i._books);
Console.WriteLine("!!!Список книг!!!");
foreach (var item in books)
{
    Console.Write(item._title + " " + item._author + "\n");
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyList<Person>  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyList<Person>  ]
Console.WriteLine("\t!!!---MyList<Person>---!!!");
MyList<Person> people = new MyList<Person>();
people.Add(new Person(25, "Stevie"));
people.Add(new Person(31, "Joi"));
people.Add(new Person(27, "Pamela"));
people.Add(new Person(38, "Nick"));
people.Sort();
foreach (var item in people)
{
    Console.WriteLine(item._age + " " + item._name);
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyObservableCollection  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyObservableCollection  ]
//////////////////////////MyObservableCollection////////////////////////////
Console.WriteLine("\t!!!---MyObservableCollection---!!!");
void DoAddToList(object sender, EvantList_add<int> e)
{
    Console.WriteLine($"{e.Item} добавлен в позицию {e.Index}");
}
void DoRemoveFromList(object sender, EvantList_add<int> e)
{
    Console.WriteLine($"Элемент {e.Item} Удален");
}
MyObservableList<int> myObservableCollection = new MyObservableList<int>();
myObservableCollection.ListChanged_add += DoAddToList;
myObservableCollection.ListChanged_remove += DoRemoveFromList;

myObservableCollection.Add(1);
myObservableCollection.Add(2);
myObservableCollection.Add(3);
myObservableCollection.Insert(0, 100);
myObservableCollection.Insert(2, 200);
myObservableCollection.Remove(2);
foreach (var item in myObservableCollection)
{
    Console.WriteLine(item);
}
//Ожидание "Enter"
Console.WriteLine("\n\nOneWayList  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  OneWayList  ]
//////////////////////////OneWayList////////////////////////////
Console.WriteLine("\t!!!---OneWayList---!!!");
OneWayList<int> oneWayList = new OneWayList<int>();
oneWayList.Add(55);
oneWayList.Add(52);
oneWayList.Add(3);
oneWayList.Add(6);
oneWayList.Add(8);
foreach (var item in oneWayList)
{
    Console.Write(item + ", ");
}
Console.WriteLine("\n\noneWayList.MySkip(3)");
filter = oneWayList.MySkip(3);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
//Ожидание "Enter"
Console.WriteLine("\n\nTowWaysList  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  TowWaysList  ]
////////////////////////TowWaysList////////////////////////////
Console.WriteLine("\t!!!---TowWaysList---!!!");
TowWaysList<int> towWaysList = new TowWaysList<int>();
towWaysList.Add(1);
towWaysList.Add(2);
towWaysList.Add(3);
towWaysList.Add(4);
towWaysList.Add(5);
foreach (var item in towWaysList)
{
    Console.Write(item + ", ");
}
Console.WriteLine("\n\ntowWaysList.MySkip(3)");
filter = towWaysList.MySkip(3);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyStack  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyStack  ]
//////////////////////////MyStack////////////////////////////
Console.WriteLine("\t!!!---MyStack---!!!");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);
myStack.Push(4);
myStack.Push(5);
foreach (var item in myStack)
{
    Console.Write(item + ", ");
}
Console.WriteLine("\n\nmyStack.MySkip(3)");
filter = myStack.MySkip(3);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyQueue  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyQueue  ]
//////////////////////////MyQueue////////////////////////////
Console.WriteLine("\t!!!---MyQueue---!!!");
MyQueue<int> myQueue = new MyQueue<int>();
myQueue.Enqueue(1);
myQueue.Enqueue(2);
myQueue.Enqueue(3);
myQueue.Enqueue(4);
myQueue.Enqueue(5);
foreach (var item in myQueue)
{
    Console.Write(item + ", ");
}
filter = myQueue.MySkip(3);
foreach (var item in filter)
{
    Console.Write(item + ", ");
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyQueuePriority  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  MyQueuePriority  ]
//////////////////////////MyQueuePriority////////////////////////////
Console.WriteLine("\t!!!---MyQueuePriority---!!!");
MyQueuePriority<int> myQueuePriority = new MyQueuePriority<int>();
myQueuePriority.Enqueue(10, 1);
myQueuePriority.Enqueue(11, 1);
myQueuePriority.Enqueue(12, 1);
myQueuePriority.Enqueue(20, 2);
myQueuePriority.Enqueue(21, 2);
myQueuePriority.Enqueue(30, 3);
myQueuePriority.Enqueue(31, 3);
myQueuePriority.Enqueue(33, 3);
myQueuePriority.Enqueue(22, 2);
myQueuePriority.Enqueue(23, 2);
myQueuePriority.Enqueue(13, 1);
Console.WriteLine("PrintAll");
foreach (var item in myQueuePriority)
{
    Console.WriteLine(item);
}
Console.WriteLine("myQueuePriority.Dequeue()");
Console.WriteLine(myQueuePriority.Dequeue());
Console.WriteLine(myQueuePriority.Dequeue());
Console.WriteLine("PrintAll");
foreach (var item in myQueuePriority)
{
    Console.WriteLine(item);
}
//Ожидание "Enter"
Console.WriteLine("\n\nMyTree  -> \"Enter\"...");
Console.ReadLine();
Console.Clear();
#endregion

#region [  3_MyTree  ]
/////////////////////////////3_MyTree//////////////////////////////
Console.WriteLine("\t!!!---MyTree---!!!");
MyTree<int> tree = new MyTree<int>();
tree.Add(100);
tree.Add(50);
tree.Add(40);
tree.Add(60);
tree.Add(140);
tree.Add(135);
tree.Add(145);
tree.Add(160);

Console.WriteLine("\ntree.Contains(160)");
Console.WriteLine(tree.Contains(160));
Console.WriteLine("tree.Contains(55)");
Console.WriteLine(tree.Contains(55));
Console.WriteLine();

int[] arr = tree.ToArray();
foreach (int item in tree)
{
    Console.Write(item + ", ");
}
Console.WriteLine();
#endregion
internal class Person : IComparable<Person>
{
    public int _age;
    public string _name;

    public Person(int age, string name)
    {
        _age = age;
        _name = name;
    }

    public int CompareTo(Person other)
    {
        if (other == null)
            return -1;
        return _age.CompareTo(other._age);
    }
}
internal class Student : Person
{
    public float _rating;
    public string _group;
    public MyList<Book> _books;
    public Student(int age, string name, float rating, string group) : base(age, name)
    {
        _rating = rating;
        _group = group;
        _books = new MyList<Book>();
    }
    public void AddBook(Book book)
    { _books.Add(book); }
}
internal class Book
{
    static int ID = 0;

    public int _id;
    public string _title;
    public string _author;
    public Book(string title, string author)
    {
        _id = ++ID;
        _title = title;
        _author = author;
    }
}