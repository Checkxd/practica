using System;
using System.IO;

class FileWatcher
{
    private FileSystemWatcher watcher;
    private string importantTxt = "important.txt";
    private string configJson = "config.json";

    public FileWatcher(string path)
    {
        watcher = new FileSystemWatcher(path)
        {
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
            Filter = "*.*",
            EnableRaisingEvents = true
        };

        watcher.Created += OnCreated;
        watcher.Deleted += OnDeleted;
        watcher.Changed += OnChanged;
        watcher.Renamed += OnRenamed;

        // Create protected files
        File.WriteAllText(Path.Combine(path, importantTxt), "Important data");
        File.WriteAllText(Path.Combine(path, configJson), "{\"config\": true}");
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Created: {e.FullPath}");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Deleted: {e.FullPath}");
        if (e.Name == importantTxt || e.Name == configJson)
        {
            RestoreFile(e.FullPath, e.Name);
        }
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Changed: {e.FullPath}");
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Renamed: {e.OldFullPath} to {e.FullPath}");
    }

    private void RestoreFile(string fullPath, string fileName)
    {
        string content = fileName == importantTxt ? "Important data" : "{\"config\": true}";
        File.WriteAllText(fullPath, content);
        Console.WriteLine($"Restored: {fileName}");
    }
}

class Program
{
    static void Main()
    {
        string watchDir = "watchDir";
        Directory.CreateDirectory(watchDir);
        FileWatcher watcher = new FileWatcher(watchDir);

        Console.WriteLine("Watching directory. Press any key to exit...");
        File.Delete(Path.Combine(watchDir, "important.txt")); // Test deletion
        Console.ReadKey();
    }
}