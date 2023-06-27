namespace MauiApp1.Models;

//public class LogEntry
//{
//    public int Id { get; set; }
//    public string Timestamp { get; set; }
//    public string Level { get; set; }

//    public string Exception { get; set; }

//    public string RenderedMessage { get; set; }

//    public string Properties { get; set; }
//    // Add additional properties as needed
//}

public class LogEntry
{
    public long Id { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string Level { get; set; }
    public string Exception { get; set; }
    public string RenderedMessage { get; set; }
    public string Properties { get; set; }

    public LogEntry()
    {

    }
    public LogEntry(long id_, DateTimeOffset Timestamp_, string Level_, string Exception_, string RenderedMessage_, string Properties_)
    {
        this.Id = id_;
        this.Timestamp = Timestamp_;
        this.Level = Level_;
        this.Exception = Exception_;
        this.RenderedMessage = RenderedMessage_;
        this.Properties = Properties_;
    }
}