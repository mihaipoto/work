using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {


        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;

        }

        private void SfDataGrid_AutoGeneratingColumn(object sender, Syncfusion.Maui.DataGrid.DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "Timestamp")
            {
                e.Column.Format = "MMM yy";
            }
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //    {
        //        var txt = $"Clicked {count} time";
        //        CounterBtn.Text = txt;
        //        _logger.LogInformation(txt);
        //    }

        //    else
        //    {
        //        var txt = $"Clicked {count} times";
        //        CounterBtn.Text = txt;
        //        _logger.LogInformation(txt);
        //    }


        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }
}