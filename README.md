# Avalonia Issue 17943

This project is a minimal reproducible example for [AvaloniaUI/Avalonia#17943](https://github.com/AvaloniaUI/Avalonia/issues/17943)

## Steps to reproduce

1. Build and run `Avalonia.IOEDemo.Android` on an Android device or emulator.
2. While app is running, go to file explorer and open any file using `Avalonia.IOEDemo.Android`.
3. Watch an InvalidOperationException being thrown in the app.

Note that this exception only occurs when the app is already running.
If you force close the app and then open a file, the exception does not occur.
