using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using SQLite;

namespace Autowont.Models
{
    public class Car
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int? year { get; set; }
        public string transmission { get; set; }
        public string drive { get; set; }
        public double? engineVolume { get; set; }
        public string fuel { get; set; }
        public int? kilometrage { get; set; }
        public int? numberOfDoors { get; set; }
        public object numberOfSeats { get; set; }
        public string color { get; set; }
        public string bodyType { get; set; }
        public object vin { get; set; }
    }

    public class CarDataModel
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public Car car { get; set; }
        public List<object> comfort { get; set; }
        public List<object> multimedia { get; set; }
        public List<object> other { get; set; }
        public List<object> security { get; set; }
        public List<object> state { get; set; }
    }

    public class Saler
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public List<object> phones { get; set; }
        public object email { get; set; }
        public string fio { get; set; }
    }

    public class Price
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double price { get; set; }
        public string currency { get; set; }
    }

    public class Car2
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int? year { get; set; }
        public string transmission { get; set; }
        public string drive { get; set; }
        public double engineVolume { get; set; }
        public string fuel { get; set; }
        public int? kilometrage { get; set; }
        public int? numberOfDoors { get; set; }
        public object numberOfSeats { get; set; }
        public string color { get; set; }
        public string bodyType { get; set; }
        public object vin { get; set; }
    }

    public class AdvertList
    {
        [JsonIgnore, PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [JsonIgnore]
        public bool IsFavorite { get; set; }
        public string source { get; set; }
        
        public CarDataModel carDataModel { get; set; }
        
        public Saler saler { get; set; }
        [JsonIgnore]
        public int priceID { get; set; }
        
        public Price price { get; set; }
        public string city { get; set; }
        public string dateAdded { get; set; }
        public string additionalData { get; set; }
        
        public List<CarImage> carImages { get; set; }

        public Car2 car { get; set; }

        [JsonIgnore]
        public string MainPicture { get; set; }
        
        [JsonIgnore]
        public string MainTitle { get; set; }
    }

    public class SearchADVModel
    {
        public int id { get; set; }
        public List<AdvertList> advertList { get; set; }
        public int totalAmount { get; set; }
    }

    public class JsonAdvMosel
    {
        public int ID { get; set; }
        public bool key { get; set; }
        public string jsonAdv { get; set; }
    }

    public class HistotyModel
    {
        public string name { get; set; }
        public bool IsCheck { get; set; }
        public string price { get; set; }
        public string location { get; set; }
        public int countOfRez { get; set; }
        public string searchstr { get; set; }
    }
    //public class Car
    //{
    //    public string brand { get; set; }
    //    public string model { get; set; }
    //    public int year { get; set; }
    //    public string transmission { get; set; }
    //    public string drive { get; set; }
    //    public double engineVolume { get; set; }
    //    public string fuel { get; set; }
    //    public int kilometrage { get; set; }
    //    public object numberOfDoors { get; set; }
    //    public object numberOfSeats { get; set; }
    //    public string color { get; set; }
    //    public string bodyType { get; set; }
    //    public object vin { get; set; }
    //}

    //public class CarDataModel
    //{
    //    public Car car { get; set; }
    //    public List<object> comfort { get; set; }
    //    public List<object> multimedia { get; set; }
    //    public List<object> other { get; set; }
    //    public List<object> security { get; set; }
    //    public List<object> state { get; set; }
    //}

    //public class Saler
    //{
    //    public List<object> phones { get; set; }
    //    public object email { get; set; }
    //    public object fio { get; set; }
    //}

    //public class Price
    //{
    //    public double price { get; set; }
    //    public string currency { get; set; }
    //}

    public class CarImage
    {
        public string smallImageUrl { get; set; }
        public string fullImageUrl { get; set; }
    }

    //public class Car2
    //{
    //    public string brand { get; set; }
    //    public string model { get; set; }
    //    public int year { get; set; }
    //    public string transmission { get; set; }
    //    public string drive { get; set; }
    //    public double engineVolume { get; set; }
    //    public string fuel { get; set; }
    //    public int kilometrage { get; set; }
    //    public object numberOfDoors { get; set; }
    //    public object numberOfSeats { get; set; }
    //    public string color { get; set; }
    //    public string bodyType { get; set; }
    //    public object vin { get; set; }
    //}

    //public class AdvertList
    //{
    //    public string source { get; set; }
    //    public CarDataModel carDataModel { get; set; }
    //    public Saler saler { get; set; }
    //    public Price price { get; set; }
    //    public string city { get; set; }
    //    public string dateAdded { get; set; }
    //    public string additionalData { get; set; }
    //    public List<CarImage> carImages { get; set; }
    //    public Car2 car { get; set; }
    //}

    //public class SearchADVModel
    //{
    //    public int id { get; set; }
    //    public List<AdvertList> advertList { get; set; }
    //    public int totalAmount { get; set; }
    //}



}
