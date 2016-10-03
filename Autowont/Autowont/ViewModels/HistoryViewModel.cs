using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Services;
using Autowont.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Autowont.Helpers;
using Autowont.Pages.Base;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public class HistoryViewModel : ListViewModel<HistotyModel>
    {
        public ObservableCollection<HistotyModel> Model { get; set; }
        public SearchADVModel RezOfSearch { get; set; }

        public HistoryViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            Title = "История";
            Icon = "historyIcon";
        }

        protected override async Task ItemTappedAsync(HistotyModel item)
        {
            RezOfSearch = WebApiHelper.GetObj<SearchADVModel>(item.searchstr);
            await Navigation.NavigateToAsync<ResultSearchViewModel>(RezOfSearch.advertList);

        }

        public override void OnAppearing()
        {
            Items = new ObservableCollection<HistotyModel>();
            IEnumerable<JsonAdvMosel> favJsonhistoryMosels = App.database.GetItems();

            foreach (var item in favJsonhistoryMosels)
            {
                if (!item.key)
                {
                    HistotyModel advertList = JsonConvert.DeserializeObject<HistotyModel>(item.jsonAdv);
                    Items.Add(advertList);
                }
            }
        }

        public ICommand CheckHistoryCommand
        {
            get
            {
                return new Command( () =>
                {
                    int a = 45;
                    a++;
                    //if (item != null)
                    //{
                    //    var answer = await Dialogs.QuestionAsync("Удалить этот запрос из Истрории поиска?", "Удаление...");
                    //    if (answer)
                    //    {
                    //        IEnumerable<JsonAdvMosel> tmpAdvMosels = App.database.GetItems();
                    //        var jsStr = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    //        List<JsonAdvMosel> advMosels = new List<JsonAdvMosel>();
                    //        foreach (var t in tmpAdvMosels)
                    //        {
                    //            advMosels.Add(t);
                    //        }
                    //        JsonAdvMosel tempAdvMosel = advMosels.Find((x) => x.jsonAdv == jsStr);
                    //        App.database.DeleteItem(tempAdvMosel.ID);
                    //    }

                    //}
                });

            }
        }
    }
}
