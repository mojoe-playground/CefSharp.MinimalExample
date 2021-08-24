dotnet build CefSharp.MinimalExample.OffScreen\CefSharp.MinimalExample.OffScreen.netcore.csproj
dotnet publish Launcher\Launcher.csproj -p:PublishSingleFile=true --self-contained false -r win-x64
Launcher\bin\Debug\net5.0-windows\win-x64\publish\Launcher.exe