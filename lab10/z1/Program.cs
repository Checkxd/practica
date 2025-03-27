using System;

public class Program
{
    public static void Main()
    {
        FileManager fileManager = new FileManager();
        FileInfoProvider fileInfoProvider = new FileInfoProvider();

        string filePath = "shatalin.aa.txt";
        string copyPath = "shatalin_copy.aatxt";
        string movedPath = "new_directory/shatalin.aa.txt";
        string renamedPath = "shatalin.io.txt";

        fileManager.CreateFile(filePath, "Привет, мир!");
        Console.WriteLine(File.ReadAllText(filePath));

        fileInfoProvider.GetFileInfo(filePath);

        fileManager.CopyFile(filePath, copyPath);
        Console.WriteLine($"Копия существует: {File.Exists(copyPath)}");

        Directory.CreateDirectory(Path.GetDirectoryName(movedPath));
        fileManager.MoveFile(filePath, movedPath);
        Console.WriteLine($"Файл перемещен: {File.Exists(movedPath)}");

        fileManager.RenameFile(movedPath, renamedPath);
        Console.WriteLine($"Файл переименован: {File.Exists(renamedPath)}");

        try
        {
            fileManager.DeleteFile(renamedPath);
            Console.WriteLine($"Файл удален: {File.Exists(renamedPath)}");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        bool areEqual = fileInfoProvider.CompareFilesBySize(filePath, copyPath);
        Console.WriteLine($"Файлы равны по размеру: {areEqual}");

        fileManager.DeleteFilesByPattern(".", "*.txt");

        fileManager.ListFiles(".");

        try
        {
            var attributes = fileInfoProvider.GetFileAttributes(filePath);
            Console.WriteLine($"Атрибуты файла: {attributes}");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}