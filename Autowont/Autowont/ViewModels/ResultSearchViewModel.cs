using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Autowont.Models;
using Autowont.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public class ResultSearchViewModel : ListViewModel<AdvertList>
    {
        public bool IsFavotite { get; set; }

        public ResultSearchViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService)
            : base(app, dialogsService, navigationService)
        {
            Title = "Найденные объявления:";
        }

        public override void Init(object args)
        {
            Items = new ObservableCollection<AdvertList>();
            foreach (var item in args as IEnumerable<AdvertList>)
            {
                if (item.carImages.Count != 0)
                    item.MainPicture = item.carImages.First().smallImageUrl;

                item.MainTitle = item.car.brand.ToString() + " " + item.car.model.ToString() + " " +
                                 item.car.year.ToString();
                Items.Add(item);
            }

            base.Init(args);
        }

        protected override Task ItemTappedAsync(AdvertList item)
        {
            return Navigation.NavigateToAsync<AdvertisementViewModel>(item);
        }

        public ICommand CheckFavoriteCommand
        {
            get
            {
                return new Command<AdvertList>((item) =>
                {
                    if (item != null)
                    {
                        item.IsFavorite = true;
                        App.database.SaveItem(new JsonAdvMosel()
                        {
                            key = true,
                            jsonAdv = Newtonsoft.Json.JsonConvert.SerializeObject(item)
                        });
                    }
                });
            }
        }
    }
}