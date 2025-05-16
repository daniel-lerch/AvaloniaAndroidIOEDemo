using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;

namespace Avalonia.IOEDemo.Android;

[Activity(
    Label = "Avalonia.IOEDemo.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
[IntentFilter(["android.intent.action.VIEW"],
    Categories = [Intent.CategoryDefault, Intent.CategoryBrowsable],
    DataSchemes = ["file", "content"],
    DataMimeType = "*/*")]
public class MainActivity : AvaloniaMainActivity<App>
{
    private const string Tag = "Avalonia.IOEDemo.Android.MainActivity";

    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI();
    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        HandleIntent(Intent);
    }

    protected override void OnNewIntent(Intent? intent)
    {
        base.OnNewIntent(intent);
        HandleIntent(intent);
    }

    private void HandleIntent(Intent? intent)
    {
        if (intent?.Action == Intent.ActionView && intent.Data != null)
        {
            string url = intent.Data.ToString() ?? "intent.Data was empty";
            Log.Debug(Tag, "Received URL: " + url);

            if (Avalonia.Application.Current is App app)
            {
                app.MainViewModel.FileName = url;
            }
            else
            {
                Log.Error(Tag, "App is null in HandleIntent");
            }
        }
    }
}
