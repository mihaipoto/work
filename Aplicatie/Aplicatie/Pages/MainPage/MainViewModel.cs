using Aplicatie.Infrastructure.Services;
using Aplicatie.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Text;


namespace Aplicatie.ViewModels;

public partial class MainViewModel : ObservableObject
{

    private DialogService _dialogService;
    private ConfigService _cf;


    

    public MainViewModel()
    {
        InitMainViewModel();
    }

    async void InitMainViewModel()
    {
        _dialogService = new DialogService();

        try
        {
            
            _cf = new ConfigService();
        }
        catch (Exception ex)
        {
            await _dialogService.ShowAlertAsync2("EXCEPTIE", $"EROARE: Mesaj: {ex.Message}, Sursa: {ex.Source}", "OK" , "N-amce face!");
           
        }

        
    }

 
    [RelayCommand]
    public async void Showpopup()
    {
        await _dialogService.ShowAlertAsync2("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async void ShowActions()
    {
        await _dialogService.ShowActionsAsync("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async void DisplayPrompt()
    {
        await _dialogService.ShowPrompt("Alert", "You have been alerted");
    }

   

}