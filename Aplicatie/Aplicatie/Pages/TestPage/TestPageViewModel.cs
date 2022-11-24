using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie.Pages;

public class TestPageViewModel : INotifyPropertyChanged
{
    #region Fields
    private string _username;
    private Command _LoginCommand;
    IValidator<TestPageViewModel> testPageValidation;
    #endregion

    #region Constructor
    [Obsolete]
    public TestPageViewModel(IValidator<TestPageViewModel> validator)
    {
        testPageValidation = validator;
    }
    #endregion
    #region Properties
    public event PropertyChangedEventHandler PropertyChanged;
    public string UserName
    {
        get { return _username; }
        set
        {
            _username = value;
            OnPropertyChanged(nameof(UserName));
        }
    }
    public string Password { get; set; }
    public string LoginError { get; set; }

    public Command LoginCommand
    {
        get
        {
            return _LoginCommand ?? (_LoginCommand = new Command(ExecuteLoginCommand));
        }
    }
    #endregion
    #region Methods
    public void ExecuteLoginCommand()
    {

        var result = testPageValidation.Validate(this);
        if (result.IsValid)
            LoginError = string.Empty;
    }
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;

        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
    #endregion
}
