using Aplicatie.Core.Models;

namespace Aplicatie.Core.Services;

public class Requests<TMessage,TReply>
{
   public event Action<TMessage, Action<TReply>>? Cerere ;
   
   
}

public class Notifications<TMessage>
{
    public static event Action<TMessage>? Notificare;

    protected virtual void OnNotificare(TMessage message)
    {
        Notificare?.Invoke(message);
    }
}