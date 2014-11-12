﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppsTracker.MVVM;
using AppsTracker.Pages.ViewModels;

namespace AppsTracker.ViewModels
{
    internal sealed class DataHostViewModel : HostViewModel 
    {
        public override string Title
        {
            get
            {
                return "data";
            }
        }
      
        public DataHostViewModel()
        {
            this.Register<Data_logsViewModel>(() => new Data_logsViewModel());
            this.Register<Data_keystrokesViewModel>(() => new Data_keystrokesViewModel());
            this.Register<Data_screenshotsViewModel>(() => new Data_screenshotsViewModel());
            this.Register<Data_dayViewModel>(() => new Data_dayViewModel());

            this.SelectedChild = Resolve(typeof(Data_logsViewModel));
        }

        protected override void Disposing()
        {
            if (_selectedChild != null)
                _selectedChild.Dispose();
            _selectedChild = null;
            base.Disposing();
        }
    }
}
