using Aplicatie.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Core;




/// <summary>
/// SERVICIU
/// </summary>
public class FlowControl
{
    private readonly IConfigService _configService;
    private readonly ILoggerService _loggerService;



    /// <summary>
    /// jjjjjjjj
    /// </summary>
    /// <param name="configService"></param>
    /// <param name="loggerService"></param>
    public FlowControl(
        IConfigService configService,
        ILoggerService loggerService
        )
	{
        _configService = configService;
        _loggerService = loggerService;
        _loggerService.InitLoggerService(_configService.LoggingConfig);
        
    }




}
