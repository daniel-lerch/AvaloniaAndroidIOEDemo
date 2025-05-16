using ReactiveUI;

namespace Avalonia.IOEDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string _fileName = "No file opened";
    public string FileName
    {
        get => _fileName;
        set => this.RaiseAndSetIfChanged(ref _fileName, value);
    }
}
