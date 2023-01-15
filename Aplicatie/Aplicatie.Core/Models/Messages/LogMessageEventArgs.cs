namespace Aplicatie.Core.Models;

public class LogMessageEventArgs<T> : EventArgs
{
    public T Message { get; init; }

	public LogMessageEventArgs(T message)
	{
		Message = message;
	}
}