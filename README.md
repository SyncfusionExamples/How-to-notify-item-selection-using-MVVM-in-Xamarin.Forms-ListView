# How to notify item selection using MVVM in Xamarin.Forms ListView?

This example demonstrates how to notify item selection using MVVM in Xamarin.Forms listview.

## Sample

```xaml
<Grid>
    <listView:SfListView x:Name="listView" ItemSize="70" ItemSpacing="0,0,5,0"
                    ItemsSource="{Binding contactsinfo}" IsStickyHeader="True" TapCommand="{Binding }"
                    SelectionMode="Multiple" IsStickyGroupHeader="True" GroupHeaderSize="50">
                <listView:SfListView.Behaviors>
                    <local:EventToCommandBehavior EventName="SelectionChanged" 
                                        Command="{Binding SelectionChangedCommand}"
                                        Converter="{StaticResource EventArgs}" />
                </listView:SfListView.Behaviors>
        <listView:SfListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <ViewCell.View>
                        <Grid x:Name="grid" RowSpacing="1">
                            <code>
                            . . .
                            . . .
                            <code>
                        </Grid>
                    </ViewCell.View>
                </ViewCell>
            </DataTemplate>
        </listView:SfListView.ItemTemplate>
    </listView:SfListView>
</Grid>

ViewModel.cs:
Command<object> selectionChangedCommand;

public Command<object> SelectionChangedCommand
{
    get { return selectionChangedCommand; }
    protected set { selectionChangedCommand = value; }
}

public ObservableCollection<Contacts> contactsinfo { get; set; }

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
```

See [How to notify item selection using MVVM in Xamarin.Forms ListView](https://www.syncfusion.com/kb/9961/how-to-notify-item-selection-using-mvvm-in-xamarin-forms-listview) for more details.

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
