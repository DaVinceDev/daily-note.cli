using System;
using System.IO;
namespace Notes.CLI;
class Program
{
    static string path = "/";
    static async Task Main(string[] args)
    {
        if(args.Length == 0)
        {
            Console.WriteLine("Hello there! Thanks for using daily note!");
            Console.WriteLine("Here are some commmands you can use:");
            Console.WriteLine("'add' -> add a note to the static path");
            Console.WriteLine($"'to-file' -> add a note to the speficic path. eg: to-file {"<path>"}/bs.txt {"<note>"}");
            Console.WriteLine("'note-with-path' -> a new file its created in a specific dir with a custom file name ");

            return;
        }
        string command = args[0].ToLower(); //Making it lowercase

        switch(command)
        {
            case "add":
                if(args.Length < 2)
                {
                    Console.WriteLine("You can use it like this: add <note>");
                }

                else
                {
                   await NoteWritter.WriteNote(path,string.Join(" ", args[1..]));
                }

            break;

            case "to-file":
            path = args[1];
            await NoteWritter.WriteNote(path,"\n"+args[2]);
            break;

            case "note-with-path":
            path = args[1];
            new Task(() => File.Create(path+"/untitled.txt"));
            await NoteWritter.WriteNoteWithPath(path,"\n"+args[2]);
            break;

            case "tool-help":
            break;

            case "set-path":
            path = args[2];
            break;

        }
    }
}