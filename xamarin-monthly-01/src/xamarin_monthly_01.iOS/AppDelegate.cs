using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace xamarin_monthly_01.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override void PerformActionForShortcutItem(UIApplication application,
            UIApplicationShortcutItem shortcutItem,
            UIOperationHandler completionHandler)
            => Xamarin.Essentials.Platform.PerformActionForShortcutItem(application,
                shortcutItem,
                completionHandler);
    }
}
