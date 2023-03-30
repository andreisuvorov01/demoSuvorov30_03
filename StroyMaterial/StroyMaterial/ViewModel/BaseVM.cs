﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StroyMaterial.ViewModel
{
    public class BaseVM : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string NameOf = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameOf));
        }
    }
}
