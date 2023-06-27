using Microsoft.Extensions.Logging;
using Serilog;
using System.Diagnostics;

namespace Aplicatie.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private readonly ILoggerFactory _loggerFactory;

    //ILogger _loggerGeneral;

    public LoggerService(ILoggerFactory loggerFactory)
    {
        //Log.Logger = new LoggerConfiguration()
        //        .ReadFrom.Configuration(configuration)
        //        .WriteTo.Console()
        //        .CreateLogger();
        _loggerFactory = loggerFactory;

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

            Debug.WriteLine(ex);
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

            Debug.WriteLine(ex);
        }

    }

}
