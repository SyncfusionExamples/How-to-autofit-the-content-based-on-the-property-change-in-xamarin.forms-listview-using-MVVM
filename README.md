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
```
