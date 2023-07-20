using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IRepository<T>
{
    Task<int> GetTotalCountAsync();
    IAsyncEnumerable<T> GetPagedDataAsync(int pageNumber, int pageSize);
}

public class YourRepository : IRepository<YourModel>
{
    private readonly YourDbContext _dbContext;

    public YourRepository(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _dbContext.YourModels.CountAsync();
    }

    public IAsyncEnumerable<YourModel> GetPagedDataAsync(int pageNumber, int pageSize)
    {
        int recordsToSkip = (pageNumber - 1) * pageSize;

        return _dbContext.YourModels
            .OrderBy(x => x.Id) // Order your data as needed (e.g., based on a unique identifier)
            .Skip(recordsToSkip)
            .Take(pageSize)
            .AsAsyncEnumerable();
    }
}



using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

public partial class MainWindow : Window
{
    private readonly IRepository<YourModel> _repository;
    private int _currentPage = 1;
    private int _pageSize = 10;

    public ObservableCollection<YourModel> YourModels { get; set; }

    public MainWindow(IRepository<YourModel> repository)
    {
        _repository = repository;
        YourModels = new ObservableCollection<YourModel>();

        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        // Clear the collection before loading new data
        YourModels.Clear();

        // Retrieve data using IAsyncEnumerable with paging
        var totalCount = await _repository.GetTotalCountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / _pageSize);

        if (_currentPage > totalPages)
        {
            _currentPage = totalPages;
        }

        var pagedData = _repository.GetPagedDataAsync(_currentPage, _pageSize);

        await foreach (var model in pagedData)
        {
            YourModels.Add(model);
        }
    }

    private async void NextButton_Click(object sender, RoutedEventArgs e)
    {
        _currentPage++;
        await LoadDataAsync();
    }

    private async void PreviousButton_Click(object sender, RoutedEventArgs e)
    {
        _currentPage--;
        if (_currentPage < 1)
        {
            _currentPage = 1;
        }

        await LoadDataAsync();
    }
}

