using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace xamarin_monthly_01.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        protected virtual IMvxNavigationService Navigation { get; }

        public BaseViewModel()
        {
            Navigation = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }
    }
}
