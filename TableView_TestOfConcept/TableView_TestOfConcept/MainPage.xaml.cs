using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TableView_TestOfConcept
{
    public partial class MainPage : ContentPage
    {
        TableView tv;
        public MainPage()
        {
            InitializeComponent();

            //Display name
            TableSection displayName = new TableSection();
            TextCell firstName = new TextCell();
            firstName.Text = "First name";
            TextCell surname = new TextCell();
            surname.Text = "Surname";
            displayName.Add(firstName);
            displayName.Add(surname);

            //Profile picture
            TableSection picture = new TableSection();
            ViewCell profilePicture = new ViewCell();
            Image img = new Image();
            img.Source = ImageSource.FromUri(new Uri("http://www.finmap-fp7.eu/no_pic.png"));
            img.Aspect = Aspect.AspectFill;
            profilePicture.View = img;
            profilePicture.Height = img.Height;
            picture.Add(profilePicture);


            //Edit name
            TableSection editName = new TableSection();
            EntryCell editFirstName = new EntryCell();
            editFirstName.Text = "First name";
            editFirstName.Label = "First name";
            EntryCell editSurname = new EntryCell();
            editSurname.Text = "Surname";
            editSurname.Label = "Surname";

            //Profile Text
            TableSection text = new TableSection();

            //bool-controlled Settings
            TableSection boolSettings = new TableSection("Settings");
            SwitchCell receiveNotifications = new SwitchCell();
            receiveNotifications.Text = "Receive notifications";
            SwitchCell receivePMs = new SwitchCell();
            receivePMs.Text = "Receive private messages";

            Slider slider = new Slider(0, 100, 100);
            slider.PropertyChanged += PropertyChanged_Slider;
            Label sliderLbl = new Label();
            sliderLbl.Text = "Brightness";
            StackLayout sliderLayout = new StackLayout();
            sliderLayout.Children.Add(sliderLbl);
            sliderLayout.Children.Add(slider);
            ViewCell sliderCell = new ViewCell();
            sliderCell.View = sliderLayout;

            boolSettings.Add(sliderCell);
            boolSettings.Add(receiveNotifications);
            boolSettings.Add(receivePMs);


            //TableSection ts1 = new TableSection("Deh best TableSction");
            //bool dehFalse = true;
            //SwitchCell sc = new SwitchCell();
            //sc.Text = "A SwitchCell";
            //ts1.Add(sc);
            //EntryCell ec = new EntryCell();
            //ec.Text = "A EntryCell";
            //ec.Label = "EntryCell Label";
            //ec.PropertyChanged += PropertyChanged_EntryCell;
            //TableSection ts2 = new TableSection("Another best TableSction");
            //ts2.Add(ec);

            TableRoot userProfile = new TableRoot("User profile") { displayName, picture, editName, text, boolSettings }; //Wrap TableSection in TableRoot.

            tv = new TableView //Use TableRoot in initialization of TableView.
            {
                Root = { userProfile },
                Intent = TableIntent.Form
            };


            Content = tv; //Put the Tableview as content on the page.            
        }
        void PropertyChanged_EntryCell(Object sender, PropertyChangedEventArgs e)
        {
            EntryCell ec = (EntryCell)sender;
            ec.Label = ec.Text;
        }

        void PropertyChanged_Slider(Object sender, PropertyChangedEventArgs e)
        {
            if (tv == null)
                return;
            Slider slider = (Slider)sender;
            Color color = Color.FromRgb(slider.Value / 100, slider.Value / 100, slider.Value / 100);
            tv.BackgroundColor = color;
            //Point point = new Point(0, 0);
            //Size size = new Size(500, 2000);
            //Rectangle bounds = new Rectangle(point, size);
            //tv.Layout(bounds);
        }
    }
}
