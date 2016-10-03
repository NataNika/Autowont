using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Autowont.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public class FavoriteViewModel: ListViewModel<AdvertList>
    {
        public FavoriteViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Title = "Закладки";
            Icon = "favoriteIcon";
            
        }

        public override void Init(object args)
        {
            //Items = new ObservableCollection<AdvertList>();
            //IEnumerable<JsonAdvMosel> favJsonAdvMosels = App.database.GetItems();

            //foreach (var item in favJsonAdvMosels)
            //{
            //    if (item.key)
            //    {
            //        Items.Add(JsonConvert.DeserializeObject<AdvertList>(item.jsonAdv));
            //    }
            //}
            //foreach (var item in Items)
            //{
            //    if (item.carImages.Count != 0)
            //        item.MainPicture = item.carImages.First().smallImageUrl;

            //    item.MainTitle = item.car.brand.ToString() + " " + item.car.model.ToString() + " " + item.car.year.ToString();
            //    Items.Add(item);
            //}
            base.Init(args);
        }

        protected override Task ItemTappedAsync(AdvertList item)
        {
            //return null;
            return Navigation.NavigateToAsync<AdvertisementViewModel>(item);
        }
        public ICommand ButtonCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Navigation.NavigateToAsync<MessagesViewModel>();

                });
            }
        }
        public override void OnAppearing()
        {
            Items = new ObservableCollection<AdvertList>();
            IEnumerable<JsonAdvMosel> favJsonAdvMosels = App.database.GetItems();

            foreach (var item in favJsonAdvMosels)
            {
                if (item.key)
                {
                    AdvertList advertList = JsonConvert.DeserializeObject<AdvertList>(item.jsonAdv);
                    if (advertList.carImages.Count != 0)
                        advertList.MainPicture = advertList.carImages.First().smallImageUrl;

                    advertList.MainTitle = advertList.car.brand.ToString() + " " + advertList.car.model.ToString() + " " +
                                           advertList.car.year.ToString();
                    Items.Add(advertList);
                }
            }
            
            base.OnAppearing();
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        public ICommand CheckFavoriteCommand
        {
            get
            {
                return new Command<AdvertList>(async (item) =>
                {
                    if (item != null)
                    {
                        var answer = await Dialogs.QuestionAsync("Удалить выбраную закладку?", "Удаление...");
                        if (answer)
                        {
                            IEnumerable<JsonAdvMosel> tmpAdvMosels = App.database.GetItems();
                            var jsStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                            List<JsonAdvMosel> advMosels = new List<JsonAdvMosel>();
                            foreach (var t in tmpAdvMosels)
                            {
                                advMosels.Add(t);
                            }
                            JsonAdvMosel tempAdvMosel = advMosels.Find((x) => x.jsonAdv == jsStr);
                            App.database.DeleteItem(tempAdvMosel.ID);
                        }

                    }
                });

            }
        }
    }
}
