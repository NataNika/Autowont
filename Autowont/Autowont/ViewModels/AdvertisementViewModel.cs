using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Autowont.Models;
using Autowont.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Autowont.ViewModels
{
    public class AdvertisementViewModel: ViewModel
    {
        public AdvertList Model { get; set; }

        public string MainFullPicture { get; set; }

        public int PhotoCount { get; set; }

        public AdvertisementViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Model = new AdvertList();
        }


        public override void Init(object args)
        {
            base.Init(args);
            Model = args as AdvertList;
            if(Model.carImages.Count!=0)
            {
                MainFullPicture = Model.carImages.First().fullImageUrl;
            }
            PhotoCount = Model.carImages.Count;
            
            App.database.SaveItem(new JsonAdvMosel() {key = true, jsonAdv = Newtonsoft.Json.JsonConvert.SerializeObject(Model)});
            
            //IEnumerable<JsonAdvMosel> a = App.database.GetItems();
            //AdvertList advertList = new AdvertList();
            //var r = a.Last();
            //JObject v = JObject.Parse(r.jsonAdv);
            //advertList = JsonConvert.DeserializeObject<AdvertList>(r.jsonAdv);


        }

        public ICommand AdvDetailsCommand
        {
            get
            {
                return new Command(()=>Navigation.NavigateToModalAsync<AdvertisementDetailViewModel>(Model));
            }
        }
    }
}
