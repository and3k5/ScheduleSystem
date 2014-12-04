/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class ViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public ViewModel()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChangedEventHandler eventHandle = PropertyChanged;
            
            if (eventHandle != null)
                eventHandle(this, new PropertyChangedEventArgs(propertyName));
        }
        public extern string Validate(string FieldName);
        string IDataErrorInfo.this[string field]
        {
            get {
                return Validate(field);
            }
            //set;
        }

        string IDataErrorInfo.Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

*/