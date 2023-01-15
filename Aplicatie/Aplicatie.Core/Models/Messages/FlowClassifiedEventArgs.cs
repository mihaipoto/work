namespace Aplicatie.Core.Models;

public class FlowClassifiedEventArgs : EventArgs
{
    public RezultatClasificare RezultatClasificare { get; set; }

    public FlowClassifiedEventArgs(RezultatClasificare rezultatClasificare)
    {
        RezultatClasificare = rezultatClasificare;
    }
}

public class RezultatClasificare
{
    public bool Rezultat { get; set; }
    public RezultatClasificare(bool rezultat)
    {
        Rezultat = rezultat;
    }
}