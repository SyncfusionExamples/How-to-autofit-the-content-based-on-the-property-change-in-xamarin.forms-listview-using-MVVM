using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SfListViewSample
{
    [Preserve(AllMembers = true)]
    #region MessageTemplateSelector
    public class MessageDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        #region Properties        
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }        

        #endregion

        #region Constructor
        public MessageDataTemplateSelector()
        {            
            Template1 = new DataTemplate(typeof(DataTemplate1));
            Template2 = new DataTemplate(typeof(DataTemplate2));
        }
        #endregion

        #region OnSelectTemplate
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {            
            var bookInfo = (item as BookInfo);
            if (bookInfo.IsSelected)
                return Template1;
            else
                return Template2;
        } 
        #endregion
    }

    #endregion    
}
