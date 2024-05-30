using MVPTema3Magazin.Models;

public class MainViewModel : IDisposable
{
    private MyDbContext _context;

    // Add a property for the connection message
    public string ConnectionMessage { get; private set; }

    public MainViewModel()
    {
        _context = new MyDbContext();
        try
        {
            _context.TestConnection();
            ConnectionMessage = "Database connection successful!";
        }
        catch
        {
            ConnectionMessage = "Database connection failed!";
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
