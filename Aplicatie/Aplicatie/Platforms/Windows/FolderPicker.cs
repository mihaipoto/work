using Aplicatie.Services;
using WindowsFolderPicker = Windows.Storage.Pickers.FolderPicker;

namespace Aplicatie.Platforms.Windows;

public class FolderPicker 
{
    public async Task<string> PickFolder()
    {
        var folderPicker = new WindowsFolderPicker();
        // Make it work for Windows 10
        folderPicker.FileTypeFilter.Add("*");
        // Get the current window's HWND by passing in the Window object
        var hwnd = ((MauiWinUIWindow)App.Current.Windows[0].Handler.PlatformView).WindowHandle;

        // Associate the HWND with the file picker
        WinRT.Interop.InitializeWithWindow.Initialize(folderPicker, hwnd);

        var result = await folderPicker.PickSingleFolderAsync();

        return result.Path;
    }
}