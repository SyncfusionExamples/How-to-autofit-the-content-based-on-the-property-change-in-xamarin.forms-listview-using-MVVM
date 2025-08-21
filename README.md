# How-to-autofit-the-content-based-on-the-property-change-in-xamarin.forms-listview-using-MVVM

This sample application shows how to autfit the listview item height based on property change in xamarin.forms listview using MVVM.

## Sample

```xaml
<syncfusion:SfListView x:Name="listView"                                                                                             
                        AutoFitMode="Height"                                  
                        ItemSpacing="5"                                               
                        ItemTemplate="{StaticResource MessageDataTemplateSelector}"
                        ItemsSource="{Binding bookInfo}">
    <syncfusion:SfListView.Behaviors>
        <local:ListViewBehavior/>
    </syncfusion:SfListView.Behaviors>
</syncfusion:SfListView>

    public class ListViewBehavior : Behavior<SfListView>
    {
        SfListView listView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            listView = bindable as SfListView;
            listView.ItemAppearing += OnItemAppearing;
            listView.ItemDisappearing += OnItemDisappearing;
        }
        private void OnItemAppearing(object sender, ItemAppearingEventArgs e)
        {
            (e.ItemData as BookInfo).PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsSelected")
            {
                var itemIndex = listView.DataSource.DisplayItems.IndexOf(sender);
                if (Device.RuntimePlatform != Device.macOS)
                    Device.BeginInvokeOnMainThread(() => { listView.RefreshListViewItem(itemIndex, itemIndex, false); });
            }
        }
        private void OnItemDisappearing(object sender, ItemDisappearingEventArgs e)
        {
            (e.ItemData as BookInfo).PropertyChanged -= OnPropertyChanged;
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemAppearing -= OnItemAppearing;
            listView.ItemDisappearing -= OnItemDisappearing;
        }
    }
```
## Requirements to run the demo
* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).
* 
## Troubleshooting
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
