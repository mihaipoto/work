namespace Aplicatie.Services
{
    public interface IDialogService
    {
        Task<string> ShowActionsAsync(string title, string message, string destruction, params string[] buttons);
        Task ShowAlertAsync(string title, string message, string accept, string cancel);
        Task ShowAlertAsync2(string title, string message, string accept, string cancel);
        Task<bool> ShowConfirmationAsync(string title, string message);
        Task ShowPrompt(string title, string message);
    }
}