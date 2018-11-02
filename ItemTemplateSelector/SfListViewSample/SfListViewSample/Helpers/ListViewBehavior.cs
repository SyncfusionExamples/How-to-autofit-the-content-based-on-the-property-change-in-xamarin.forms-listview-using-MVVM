using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SfListViewSample
{
    public class ListViewBehavior : Behavior<SfListView>
    {
        SfListView listView;
        protected override void OnAttachedTo(SfListView bindable)
        {
            base.OnAttachedTo(bindable);
            listView = bindable as SfListView;
            listView.ItemAppearing += OnItemAppearing;
            listView.ItemDisappearing += ListView_ItemDisappearing;
        }
        private void OnItemAppearing(object sender, ItemAppearingEventArgs e)
        {
            (e.ItemData as BookInfo).PropertyChanged += OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var itemIndex = listView.DataSource.DisplayItems.IndexOf(sender);
            if (Device.RuntimePlatform != Device.macOS)
                Device.BeginInvokeOnMainThread(() => { listView.RefreshListViewItem(itemIndex, itemIndex, false); });
        }
        private void ListView_ItemDisappearing(object sender, ItemDisappearingEventArgs e)
        {
            (e.ItemData as BookInfo).PropertyChanged -= OnPropertyChanged;
        }

        protected override void OnDetachingFrom(SfListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemAppearing -= OnItemAppearing;
        }
    }
}
