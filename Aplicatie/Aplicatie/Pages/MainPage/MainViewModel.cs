using Aplicatie.Core;
using Aplicatie.Infrastructure.Services;
using Aplicatie.Platforms.Windows;
using Aplicatie.Services;
using Aplicatie.Validations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Serilog;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;

namespace Aplicatie.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    private readonly FolderPicker _folderPicker;
    private string _pickedFolder;


    public ValidatableObject<string> UserName { get; private set; }

    

    public string PickedFolder
    {
        get => _pickedFolder;
        set => SetProperty(ref _pickedFolder, value);
    }

    public ICommand ValidateCommand { get; }

    public MainViewModel(
        IDialogService dialogService,
        INavigationService navigationService,
        FolderPicker folderPicker)
        : base(dialogService,navigationService)
    {
       
        _folderPicker = folderPicker;

        UserName = new ValidatableObject<string>();

        ValidateCommand = new RelayCommand(() => Validate());

        AddValidations();
    }


    private string _name;

    [MinLength(2,ErrorMessage ="lalalal"), MaxLength(10)]
    string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }


    [RelayCommand]
    public async Task Showpopup()
    {
        await DialogService.ShowAlertAsync2("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async Task PickFolder()
    {
        PickedFolder = await _folderPicker.PickFolder();
    }


    
    public AppTheme CurrentTheme  => Application.Current.UserAppTheme;


   

    [RelayCommand]
    public void ToggleDarkLight()
    {
        switch(Application.Current.UserAppTheme)
        {
            case AppTheme.Dark:
                Application.Current.UserAppTheme = AppTheme.Light;
                OnPropertyChanged(nameof(CurrentTheme));
                break;
            case AppTheme.Light:
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                OnPropertyChanged(nameof(CurrentTheme));
                break;
            case AppTheme.Unspecified:
                Application.Current.UserAppTheme = AppTheme.Dark;
                OnPropertyChanged(nameof(CurrentTheme));
                break;
            default:
                break;       
        }  
    }

  
    public bool Validate()
    {
        return UserName.Validate();
       
  
    }


    private void AddValidations()
    {
        UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A username is required." });
        //Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
    }


}