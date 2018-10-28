﻿using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using MvvmCross.Platforms.Uap.Views;
using Surrender_20.Core.ViewModels;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Animation;
using System.Net.NetworkInformation;
using System;
using Surrender_20.UWP.Views.MessageBoxes;
using Windows.UI.Xaml.Media.Imaging;

namespace Surrender_20.UWP.View
{
    public sealed partial class MainPageView : MvxWindowsPage
    {
        public MainPageViewModel VM => ViewModel as MainPageViewModel;

        private BitmapImage LogoLight, LogoDark;

        public MainPageView()
        {
            InitializeComponent();
            CheckInternetConnection();
            LoadImages();
            ChangeThemeLogo();

            var CoreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            CoreTitleBar.ExtendViewIntoTitleBar = true;

            Window.Current.SetTitleBar(DragArea);

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            e.Cancel = true;

            switch (e.NavigationMode)
            {
                case NavigationMode.New:
                    ContentFrame.Navigate(e.SourcePageType, e.Parameter, new EntranceNavigationTransitionInfo());
                    break;
                case NavigationMode.Forward:
                    ContentFrame.GoForward(); //Navigate?
                    break;
                case NavigationMode.Back:
                    ContentFrame.GoBack(e.NavigationTransitionInfo);
                    break;
                case NavigationMode.Refresh:
                default: break;
            }

            base.OnNavigatingFrom(e);
        }

        private async void CheckInternetConnection() //ViewModel?
        {
            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isInternetConnected == false)
            {
                ConnectionDialog Dialog = new ConnectionDialog();
                
                await Dialog.ShowAsync();
            }
        }

        private void LoadImages()
        {
            LogoLight = new BitmapImage(new Uri("ms-appx:///Assets/Square44x44Logo.scale-100.png"));
            LogoDark = new BitmapImage(new Uri("ms-appx:///Assets/Square44x44Logo.scale-100Dark.png"));
            
        }

        private void MvxWindowsPage_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            ChangeThemeLogo();
        }

        private void ChangeThemeLogo()
        {
            if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
            {
                LogoImage.Source = LogoLight;
            }

            else
            {
                LogoImage.Source = LogoDark;
            }
        }

        /*private void NavView_ItemSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            if (item.Content.Equals("Home"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListView), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Statystyki postaci";
            }
            else if (item.Content.Equals("PBE"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Siła czarów i run";
            }
            else if (item.Content.Equals("Releases"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Umiejętności";
            }
            else if (item.Content.Equals("Red Posts"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Lista przedmiotów";
            }
            else if (item.Content.Equals("Rotations"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Poradniki Youtube";
            }
            else if (item.Content.Equals("E-Sports"))
            {
                ContentFrame.Navigate(typeof(NewsfeedListViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Poradniki Youtube";
            }
            else if (item.Content.Equals("Settings"))
            {
                ContentFrame.Navigate(typeof(SettingsViewModel), null, new DrillInNavigationTransitionInfo());
                //TitlePageTextBlock.Text = "Informacje";
            }
        }*/
    }
}