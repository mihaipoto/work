
using CommunityToolkit.Maui.Views;


namespace Aplicatie.Services;

public class DialogService : IDialogService
{
    public Task<bool> ShowConfirmationAsync(string title, string message)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, "ok", "no");
    }

    public Task ShowAlertAsync(string title, string message, string accept, string cancel)
    {
        return Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }

    //public async Task ShowAlertAsync2(string title, string message, string accept, string cancel)
    //{
    //    await Application.Current.MainPage.ShowPopupAsync(new PopUpPage());
    //}

    public Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons)
    {
        return Application.Current.MainPage.DisplayActionSheet(title, message, destruction, buttons);
    }

    public Task ShowPrompt(string title, string message)
    {
        return Application.Current.MainPage.DisplayPromptAsync(title, message);
    }

    //public Task<bool> SnackBarAsync(string message, string actionText, Func<task> action)
    //{
    //    return Application.Current.MainPage.DisplaySnackBarAsync(message, actionText, action);
    //}
}