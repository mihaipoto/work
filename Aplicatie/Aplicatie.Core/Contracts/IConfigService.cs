using Aplicatie.Core.Modele;
using Microsoft.Extensions.Configuration;

namespace Aplicatie.Core.Contracts;

public interface IConfigService
{
    IConfiguration LoggingConfig { get; }

    AppConfig AppConfig { get; }
}