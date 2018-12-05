using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PassItemData
{
    public class ContactsViewModel
    {
        #region Command Fields

        Command<object> selectionChangedCommand;
       

        #endregion

        #region Command Properties

        public Command<object> SelectionChangedCommand
        {
            get { return selectionChangedCommand; }
            protected set { selectionChangedCommand = value; }
        }

        #endregion

        #region Properties
        public ObservableCollection<Contacts> contactsinfo { get; set; }

        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            selectionChangedCommand = new Command<object>(OnSelectionChanged);
            contactsinfo = new ObservableCollection<Contacts>();
            Random r = new Random();
            foreach (var cusName in CustomerNames)
            {
                var contact = new Contacts(cusName, r.Next(720, 799).ToString() + " - " + r.Next(3010, 3999).ToString());
                contact.ContactImage = ImageSource.FromResource("PassItemData.Images.Image" + r.Next(0, 28) + ".png");
                contactsinfo.Add(contact);
            }
        }



        #endregion

        #region Fields

        string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson"    ,
            "Mason  "    ,
            "Liam   "    ,
            "Jacob  "    ,
            "Jayden "    ,
            "Ethan  "    ,
            "Noah   "    ,
            "Lucas  "    ,
            "Logan  "    ,
            "Caleb  "    ,
            "Caden  "    ,
            "Jack   "    ,
            "Ryan   "    ,
            "Connor "    ,
            "Michael"    ,
            "Elijah "    ,
            "Brayden"    ,
            "Benjamin"   ,
            "Nicholas"   ,
            "Alexander"  ,
            "William"    ,
            "Matthew"    ,
            "James  "    ,
            "Landon "    ,
            "Nathan "    ,
            "Dylan  "    ,
            "Evan   "    ,
            "Luke   "    ,
            "Andrew "    ,
            "Gabriel"    ,
            "Gavin  "    ,
            "Joshua "    ,
            "Owen   "    ,
            "Daniel "    ,
            "Carter "    ,
            "Tyler  "    ,
            "Cameron"    ,
            "Christian"  ,
            "Wyatt  "    ,
            "Henry  "    ,
            "Eli    "    ,
            "Joseph "    ,
            "Max    "    ,
            "Isaac  "    ,
            "Samuel "    ,
            "Anthony"    ,
            "Grayson"    ,
            "Zachary"    ,
            "David  "    ,
            "Christopher",
            "John   "    ,
            "Isaiah "    ,
            "Levi   "    ,
            "Jonathan"   ,
            "Oliver "    ,
            "Chase  "    ,
            "Cooper "    ,
            "Tristan"    ,
            "Colton "    ,
            "Austin "    ,
            "Colin  "    ,
            "Charlie"    ,
            "Dominic"    ,
            "Parker "    ,
            "Hunter "    ,
            "Thomas "    ,
            "Alex   "    ,
            "Ian    "    ,
            "Jordan "    ,
            "Cole   "    ,
            "Julian "    ,
            "Aaron  "    ,
            "Carson "    ,
            "Miles  "    ,
            "Blake  "    ,
            "Brody  "    ,
            "Adam   "    ,
            "Sebastian"  ,
            "Adrian "    ,
            "Nolan  "    ,
            "Sean   "    ,
            "Riley  "    ,
            "Bentley"    ,
            "Xavier "    ,
            "Hayden "    ,
            "Jeremiah"   ,
            "Jason  "    ,
            "Jake   "    ,
            "Asher  "    ,
            "Micah  "    ,
            "Jace   "    ,
            "Brandon"    ,
            "Josiah "    ,
            "Hudson "    ,
            "Nathaniel"  ,
            "Bryson "    ,
            "Ryder  "    ,
            "Justin "    ,
            "Bryce  "    ,
        };

        #endregion

        #region Command Events

        public void OnSelectionChanged(object obj)
        {
            var eventArgs = obj as ItemSelectionChangedEventArgs;

            for (int i = 0; i < eventArgs.RemovedItems.Count; i++)
            {
                var item = eventArgs.RemovedItems[i] as Contacts;
                if (item.IsSelected)
                {
                    item.IsSelected = false;
                    App.Current.MainPage.DisplayAlert("Message", "Item removed from selected item", "ok");
                }
            }
            for (int i = 0; i < eventArgs.AddedItems.Count; i++)
            {
                var item = eventArgs.AddedItems[i] as Contacts;
                if (!item.IsSelected)
                {
                    item.IsSelected = true;
                    App.Current.MainPage.DisplayAlert("Message", "Item added into selected item", "ok");
                }
            }
        }
        
        #endregion
    }
}
