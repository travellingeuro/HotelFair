using HotelFair.Models;
using HotelFair.AppResources;
using HotelFair.Service.Destination;
using HotelFair.Service.Dialog;
using HotelFair.Service.Request;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelFair.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        #region Fields

        

        public IDestinationService destinationService { get; private set; }
        public IDialogService dialogService { get; private set; }
        public INavigationService navigationService { get; private set; }

        public Command DestinationSelectedCommand { get; set; }


        string searchText;
        public static readonly int MinSearchLength = 1;

        private Models.Destinations results;           


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }



        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HomeViewModel"/> class.
        /// </summary>
        public HomeViewModel(IDestinationService destinationService, IDialogService dialogService, INavigationService navigationService)
        {
            this.destinationService = destinationService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
            this.results = new Models.Destinations();
            this.DestinationSelectedCommand = new Command(this.NavigateToCalendar);

        }

       
        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets a collection of value to be displayed in movies list page.
        /// </summary>
        /// 
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                _ = SearchLocationAsync();
                RaisePropertyChanged();
            }
        }

        public Models.Destinations Results
        {
            get => results;
            set => SetProperty(ref results, value);
        }




        #endregion

        #region Methods

        private void NavigateToCalendar(object obj)
        {
            var navigationparams = new NavigationParameters();
            var destination = obj as Result;
            navigationparams.Add("Destination", destination);
            navigationService.NavigateAsync("OccupancyPage", navigationparams);
        }

        async Task SearchLocationAsync()
        {
            if (!string.IsNullOrEmpty(SearchText) && SearchText.Length > MinSearchLength)
            {
                try
                {
                    IsBusy = true;
                    Results = await destinationService.GetDestinationsAsync(AppSettings.HereLocation, SearchText);

                }
               catch (HttpRequestException httpEx)
                {
                    Debug.WriteLine($"[Booking Where Step] Error retrieving data: {httpEx}");

                    if (!string.IsNullOrEmpty(httpEx.Message))
                    {
                        await dialogService.ShowAlertAsync(
                            string.Format(AppResources.AppResources.HttpRequestExceptionMessage, httpEx.Message),
                            AppResources.AppResources.HttpRequestExceptionTitle,
                            AppResources.AppResources.DialogOk);
                    }

                }
                catch (ConnectivityException cex)
                {
                    Debug.WriteLine($"[Booking Where Step] Connectivity Error: {cex}");
                    await dialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"[Booking Where Step] Error: {ex}");

                    await dialogService.ShowAlertAsync(
                        AppResources.AppResources.ExceptionMessage,
                        AppResources.AppResources.ExceptionTitle,
                        AppResources.AppResources.DialogOk);

                }
                finally
                {
                    IsBusy = false;                    
                }
            }

            else
            {
                Results = null;
            }

        }

        /// <summary>
        /// Invoked when an item is selected from the movies list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something
        }

        #endregion

    }
}
