namespace Aplicatie.Services;

public interface IFolderPicker
{
    Task<string> PickFolder();
}