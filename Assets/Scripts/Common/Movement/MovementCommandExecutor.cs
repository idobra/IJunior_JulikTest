using System.Collections.Generic;

public sealed class MovementCommandExecutor : ICommandExecutor
{
    /* 
    Если бы мы использовали DI можно было бы обойтись без синглтона.
    Очень было бы интересно узнать побольше о DI в Unity.
    */
    private List<ICommand> _commands = new List<ICommand>();
    private static MovementCommandExecutor _instance = null;

    private MovementCommandExecutor()
    {
    }

    public static MovementCommandExecutor Instance()
    {
        if (_instance == null)
            _instance = new MovementCommandExecutor();
        return _instance;

    }

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void ExecuteCommands()
    {
        for(var i = 0; i < _commands.Count; i++)
        {
            _commands[i].Execute();
            _commands.Remove(_commands[i]);
        }
    }
}
