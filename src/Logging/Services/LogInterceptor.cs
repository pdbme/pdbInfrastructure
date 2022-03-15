using pdbme.pdbInfrastructure.Logging.Commands;
using Serilog.Core;
using Spectre.Console.Cli;

namespace pdbme.pdbInfrastructure.Logging.Services;

public class LogInterceptor : ICommandInterceptor
{
    public static readonly LoggingLevelSwitch LogLevel = new();

    public void Intercept(CommandContext context, CommandSettings settings)
    {
        if (settings is LogCommandSettings logSettings)
        {
            LogLevel.MinimumLevel = logSettings.LogLevel;
        }
    }
}
