using Microsoft.Extensions.Configuration;

namespace Aplicatie.Core.Contracts;

public interface ILoggerService
{
    //void InitLoggerService(IConfiguration loggerConfiguration);
    void Logheaza_INFO(string mesaj);
    void Logheaza_INFO(string mesaj, params object?[]? objects);
}