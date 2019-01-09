﻿using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PropertyChanged;
using Surrender_20.Core.Interface;
using Surrender_20.Forms.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Surrender_20.Forms.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MasterViewModel : MvxViewModel
    {
        public string Title { get; set; } = "Menu";

        public ICommand NavigateCommand { get; set; }


        public ObservableCollection<MenuListElement> MenuElements { get; set; }

        public MasterViewModel(IMasterDetailService masterDetailService)
        {

            MenuElements = new ObservableCollection<MenuListElement>();

            MenuElements.Add(new MenuListElement { Name = "SurrenderAt20", Page = Pages.SurrenderHome });
            MenuElements.Add(new MenuListElement { Name = "LOL Official", Page = Pages.Official });

            NavigateCommand = new MvxCommand<MenuListElement>((Parameter) =>
            {
                masterDetailService.MasterPageSelect(Parameter.Page);
            });
        }
    }

    public class MenuListElement
    {
        public Pages Page { get; set; }
        public string Name { get; set; }
    }
}