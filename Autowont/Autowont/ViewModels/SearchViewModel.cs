using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autowont.Services;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Autowont.Helpers;
using Autowont.Models;
using System.Collections;

namespace Autowont.ViewModels
{
    public class SearchViewModel : ViewModel
    {

       
        public bool IsPressed { get; set;}
        public int ButtonPressed { get; set; }
        public int CountOfAdv { get; set; }
        public string ButtonSearchText { get; set; }

        public string BrandItem { get; set; }
        public string CarModelItem { get; set; }
        public string BodyTypeItem { get; set; }
        public string ColorItem { get; set; } 
        public string TransmisionItem { get; set; }
        public string DriveItem { get; set; }
        public string FuelTypeItem { get; set; }
        public string StateItem { get; set; }
        
        
        #region propertiesforpickers
        public List<Colors> ColorsList { get; set; }
        public IEnumerable<string> Colors { get; set; }

        public List<string> ColorStrings { get; set; }

        public List<State> StateList { get; set; }
        public IEnumerable<string> States { get; set; }

        public List<string> StateStrings { get; set; }

        public List<Brand> BrandList { get; set; }
        public IEnumerable<string> Brands { get; set; }

        public List<string> BrandStrings { get; set; }

        public List<CarModel> CarModelList { get; set; }
        public IEnumerable<string> CarModels { get; set; }

        public List<string> CarModelStrings { get; set; }

        public List<BodyType> BodyTypeList { get; set; }
        public IEnumerable<string> BodyTypes { get; set; }

        public List<string> BodyTypeStrings { get; set; }

        public List<Transmission> TransmissionList { get; set; }
        public IEnumerable<string> Transmissions { get; set; }

        public List<string> TransmissionStrings { get; set; }

        public List<DriveType> DriveTypeList { get; set; }
        public IEnumerable<string> DriveTypes { get; set; }

        public List<string> DriveTypeStrings { get; set; }

        public List<FuelType> FuelTypeList { get; set; }
        public IEnumerable<string> FuelTypes { get; set; }

        public List<string> FuelTypeStrings { get; set; }




        #endregion

        public SearchModel searchModel { get; set; }

        public SearchADVModel RezOfSearch { get; set; }

        public SearchViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Title = "Поиск";
            Icon = "searcheIcon";
            IsPressed = false;
            CountOfAdv = 0;
            ButtonSearchText = "Поиск объявлений";

            #region getvalues

            if (ColorsList!=null)
            {
                ColorsList = new List<Colors>();
                ColorsList = WebApiHelper.Get<Colors>("/reference/color");
            }

            if (StateList != null)
            {
                StateList = new List<State>();
                StateList = WebApiHelper.Get<State>("/reference/state");
            }

            if (BrandList != null)
            {
                BrandList = new List<Brand>();
                BrandList = WebApiHelper.Get<Brand>("/reference/brand");
            }

            if (CarModelList != null)
            {
                CarModelList = new List<CarModel>();
                CarModelList = WebApiHelper.Get<CarModel>("/reference/model");
            }

            if (BodyTypeList != null)
            {
                BodyTypeList = new List<BodyType>();
                BodyTypeList = WebApiHelper.Get<BodyType>("/reference/bodyType");
            }

            if (TransmissionList != null)
            {
                TransmissionList = new List<Transmission>();
                TransmissionList = WebApiHelper.Get<Transmission>("/reference/transmission");
            }

            if (DriveTypeList != null)
            {
                DriveTypeList = new List<DriveType>();
                DriveTypeList = WebApiHelper.Get<DriveType>("/reference/driveType");
            }

            if (FuelTypeList != null)
            {
                FuelTypeList = new List<FuelType>();
                FuelTypeList = WebApiHelper.Get<FuelType>("/reference/fuelType");
            }

            #endregion

            //BrandItem = -1;
            //CarModelItem = -1;
            //BodyTypeItem = -1;
            //ColorItem = 1;
            //TransmisionItem = -1;
            //DriveItem = -1;
            //FuelTypeItem = -1;
            //StateItem = -1;
            searchModel = new SearchModel();
            RezOfSearch = new SearchADVModel();
        }

