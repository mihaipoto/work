using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ConfigExtension;
using Microsoft.Extensions.Options;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Text;

namespace MauiApp2;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel(OrderInfoRepository orders, IOptionsMonitor<SettingsOptionsJson> optionsMonitor, DialogService ds)
    {
        _orders = orders;
        this.ds = ds;
        _optionsMonitor = optionsMonitor.Get(name: nameof(SettingsOptionsJson));
        Actual = "Manual";
        Expected = new List<string>
        {
            "Automat",
            "Hibrid",
            "Manual"
        };
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(GetBadgeCount))]
    public int badgeCount = 0;

    [ObservableProperty]
    public string cevaMesaj;

    private readonly OrderInfoRepository _orders;
    private readonly DialogService ds;
    private readonly SettingsOptionsJson _optionsMonitor;

    public IEnumerable<OrderInfo> OrderInfoCollection
    {
        get
        {
            return _orders.OrderInfoCollection;
        }
    }

    public string GetBadgeCount
    {
        get
        {
            return BadgeCount.ToString();
        }
    }

    [RelayCommand]
    public void CreateDocument()
    {
        StringBuilder sb = new();

        using (FileStream inputFileStream = new FileStream(Path.GetFullPath(@"E:\sample.docx"), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (WordDocument wordDocument = new WordDocument(inputFileStream, FormatType.Docx))
            {
                foreach (WSection section in wordDocument.Sections)
                {
                    var paragrafe = section.HeadersFooters.OddHeader.Paragraphs;
                    foreach (var paragraf in paragrafe)
                    {
                        sb.Append(((Syncfusion.DocIO.DLS.WParagraph)paragraf).Text);
                        sb.Append("[:delimiter:]");
                    }
                }

                //Creates file stream.
                using (FileStream outputFileStream = new FileStream(Path.GetFullPath(@"e:\Result.docx"), FileMode.Create, FileAccess.ReadWrite))
                {
                    //Saves the Word document to file stream.
                    wordDocument.Save(outputFileStream, FormatType.Docx);
                }
                //Closes the document.
                wordDocument.Close();
            }
        }
        var header = sb.ToString();
    }

    [RelayCommand]
    public void IncrementBadge()
    {
        BadgeCount++;
    }

    [RelayCommand]
    public async void Showpopup()
    {
        await ds.ShowAlertAsync2("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async void ShowActions()
    {
        await ds.ShowActionsAsync("Alert", "You have been alerted", "OK", "Cancel");
    }

    [RelayCommand]
    public async void DisplayPrompt()
    {
        await ds.ShowPrompt("Alert", "You have been alerted");
    }

    [RelayCommand]
    public async void RequestMessage()
    {
        CevaMesaj = WeakReferenceMessenger.Default.Send<Maesaj>();
    }


    [ObservableProperty]
    string actual;

    [ObservableProperty]
    List<string> expected;




    [RelayCommand]
    void SelectatNou(string valoareNoua)
    {
        Actual = valoareNoua;
    }

}