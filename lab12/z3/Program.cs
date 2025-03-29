using System;

public interface ICommand
{
    void Execute();
}

public class FileManager
{
    public void CopyFile(string source, string destination)
    {
        Console.WriteLine($"Copying file from {source} to {destination}");
    }

    public void MoveFile(string source, string destination)
    {
        Console.WriteLine($"Moving file from {source} to {destination}");
    }
}

public class CopyFileCommand : ICommand
{
    private readonly FileManager _fileManager;
    private readonly string _source;
    private readonly string _destination;

    public CopyFileCommand(FileManager fileManager, string source, string destination)
    {
        _fileManager = fileManager;
        _source = source;
        _destination = destination;
    }

    public void Execute()
    {
        _fileManager.CopyFile(_source, _destination);
    }
}

public class MoveFileCommand : ICommand
{
    private readonly FileManager _fileManager;
    private readonly string _source;
    private readonly string _destination;

    public MoveFileCommand(FileManager fileManager, string source, string destination)
    {
        _fileManager = fileManager;
        _source = source;
        _destination = destination;
    }

    public void Execute()
    {
        _fileManager.MoveFile(_source, _destination);
    }
}

public class FileOperationInvoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main()
    {
        FileManager fileManager = new FileManager();
        ICommand copyCommand = new CopyFileCommand(fileManager, "file1.txt", "file2.txt");
        ICommand moveCommand = new MoveFileCommand(fileManager, "file2.txt", "archive/file2.txt");

        FileOperationInvoker invoker = new FileOperationInvoker();

        invoker.SetCommand(copyCommand);
        invoker.ExecuteCommand();

        invoker.SetCommand(moveCommand);
        invoker.ExecuteCommand();
    }
}