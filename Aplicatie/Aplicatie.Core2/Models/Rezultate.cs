namespace Aplicatie.Core.Models;


public record FlowCreatedMessage(int FlowSettingsId, USBDeviceEvent USBEvent, Guid Id);

public record ScanResultModel(bool Rezultat);

public record Etapa2ResultModel(string Etapa2Nume, List<ItemEtapa2Model> Etapa2ListaItemi);


public record ItemEtapa2Model(string ItemNume, string ItemValoare, SubItemEtapa2Model SubItemEtapa);

public record SubItemEtapa2Model(string SubItemNume, string SubItemValoare);