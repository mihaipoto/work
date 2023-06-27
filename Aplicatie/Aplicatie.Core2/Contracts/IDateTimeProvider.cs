namespace Aplicatie.Core.Contracts;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}