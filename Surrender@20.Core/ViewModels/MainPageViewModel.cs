﻿using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using Surrender_20.Core.Interface;
using Surrender_20.Core.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Surrender_20.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel : MvxViewModel
    {
        private IOperatingSystemService _operatingSystemService;
        private IMvxNavigationService _navigationService;

        public string Title { get; set; } = "Home";

        public ICommand HomeCommand { get; private set; }
        public ICommand PBECommand { get; private set; }
        public ICommand ReleasesCommand { get; private set; }
        public ICommand RedPostsCommand { get; private set; }
        public ICommand RotationsCommand { get; private set; }
        public ICommand EsportsCommand { get; private set; }

        public ICommand NavViewCommand { get; private set; }

        public MainPageViewModel(IMvxNavigationService navigationService, IOperatingSystemService operatingSystemService, IMvxLog log)
        {
            _navigationService = navigationService;
            _operatingSystemService = operatingSystemService;

            if (operatingSystemService.GetSystemType() != SystemType.Android) //TODO remove "if", we use NavView on UWP
            {
                HomeCommand = new MvxAsyncCommand(() => NavigateToList(Setting.Home));
                PBECommand = new MvxAsyncCommand(() => NavigateToList(Setting.PBE));
                ReleasesCommand = new MvxAsyncCommand(() => NavigateToList(Setting.Releases));
                RedPostsCommand = new MvxAsyncCommand(() => NavigateToList(Setting.RedPosts));
                RotationsCommand = new MvxAsyncCommand(() => NavigateToList(Setting.People));
                EsportsCommand = new MvxAsyncCommand(() => NavigateToList(Setting.ESports));
            }
            else
            {
                NavViewCommand = new MvxAsyncCommand<string>((Parameter) => NavigateToDetail(Parameter));
            }
        }

        public async override void ViewAppearing()
        {
            base.ViewAppearing();

            if (_operatingSystemService.GetSystemType() == SystemType.Android)
                await InitializeViewModels();
        }

        private async Task InitializeViewModels()
        {
            await NavigateToList(Setting.Home);
            await NavigateToList(Setting.PBE);
            //await NavigateToList(Setting.Releases);
            //await NavigateToList(Setting.RedPosts);
            //await NavigateToList(Setting.People);
            //await NavigateToList(Setting.ESports);
        }

        private async Task NavigateToList(Setting setting)
        {
            await _navigationService.Navigate<NewsfeedListViewModel, Setting>(setting);
        }

        private async Task NavigateToDetail(string Parameter)
        {
            switch (Parameter)
            {
                case "Home": await NavigateToList(Setting.Home); break;
                case "PBE": await NavigateToList(Setting.PBE); break;
                case "Releases": await NavigateToList(Setting.Releases); break;
                case "Red Posts": await NavigateToList(Setting.RedPosts); break;
                //case "Rotations": await NavigateToList(Setting.Rotations); break; //People???
                case "E-Sports": await NavigateToList(Setting.ESports); break;
                default: break;
            }
        }
    }
}
