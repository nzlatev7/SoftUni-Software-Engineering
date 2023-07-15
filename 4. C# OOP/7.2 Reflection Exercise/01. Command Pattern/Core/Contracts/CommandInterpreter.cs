using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] arguments = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = arguments[0];

            string[] commandArguments = arguments.Skip(1).ToArray();

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(x => x.IsClass)
                .FirstOrDefault(x => x.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            if (command == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            return command.Execute(commandArguments);
        }
    }
}
