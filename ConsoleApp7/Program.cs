using ConsoleApp7;

Blocknot blocknot = new Blocknot();
MenuItems menuItems;
FindItems findItems;
int choice;
blocknot.LoadFromFile();
do
{
    Console.WriteLine("1 - Add Record");
    Console.WriteLine("2 - Find");
    Console.WriteLine("3 - Remove");
    Console.WriteLine("4 - Show All");
    Console.WriteLine("5 - Save");
    Console.WriteLine("0 - Exit");

    System.Console.Write("choice ->");

    while (!int.TryParse(Console.ReadLine(), out choice))
    {
        Console.WriteLine("Please, enter a number");
    }
    menuItems = (MenuItems)choice;

    switch (menuItems)
    {

        case MenuItems.AddRecord:
            System.Console.Write("name ->");
            string name = Console.ReadLine();

            System.Console.Write("phoneNumber ->");
            string phoneNumber = Console.ReadLine();

            Record record = new Record(name, phoneNumber);
            blocknot.Add(record);
            break;
        case MenuItems.Find:
            IEnumerable<Record> record1 = null;
            Console.WriteLine("1 - Find by name");
            Console.WriteLine("2 - Find by phone");
            Console.WriteLine("3 - Find by first letter");
            Console.WriteLine("4 - Find by letter");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please, enter a number");
            }
            findItems = (FindItems)choice;
            switch (findItems)
            {
                case FindItems.Name:
                    Console.Write("Name -> ");
                    string nameToFind = Console.ReadLine();
                    record1 = blocknot.Find(item => item.Name == nameToFind);
                    break;
                case FindItems.Phone:
                    Console.Write("Phone number -> ");
                    string phone = Console.ReadLine();
                    record1 = blocknot.Find(item => item.Phone == phone);
                    break;
                case FindItems.StartWith:
                    Console.Write("Letter -> ");
                    string letter = Console.ReadLine();
                    record1 = blocknot.Find(item => item.Name.ToLower()[0] == char.Parse(letter.ToLower()));
                    break;
                case FindItems.Contain:
                    Console.Write("Letter contain -> ");
                    string letterContain = Console.ReadLine();
                    record1 = blocknot.Find(item => item.Name.Contains(char.Parse(letterContain)));
                    break;
            }
            if (record1 != null)
            {
                foreach (var item in record1)
                {
                   Console.WriteLine($"The record you need is {item.Name} ----- {item.Phone}");
                }
            }
            else
                Console.WriteLine("Record did not exist");
            break;
        case MenuItems.ShowAll:
            blocknot.ShowOnConsole();
            break;
        case MenuItems.Remove:
            string nameToRemove = default;
            bool isRemoved = default;
            do
            {
                Console.WriteLine("Name ");
                nameToRemove = Console.ReadLine();
                isRemoved = blocknot.Remove(nameToRemove);
                if (isRemoved)
                {
                    Console.WriteLine("Record removed");
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                }
            }
            while (!isRemoved);
            break;
        case MenuItems.Save:
            if (blocknot.SaveToFile())
            {
                Console.WriteLine("Successfuly saved");
            }
            else
            {
                Console.WriteLine("Error while saving");
            }
            break;
        case MenuItems.Exit:
            System.Console.WriteLine("You exit");
            break;
        default:
            System.Console.WriteLine("Unknown command");
            break;
    }

} while ((int)menuItems != 0);