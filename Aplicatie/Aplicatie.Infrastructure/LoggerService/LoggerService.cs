


using Aplicatie.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Aplicatie.Infrastructure.Services;

public class LoggerService : ILoggerService
{

    //ILogger _loggerGeneral;

    public LoggerService(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
    }

    //public void InitLoggerService(IConfiguration loggerConfiguration)
    //{
    //    try
    //    {
    //        _loggerGeneral = new LoggerConfiguration()
    //        .ReadFrom.Configuration(loggerConfiguration)
    //        .CreateLogger();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw;
    //    }

    //}

    public void Logheaza_INFO(string mesaj, params object?[]? objects)
    {
        try
        {
            Log.Logger.Information(mesaj, objects);
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public void Logheaza_INFO(string mesaj)
    {
        try
        {
            Log.Logger.Information(mesaj);
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

}
