using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace Aplicatie.Core.Models;

public partial class FluxInLucru : ObservableObject, IDisposable
{
    private bool _disposedValue;
    private readonly IServiceProvider _services;

    private readonly ILogger<FluxInLucru> _logger;

    public event Action<ScanResultModel>? FlowScanned;

    public event Action<Etapa2ResultModel, Action>? Etapa2Result;

    public Guid Id { get; init; }

    [ObservableProperty]
    private USBDeviceEvent? _evenimentUSB;

    [ObservableProperty]
    private FlowItemSettings? _flowConfig;

    [ObservableProperty]
    private ScanResultModel? _rezultatEtapa1;

    [ObservableProperty]
    private Etapa2ResultModel? _rezultatEtapa2;

    [ObservableProperty]
    private bool? _isFinished;

    public FluxInLucru(IServiceProvider services)
    {
        Id = Guid.NewGuid();
        _state = new()
        {
            ["ID"] = Id,
        };
        _services = services;
        _logger = _services.GetService<ILogger<FluxInLucru>>();
    }

    public async Task StartFlux()
    {
        _state.Add(key: "STARTED", DateTime.Now);

        _logger.LogInformation(eventId: new((int)Etape.FluxStarted, Id.ToString()), message: "START {thread}", args: Thread.CurrentThread.ManagedThreadId);
        _ = Task.Run(StartEtapa1);
    }

    private async Task StartEtapa1()
    {
        _state.Add(key: "Etapa 1", DateTime.Now);

        //FlowScanned?.Invoke(RezultatEtapa1);
        await Task.Delay(2000);
        _ = Task.Run(StartEtapa2);
        _logger.LogInformation(eventId: new((int)Etape.Etapa1), message: "Etapa 1 {thread}", args: Thread.CurrentThread.ManagedThreadId);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            RezultatEtapa1 = new(Rezultat: true);
        });
    }

    private enum Etape
    {
        FluxStarted = 100,
        Etapa1 = 101,
        Etapa2 = 102,
        Etapa3 = 103
    }

    private Dictionary<string, object> _state;

    public async Task StartEtapa2()
    {
        _state.Add(key: "Etapa 2", DateTime.Now);

        var subitem21 = new SubItemEtapa2Model(SubItemNume: "subitemnume1", SubItemValoare: "subitemvaloare1");
        var subitem22 = new SubItemEtapa2Model(SubItemNume: "subitemnume2", SubItemValoare: "subitemvaloare2");
        var subitem23 = new SubItemEtapa2Model(SubItemNume: "subitemnume3", SubItemValoare: "subitemvaloare3");
        var etapa2listaitemi = new List<ItemEtapa2Model>();
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item1nume", ItemValoare: "item1valoare", SubItemEtapa: subitem21));
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item2nume", ItemValoare: "item2valoare", SubItemEtapa: subitem22));
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item3nume", ItemValoare: "item3valoare", SubItemEtapa: subitem23));
        await Task.Delay(2000);

        _logger.LogInformation(eventId: new((int)Etape.Etapa2), message: "Etapa 2 {thread}", args: Thread.CurrentThread.ManagedThreadId);
        MainThread.BeginInvokeOnMainThread(() =>
        {
            RezultatEtapa2 = new(Etapa2Nume: "numeEtapa2", Etapa2ListaItemi: etapa2listaitemi);
        });
        _ = Task.Run(StartEtapa3);
    }

    public async Task StartEtapa3()
    {
        _state.Add(key: "Etapa 3", DateTime.Now);

        await Task.Delay(2000);
        _logger.LogInformation(eventId: new((int)Etape.Etapa3), message: "Etapa 3 LOG 1 {thread}", args: Thread.CurrentThread.ManagedThreadId);
        await Task.Delay(2000);
        _logger.LogInformation(eventId: new((int)Etape.Etapa3), message: "Etapa 3 LOG 2 {thread}", args: Thread.CurrentThread.ManagedThreadId);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            _logger.LogInformation(eventId: new((int)Etape.Etapa3), message: "FINISHED  {thread}", args: Thread.CurrentThread.ManagedThreadId);
            IsFinished = true;
        });
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}