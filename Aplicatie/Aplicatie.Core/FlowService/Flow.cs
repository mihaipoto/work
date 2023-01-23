using Aplicatie.Core.Models.Configuratie;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Aplicatie.Core.Models;

public class Flow
{
   

    

    public event Action<ScanResultModel> FlowScanned;

    public event Action<Etapa2ResultModel, Action> Etapa2Result;

    

    public Guid Id { get; init; }

    public USBDeviceEvent EvenimentUSB { get; set; }

    public FlowItemSettings FlowConfig { get; set; }

    public ScanResultModel RezultatScanare { get; set; }

    public Etapa2ResultModel RezultatEtapa2 { get; set; }

    public Flow()
    {
        Id = Guid.NewGuid();
        
    }
    
    public void StartFlux()
    {
        OnEtapa2Result();
    }

    private void OnFlowScanned()
    {
        RezultatScanare = new(Rezultat: true);
        FlowScanned?.Invoke(RezultatScanare);
        Task.Delay(2000);
        OnEtapa2Result();
    }

    private void OnEtapa2Result()
    {
        var subitem21 = new SubItemEtapa2Model(SubItemNume: "subitemnume1", SubItemValoare: "subitemvaloare1");
        var subitem22 = new SubItemEtapa2Model(SubItemNume: "subitemnume2", SubItemValoare: "subitemvaloare2");
        var subitem23 = new SubItemEtapa2Model(SubItemNume: "subitemnume3", SubItemValoare: "subitemvaloare3");
        var etapa2listaitemi = new List<ItemEtapa2Model>();
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item1nume", ItemValoare: "item1valoare", SubItemEtapa: subitem21));
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item2nume", ItemValoare: "item2valoare", SubItemEtapa: subitem22));
        etapa2listaitemi.Add(new ItemEtapa2Model(ItemNume: "item3nume", ItemValoare: "item3valoare", SubItemEtapa: subitem23));

        RezultatEtapa2 = new(Etapa2Nume: "numeEtapa2", Etapa2ListaItemi: etapa2listaitemi);
        Debug.WriteLine("Etapa 2 in Model" + Thread.CurrentThread.ManagedThreadId);
        Etapa2Result?.Invoke(RezultatEtapa2,CallbackEtapa2result);
    }


    void CallbackEtapa2result()
    {
        Debug.WriteLine("callback Etapa 2 in Model" + Thread.CurrentThread.ManagedThreadId);
    }

   
   
   

   
}