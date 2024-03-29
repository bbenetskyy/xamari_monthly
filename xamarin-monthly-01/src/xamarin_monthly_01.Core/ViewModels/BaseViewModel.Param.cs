using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace xamarin_monthly_01.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
        where TParameter : notnull
    {
        public abstract void Prepare(TParameter parameter);
    }
}
