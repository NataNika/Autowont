using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Autowont.Helpers
{
    public static class WebApiHelper
    {
        public static List<TObject> Get<TObject>(string webApiAction)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://31.131.20.58:8080/autoWantFacade" + webApiAction);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                var responseData = client.GetAsync("").Result;
                try
                {
                    List<TObject> objects = new List<TObject>();
                    var jsonString = responseData.Content.ReadAsStringAsync().Result;

                    objects = JsonConvert.DeserializeObject<List<TObject>>(jsonString);
                    return objects;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            }
            //return new List<TObject>();
            return null;
        }
        public static TObject GetObj<TObject>(string webApiAction) where TObject : new()
        {
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://31.131.20.58:8080/autoWantFacade/search?&state=3&brand=1&model=6&color=2&transmission=2");
                client.BaseAddress = new Uri("http://31.131.20.58:8080/autoWantFacade" + webApiAction);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseData = client.GetAsync("").Result;
                try
                {
                    TObject objects = new TObject();

                    var jsonString = responseData.Content.ReadAsStringAsync().Result;

                    objects = JsonConvert.DeserializeObject<TObject>(jsonString);
                    return objects;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            //return new TObject();
            return default(TObject);
        }
    }
}
