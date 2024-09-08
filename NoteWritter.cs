using System;
namespace Notes.CLI;

public class NoteWritter
{

    public static async Task WriteNote(string path,string note)
    {
        string TheNote = $"{DateTime.Now}: {note}";
        await File.AppendAllTextAsync(path, TheNote);
    }

    public static async Task WriteNoteWithPath(string path,string note)
    {
        string TheNote = $"{DateTime.Now}: {note}"; 
        
        await File.AppendAllTextAsync(path, TheNote);
    }

}