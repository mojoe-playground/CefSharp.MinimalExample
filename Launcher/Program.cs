using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Launcher
{
    class Program
    {
        static int Main(string[] args)
        {
            // Find CefSharp.MinimalExample.OffScreen folder
            var d = new FileInfo(Environment.GetCommandLineArgs()[0]).Directory;
            while (d != null && !d.EnumerateDirectories("CefSharp.MinimalExample.OffScreen").Any())
                d = d.Parent;

            if (d == null)
            {
                Console.WriteLine("CefSharp.MinimalExample.OffScreen folder not found");
                return -1;
            }

            // Find dll to load
            var f = new FileInfo(Path.Combine(d.FullName, "CefSharp.MinimalExample.OffScreen", "bin.netcore", "Debug", "net5.0-windows", "CefSharp.MinimalExample.OffScreen.netcore.dll"));

            if (!f.Exists)
            {
                Console.WriteLine("CefSharp.MinimalExample.OffScreen.dll not found, build in Debug first");
                return -1;
            }

            // Load dll
            var a = Assembly.LoadFrom(f.FullName);
            var m = a.GetType("CefSharp.MinimalExample.OffScreen.Program")?.GetMethod("Startup");

            if (m == null)
            {
                Console.WriteLine("Startup method not found");
                return -1;
            }

            // Run dll
            m.Invoke(null, null);

            return 0;
        }
    }
}
