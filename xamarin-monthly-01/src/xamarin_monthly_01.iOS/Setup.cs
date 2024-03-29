using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using Serilog;
using Serilog.Extensions.Logging;
using UIKit;

namespace xamarin_monthly_01.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, UI.App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.NSLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
