using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Net.Http;
using Windows.Data.Json;
using Windows.ApplicationModel;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using Windows.Storage;
using System.Xml.Linq;
using System.IO;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace AboutCountries.Data
{
    /// <summary>
    /// Base class for <see cref="RecipeDataItem"/> and <see cref="RecipeDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class CountryDataCommon : AboutCountries.Common.BindableBase
    {
        internal  static Uri _baseUri = new Uri("ms-appx:///");

        public CountryDataCommon(int uniqueId, String name, String currency, String imagePath)
        {
            this._uniqueId = uniqueId; // ID
            this._name = name;   // Name
            this._currency = currency; // Currency
            this._imagePath = imagePath; //Img
        }

        private int _uniqueId = -1;
        public int UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _name = string.Empty;
        public string Name //Title  
        {
            get { return this._name; }
            set { this.SetProperty(ref this._name, value); }
        }
        private char _key = '#';
        public char Key //Title  
        {
            get { return this._key; }
            set
            {
               
                this.SetProperty(ref this._key, value);
            }
        }
        private string _currency = string.Empty;
        public string Currency  //short title
        {
            get { return this._currency; }
            set { this.SetProperty(ref this._currency, value); }
        }

        private ImageSource _image = null;
        private String _imagePath = null;

        public Uri ImagePath
        {
            get
            {
                return new Uri(CountryDataCommon._baseUri, this._imagePath); 
            }
        } 

        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(CountryDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public string GetImageUri()
        {
            return _imagePath;
        }
    }

    /// <summary>
    /// Country item data model.
    /// </summary>
    public class CountryDataItem : CountryDataCommon
    {
        public CountryDataItem()
            : base(-1, String.Empty, String.Empty, String.Empty)
        {
        }
        
        public CountryDataItem( int uniqueId, String name, String currency, String imagePath, 
                                String capital, // prep time 
                                String startDate, // directions 
                                String endDate,
                                String utc,
                                String region,
                                String longitude,
                                String latitude,
                                String dialCode,
                                String language,
                                String localTime,
                                CountryDataGroup group)
                                : base(uniqueId, name, currency, imagePath)
        {
            this._capital = capital;
            this._startDate = startDate;
            this._endDate = endDate;
            this._utc = utc;
            this.Img = imagePath;
            this._region = region;
            this._longitude = longitude;
            this._latitude = latitude;
            this._dialCode = dialCode;
            this._localTime = localTime;
            this._language = language;
          
            this._group = group;
        }

        private string _capital = string.Empty;
        public string Capital
        {
            get { return this._capital; }
            set { this.SetProperty(ref this._capital, value); }
        }

        private string _startDate = string.Empty;
        public string StartDate
        {
            get { return this._startDate; }
            set { this.SetProperty(ref this._startDate, value); }
        }
        
        private string _endDate = string.Empty;
        public string EndDate
        {
            get { return this._endDate; }
            set { this.SetProperty(ref this._endDate, value); }
        }

        private string _utc = string.Empty;
        public string UTC
        {
            get { return this._utc; }
            set { this.SetProperty(ref this._utc, value); }
        }
      
        private string _region = string.Empty;
        public string Region
        {
            get { return this._region; }
            set { this.SetProperty(ref this._region, value); }
        }

        private string _longitude = string.Empty;
        public string Longitude
        {
            get { return this._longitude; }
            set { this.SetProperty(ref this._longitude, value); }
        }

        private string _latitude = string.Empty;
        public string Latitude
        {
            get { return this._latitude; }
            set { this.SetProperty(ref this._latitude, value); }
        }

        private string _dialCode = string.Empty;
        public string DialCode
        {
            get { return this._dialCode; }
            set { this.SetProperty(ref this._dialCode, value); }
        }

        private string _localTime = string.Empty;
        public string LocalTime
        {
            get { return this._localTime; }
            set { this.SetProperty(ref this._localTime, value); }
        }

        private string _language = string.Empty;
        public string Language
        {
            get { return this._language; }
            set { this.SetProperty(ref this._language, value); }
        }

        private string _img = string.Empty;
        public string Img
        {
            get { return this._img; }
            set { this.SetProperty(ref this._img, value); }
        }    
                
        private CountryDataGroup _group;
        public CountryDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }

        private ImageSource _tileImage;
        private string _tileImagePath;

        public Uri TileImagePath
        {
            get
            {
                return new Uri(CountryDataCommon._baseUri, this._tileImagePath);
            }
        }
        
        public ImageSource TileImage
        {
            get
            {
                if (this._tileImage == null && this._tileImagePath != null)
                {
                    this._tileImage = new BitmapImage(new Uri(CountryDataCommon._baseUri, this._tileImagePath));
                }
                return this._tileImage;
            }
            set
            {
                this._tileImagePath = null;
                this.SetProperty(ref this._tileImage, value);
            }
        }

        public void SetTileImage(String path)
        {
            this._tileImage = null;
            this._tileImagePath = path;
            this.OnPropertyChanged("TileImage");
        }

        public string CountryImg { get; set; }
    }

    /// <summary>
    /// Country group data model.
    /// </summary>
    public class CountryDataGroup : CountryDataCommon
    {
        public CountryDataGroup()
            : base(-1, String.Empty, String.Empty, String.Empty)
        {
        }
        
        public CountryDataGroup(int uniqueId, String name, String currency, String imagePath, String description)
            : base(uniqueId, name, currency, imagePath)
        {
        }

        private ObservableCollection<CountryDataItem> _items = new ObservableCollection<CountryDataItem>();
        public ObservableCollection<CountryDataItem> Items
        {
            get { return this._items; }
        }

        public IEnumerable<CountryDataItem> TopItems
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed
            get { return this._items.Take(12); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }
               
        private string _capital = string.Empty;
        public string Capital
        {
            get { return this._capital; }
            set { this.SetProperty(ref this._capital, value); }
        }
        //private char _key= '-';
        //public char Key
        //{
        //    get { return this._key; }
        //    set { this.SetProperty(ref this._key, value); }
        //}

        private ImageSource _groupImage;
        private string _groupImagePath;  

        public ImageSource GroupImage
        {
            get
            {
                if (this._groupImage == null && this._groupImagePath != null)
                {
                    this._groupImage = new BitmapImage(new Uri(CountryDataCommon._baseUri, this._groupImagePath));
                }
                return this._groupImage;
            }
            set
            {
                this._groupImagePath = null;
                this.SetProperty(ref this._groupImage, value);
            }
        }

        public int CountrysCount
        {
            get
            {
                return this.Items.Count; 
            } 
        } 

        public void SetGroupImage(String path)
        {
            this._groupImage = null;
            this._groupImagePath = path;
            this.OnPropertyChanged("GroupImage");
        }
    }

    /// <summary>
    /// Creates a collection of groups and items.
    /// </summary>
    public sealed class CountryDataSource
    {
        //public event EventHandler CountrysLoaded;

        private static CountryDataSource _countryDataSource = new CountryDataSource();
        
        private ObservableCollection<CountryDataGroup> _allGroups = new ObservableCollection<CountryDataGroup>();
        public ObservableCollection<CountryDataGroup> AllGroups
        {
            get { return this._allGroups; }
        }

        public static IEnumerable<CountryDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return _countryDataSource.AllGroups;
        }

        public static CountryDataGroup GetGroup(int uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _countryDataSource.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static CountryDataItem GetItem(int uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _countryDataSource.AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task LoadLocalDataAsync()
        {
            // Retrieve Country data from Countrys.txt
           // var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\worldTime.xml");
         //   var result = await FileIO.ReadTextAsync(file);

            //int i = 0;
            // XDocument doc = await XDocument.Load("Data\\worldTime.xml");
            //_countryLookup = new Dictionary<int, Country>();

            var sf = await Package.Current.InstalledLocation.GetFileAsync(@"Data\worldTime.xml");
            var file = await sf.OpenAsync(FileAccessMode.Read);
            Stream inStream = file.AsStreamForRead();

            XDocument doc = XDocument.Load(inStream);
            CreateCountrysAndCountryGroups(doc);

            // Parse the JSON Country data
            //var countrys = JsonArray.Parse(result);

            //// Convert the JSON objects into CountryDataItems and CountryDataGroups
            //CreateCountrysAndCountryGroups(countrys);
        }

        private static void CreateCountrysAndCountryGroups(XDocument doc)
        {
            int i = 0;
            char prevKey ='-';
            foreach (XElement e in doc.Descendants("Country"))
            {
                CountryDataItem cc = new CountryDataItem();
                CountryDataGroup group = null;
               
                cc.Name = e.Element("Name").Value;                
                char key = char.ToUpper(cc.Name[0]);
                cc.Key = key;

                if (key != prevKey)
                {
                    
                    prevKey = key; 
                }i++;
                cc.UniqueId = i;
                cc.Capital = e.Element("Capital").Value;
                cc.Currency = e.Element("Currency").Value;
                cc.Region = e.Element("Region").Value;
                cc.UTC = e.Element("UTC").Value;
                cc.Img = "png/" + (e.Element("Name").Value) + ".png";
                cc.CountryImg = "img/" + (e.Element("Name").Value) + ".png";
                cc.StartDate = e.Element("StartDate").Value;
                cc.EndDate = e.Element("EndDate").Value;
                cc.LocalTime = e.Element("UTC").Value;
                cc.Longitude = e.Element("Longitude").Value;
                cc.Latitude = e.Element("Latitude").Value;
                cc.Language = e.Element("Language").Value;
                cc.DialCode = e.Element("DialCode").Value;

                

                //_countryLookup[i++] = cc;

               // group = _countryDataSource.AllGroups.FirstOrDefault(c => c.UniqueId.Equals(cc.UniqueId));
              group = _countryDataSource.AllGroups.FirstOrDefault(c => c.Key.Equals(key));

                if (group == null)
                    group = CreateCountryGroup(cc);

                cc.Group = group;

                if (group != null)
                    group.Items.Add(cc);
                
            }
           
        }
        
        private static CountryDataGroup CreateCountryGroup(CountryDataItem cc)
        {
            CountryDataGroup group = new CountryDataGroup();
            group.UniqueId = cc.UniqueId;
            group.Name = cc.Name;
            group.Currency = cc.Currency;
            group.Capital = cc.Capital;
            group.Key = cc.Key;

           

            _countryDataSource.AllGroups.Add(group);
            return group;
        }
    }
}
