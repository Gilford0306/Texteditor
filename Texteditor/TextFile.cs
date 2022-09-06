
using System.Text;
using System.Text.RegularExpressions;

namespace Texteditor
{
    internal class TextFile
    {
        public string FileName { get; set; }
        public string Textin { get; set; }
        public TextFile()
        {
            FileName = String.Empty;
            Textin = String.Empty;
        }
        public TextFile(string n, string l)
        {
            if (l == string.Empty)
                FileName = ($"{n}.txt");
            else
            {
                if (!Directory.Exists(l))
                {
                    Console.WriteLine("Erorre - directory does not exist");
                    return;
                }
                FileName = ($"{l}{n}.txt");
            }
            Console.WriteLine("Enter text (to exit press enter than qx)");
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("qx") == false)
                {

                    sb.AppendLine(input);
                }
                else
                    break;
            }
            string line = sb.ToString();
            File.AppendAllText(FileName, line);
            Console.WriteLine("File is Save");
        }
        public TextFile(string fileName)
        {
            FileName = fileName;

            Textin = File.ReadAllText(fileName);

        }
        public void Show()
        {
            Console.WriteLine(Textin);
        }

        public void Edit(string fileName, string edt)
        {

            if (File.Exists(fileName))
            {
                Textin = File.ReadAllText(fileName);
                int count = -1;
                int i = 0;
                int x = -1;
                while (i != -1)
                {
                    i = Textin.IndexOf(edt, x + 1);
                    x = i;
                    count++;
                }
                if (count == 0)
                    Console.WriteLine($"No {edt} in text");
                else if (count == 1)
                {
                    Console.WriteLine("Input corrected word/sentence");
                    string correct = Console.ReadLine();
                    Textin = Textin.Replace(edt, correct);
                    File.WriteAllText(fileName, Textin);
                    Console.WriteLine("File is Update");
                }
                else
                {
                    Console.WriteLine("Input corrected word/sentence");
                    string correct = Console.ReadLine();
                    Console.WriteLine($"This word/sentence occurs {count} times in the text");
                    Console.WriteLine("Do need edit all this words/sentence in text or one ");
                    Console.WriteLine("If you want coorect only 1 word input number word (1 - if first word, 2 - only second find, etc)");
                    Console.WriteLine("If you want coorect all word input \"-1\" ");
                    int choose = int.Parse(Console.ReadLine());
                    if (choose == -1)
                    {
                        Textin = Textin.Replace(edt, correct);
                        File.WriteAllText(fileName, Textin);
                    }
                    else
                    {
                        string[] Texts = Textin.Split(' ', '.', ',', ';', '!', '\n', '?', ':');
                        count = 0;
                        for (i = 0; i < Texts.Length; i++)
                        {
                            if (Texts[i].Trim() == edt)
                            {
                                count++;
                            }
                            if (count == choose && Texts[i].Trim() == edt)
                            {
                               Texts[i] = " "+correct+" ";
                            }
                        }
                        string temp = String.Empty;
                        foreach (var item in Texts)
                        {
                            Console.WriteLine(item);
                            temp += item;
                        }
                        Console.WriteLine(temp);
                        File.WriteAllText(fileName,temp);
                    }
                }

            }

            else
                Console.WriteLine("Errore file doesnt exist");

        }

        public void Deleted()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            else
                Console.WriteLine("Errore file doesnt exist");

        }

    }

}
