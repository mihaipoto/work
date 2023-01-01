using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Services;

public class GuidService
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
