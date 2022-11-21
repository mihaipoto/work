namespace MauiApp2;

public interface IFolderPicker
{
    Task<string> PickFolder();
}