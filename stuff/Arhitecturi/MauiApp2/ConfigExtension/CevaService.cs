using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace ConfigExtension;

public class CevaService : ObservableObject, IRecipient<Maesaj>
{
    public CevaService()
    {
        WeakReferenceMessenger.Default.RegisterAll(this);
    }

    public void Receive(Maesaj message)
    {
        message.Reply("un Raspuns");
    }
}