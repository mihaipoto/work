using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiApp1.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ILogger<MainViewModel> _logger;
    private readonly IDbContextFactory<LogDbContext> _dbContextFactory;
    private LogDbContext _context;

    public MainViewModel(ILogger<MainViewModel> logger,
        IDbContextFactory<LogDbContext> dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _context = _dbContextFactory.CreateDbContext();

        LastId = _context.Log.AsNoTracking().OrderByDescending(l => l.Id).First().Id;

        CurrentPage = 0;



    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CountButtonText))]
    private int _count;

    [ObservableProperty]
    bool _isRefreshing;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(LastId))]
    [NotifyPropertyChangedFor(nameof(CurrentId))]
    private long _currentPage;

    public long LastId { get; set; }


    public long CurrentId => LastId - (50 * CurrentPage);


    public string CountButtonText => Count switch
    {
        1 => $"Clicked {Count} time",
        > 1 => $"Clicked {Count} times",
        _ => "Click Button"
    };

    [RelayCommand]
    public void IncrementCounter()
    {

        Count++;

        _logger.LogInformation(CountButtonText);

    }




    public List<LogEntry> Logs { get; set; }


    [RelayCommand]
    public async Task GetLogs()
    {
        try
        {
            IsRefreshing = true;
            if (CurrentPage > 0)
            {
                CurrentPage--;

            }

            var last = await _context.Log.AsNoTracking().OrderByDescending(l => l.Id).FirstAsync();
            LastId = last.Id;


            Logs = await _context.Log.AsNoTracking().OrderByDescending(l => l.Id).Where(l => l.Id <= CurrentId).Take(50).ToListAsync();
            OnPropertyChanged(nameof(Logs));
            IsRefreshing = false;



        }
        catch (Exception ex)
        {

            await Application.Current.MainPage.DisplayPromptAsync(title: "Eroare", message: ex.Message);
        }


    }

    [RelayCommand]
    public async Task GetBackLogs()
    {
        try
        {
            IsRefreshing = true;
            CurrentPage++;
            var last = await _context.Log.OrderByDescending(l => l.Id).FirstAsync();
            LastId = last.Id;

            Logs = await _context.Log.AsNoTracking().OrderByDescending(l => l.Id).Where(l => l.Id <= CurrentId).Take(50).ToListAsync();


            OnPropertyChanged(nameof(Logs));

            IsRefreshing = false;



        }
        catch (Exception ex)
        {

            await Application.Current.MainPage.DisplayPromptAsync(title: "Eroare", message: ex.Message);
        }


    }


}