        public ICommand ButtonPressedCommand
        {
            get
            {
                return new Command(() =>
                {
                    IsPressed = true;
                });
            }
        }
        public ICommand SearchADVCount
        { 
             get
            {
                return new Command(() =>
                {
                    string searchstr = "/search?";

                    if (!StateItem.IsNullOrEmpty())
                    {
                        var id = StateList.FindIndex(0, (x) => x.name == StateItem) + 1;
                        searchstr += "&state=" + id;
                    }
                    if (!BrandItem.IsNullOrEmpty())
                    {

                        var id = BrandList.FindIndex(0,(x)=>x.name == BrandItem) +1;
                        searchstr += "&brand=" + id;
                    }
                    if (!CarModelItem.IsNullOrEmpty())
                    {
                        var id = CarModelList.FindIndex(0, (x) => x.name == CarModelItem) + 1;
                        searchstr += "&model=" + id;
                    }
                    if (!ColorItem.IsNullOrEmpty())
                    {
                        var id = ColorsList.FindIndex(0, (x) => x.name == ColorItem) + 1;
                        searchstr += "&color=" + id;
                    }
                    if (!TransmisionItem.IsNullOrEmpty())
                    {
                        var id = TransmissionList.FindIndex(0, (x) => x.name == TransmisionItem) + 1;
                        searchstr += "&transmission=" + id;
                    }
                    if (!BodyTypeItem.IsNullOrEmpty())
                    {
                        var id = BodyTypeList.FindIndex(0, (x) => x.name == BodyTypeItem) + 1;
                        searchstr += "&bodyType=" + id;
                    }
                    
                    if (!DriveItem.IsNullOrEmpty())
                    {
                        var id = DriveTypeList.FindIndex(0, (x) => x.name == DriveItem) + 1;
                        searchstr += "&driveType=" + id;
                    }
                    if (!FuelTypeItem.IsNullOrEmpty())
                    {
                        var id = FuelTypeList.FindIndex(0, (x) => x.name == FuelTypeItem) + 1;
                        searchstr += "&fuelType=" + id;
                    }



                    RezOfSearch = WebApiHelper.GetObj<SearchADVModel>(searchstr);
                    if (RezOfSearch!=null)
                    {
                        CountOfAdv = RezOfSearch.advertList.Count;
                    }
                    
                });
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new Command(async () =>
                {
                    SearchADVCount.Execute(null);

                    HistotyModel histoty = new HistotyModel()
                    {
                        location = StateItem,
                        name = CarModelItem,
                        countOfRez = CountOfAdv,
                        IsCheck = true,
                        price = String.Empty
                    };
                    App.database.SaveItem(new JsonAdvMosel()
                    {
                        key = false,
                        jsonAdv = Newtonsoft.Json.JsonConvert.SerializeObject(histoty)
                    });
                    if (RezOfSearch == null)
                    {
                        Dialogs.Alert(
                            "Сервер временно не работает. Повторите попытку позже.",
                            "Оповещение");
                    }
                    else await Navigation.NavigateToAsync<ResultSearchViewModel>(RezOfSearch.advertList);
                });
            }
        }

        public override void Init(object args)
        {
            IsPressed = false;

            #region setvalue_for_pickers
            ColorStrings = new List<string>();
            foreach (var item in ColorsList)
            {
                ColorStrings.Add(item.name);
            }
            Colors = ColorStrings;

            StateStrings = new List<string>();
            foreach (var item in StateList)
            {
                StateStrings.Add(item.name);
            }
            States = StateStrings;
            base.Init(args);

            BrandStrings = new List<string>();
            foreach (var item in BrandList)
            {
                BrandStrings.Add(item.name);
            }
            Brands = BrandStrings;
            base.Init(args);

            CarModelStrings = new List<string>();
            foreach (var item in CarModelList)
            {
                CarModelStrings.Add(item.name);
            }
            CarModels = CarModelStrings;
            
            BodyTypeStrings = new List<string>();
            foreach (var item in BodyTypeList)
            {
                BodyTypeStrings.Add(item.name);
            }
            BodyTypes = BodyTypeStrings;

            TransmissionStrings = new List<string>();
            foreach (var item in TransmissionList)
            {
                TransmissionStrings.Add(item.name);
            }
            Transmissions = TransmissionStrings;

            DriveTypeStrings = new List<string>();
            foreach (var item in DriveTypeList)
            {
                DriveTypeStrings.Add(item.name);
            }
            DriveTypes = DriveTypeStrings;

            FuelTypeStrings = new List<string>();
            foreach (var item in FuelTypeList)
            {
                FuelTypeStrings.Add(item.name);
            }
            FuelTypes = FuelTypeStrings;
            #endregion

            base.Init(args);

        }
    }
}
