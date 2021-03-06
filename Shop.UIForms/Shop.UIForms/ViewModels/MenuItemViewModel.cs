﻿namespace Shop.UIForms.ViewModels
{
	using GalaSoft.MvvmLight.Command;
	using System.Windows.Input;
	using Views;
	using Xamarin.Forms;

	public class MenuItemViewModel : Common.Models.Menu
	{
		public ICommand SelectMenuCommand => new RelayCommand(this.SelectMenu);

		private async void SelectMenu()
		{
			var mainViewModel = MainViewModel.GetInstance();
			App.Master.IsPresented = false;

			switch (this.PageName)
			{
				case "AboutPage":
					await App.Navigator.PushAsync(new AboutPage());
					break;
				case "SetupPage":
					await App.Navigator.PushAsync(new SetupPage());
					break;
				default:
					MainViewModel.GetInstance().Login = new LoginViewModel();
					Application.Current.MainPage = new NavigationPage(new LoginPage());
					break;
			}
		}
	}

}
