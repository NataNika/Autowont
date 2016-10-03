using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autowont.Models;
using Autowont.Services;

namespace Autowont.ViewModels
{
    public class AdvertisementDetailViewModel:  ViewModel
    {
        public AdvertList Model { get; set; }
        public AdvertisementDetailViewModel(IApp app, IDialogsService dialogsService, INavigationService navigationService) : base(app, dialogsService, navigationService)
        {
            Model = new AdvertList();
        }

        public override void Init(object args)
        {
            Model = args as AdvertList;
            base.Init(args);
        }
    }
}
