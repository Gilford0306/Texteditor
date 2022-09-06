using Texteditor;

do
{
    Console.Clear();
    Console.WriteLine("\tText Editor");
    Console.WriteLine("Create file - press 1");
    Console.WriteLine("Open file - press 2");
    Console.WriteLine("Edit file - press 3");
    Console.WriteLine("Deleted file - press 4");
    string k = Console.ReadLine();

    switch (k)
    {
        case "1":

            Console.WriteLine("Input name of file");
            string name = Console.ReadLine();
            Console.WriteLine("Input save location or  press enter - to save in the default folder");
            Console.WriteLine(@"Example save location - C:\Users\User\Desktop\");
            string locate = Console.ReadLine();
            TextFile textfile = new TextFile(name, locate);
            Console.WriteLine("File is created");
            Console.WriteLine("Press enter to continue");
            string any1 = Console.ReadLine();
            break;
        case "2":
            Console.WriteLine("Input location file");
            Console.WriteLine(@"Example location - C:\Users\User\Desktop\");
            string dir = Console.ReadLine();
            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    Console.WriteLine($"file:\t{item}");
                }
                Console.WriteLine("Input full path + name file ");
                string file = Console.ReadLine();
                textfile = new TextFile(file);
                textfile.Show();
                Console.WriteLine("Press enter to continue");
                string any2 = Console.ReadLine();
                break;
            }
            else
            Console.WriteLine("Directory doesn`t exist");
            Console.WriteLine("Press enter to continue");
            string any3 = Console.ReadLine();
            break;
        case "3":
            Console.WriteLine("Input location file");
            Console.WriteLine(@"Example location - C:\Users\User\Desktop\");
            dir = Console.ReadLine();
            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    Console.WriteLine($"file:\t{item}");
                }
                Console.WriteLine("Input full path + name file ");
                string file = Console.ReadLine();
                textfile = new TextFile(file);
                Console.WriteLine("What word do you need edit");
                string e = Console.ReadLine();
                textfile.Edit(file, e);
                Console.WriteLine("Press enter to continue");
                string any4 = Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine("Directory doesn`t exist");
                Console.WriteLine("Press enter to continue");
                string any5 = Console.ReadLine();
            }


            break;
        case "4":
            Console.WriteLine("Input location file");
            Console.WriteLine(@"Example location - C:\Users\User\Desktop\");
            dir = Console.ReadLine();
            if (Directory.Exists(dir))
            {
                foreach (var item in Directory.GetFiles(dir))
                {
                    Console.WriteLine($"file:\t{item}");
                }
                Console.WriteLine("Input full path + name file ");
                string file = Console.ReadLine();
                textfile = new TextFile(file);
                textfile.Deleted();
                if (!File.Exists(file))
                Console.WriteLine("File is Deleted");
                Console.WriteLine("Press enter to continue");
                string any6 = Console.ReadLine();
            }
                break;
        default:
            Console.WriteLine("Only Number 1 - 4");
            Console.WriteLine("Press enter to continue");
            string any7 = Console.ReadLine();
            break;
    }
} while (true);
