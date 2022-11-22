


using Aplicatie.Core.Contracts;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Aplicatie.Infrastructure.Services;

public class LoggerService : ILoggerService
{

    ILogger _loggerGeneral;

    public LoggerService()
    {

    }

    public void InitLoggerService(IConfiguration loggerConfiguration)
    {
        try
        {
            _loggerGeneral = new LoggerConfiguration()
            .ReadFrom.Configuration(loggerConfiguration)
            .CreateLogger();
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

    public void Logheaza_INFO(string mesaj, params object?[]? objects)
    {
        try
        {
            _loggerGeneral.Information(mesaj, objects);
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
            _loggerGeneral.Information(mesaj);
        }
        catch (Exception ex)
        {

            throw;
        }
        
    }

}
