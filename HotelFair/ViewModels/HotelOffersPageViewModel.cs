using HotelFair.Models;
using HotelFair.Service.AmadeusToken;
using HotelFair.Service.Dialog;
using HotelFair.Service.HotelOffers;
using HotelFair.Service.Request;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelFair.ViewModels
{
    public class HotelOffersPageViewModel : BindableBase, INavigationAware
    {
        //Services
        public IAmadeusTokenService amadeusTokenService { get; private set; }
        public IHotelOffersService hotelOffersService { get; private set; }
        public IDialogService dialogService { get; private set; }
        public INavigationService navigationService { get; private set; }


        //Properties
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private Models.Amadeus.AmadeusToken token;
        public Models.Amadeus.AmadeusToken Token
        {
            get { return token; }
            set { SetProperty(ref token, value); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private BookingDates bookingDates;
        public BookingDates BookingDates
        {
            get { return bookingDates; }
            set { SetProperty(ref bookingDates, value); }
        }

        private Location location;
        public Location Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        private RoomOccupancy roomOccupancy;
        public RoomOccupancy RoomOccupancy
        {
            get { return roomOccupancy; }
            set { SetProperty(ref roomOccupancy, value); }
        }

        private Result destination;
        public Result Destination
        {
            get { return destination; }
            set { SetProperty(ref destination, value); }
        }

        private HotelOffers hotelOffers;
        public HotelOffers HotelOffers
        {
            get { return hotelOffers; }
            set { SetProperty(ref hotelOffers, value); }
        }

        //Constructor
        public HotelOffersPageViewModel(IAmadeusTokenService amadeusTokenService, INavigationService navigationService,
                                        IDialogService dialogService, IHotelOffersService hotelOffersService)
        {
            this.amadeusTokenService = amadeusTokenService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.hotelOffersService = hotelOffersService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //Retrieve navigation parameters
            if (parameters != null)
            {
                BookingDates = parameters["BookingDates"] as BookingDates;
                Location = parameters["Location"] as Location;
                RoomOccupancy = parameters["RoomOccupancy"] as RoomOccupancy;
                Destination = parameters["Destinations"] as Result;
                Title = Destination.ToString();
            }


            //cultures for serach in lenguaje and cuurrency
            var culture = System.Globalization.CultureInfo.CurrentUICulture.LCID;
            System.Globalization.RegionInfo regionInfo = new System.Globalization.RegionInfo(culture);

            
            _ = GetHotelOffers();
        }

        async Task GetToken()
        {
            try
            {
                IsBusy = true;
                Token = await amadeusTokenService.GetAmadeusToken();
            }
            catch (HttpRequestException httpEx)
            {

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

                await dialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");

            }
            catch (Exception ex)
            {

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

        async Task GetHotelOffers()
        {
            await GetToken();
            if (Token != null)

            try
            {
                IsBusy = true;
                HotelOffers = await hotelOffersService.GetHotelsOffersAsync(BookingDates, Location, RoomOccupancy, Token);
            }
            catch (HttpRequestException httpEx)
            {

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

                await dialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");

            }
            catch (Exception ex)
            {

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
    }
}
