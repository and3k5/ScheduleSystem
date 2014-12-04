using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class StudentViewModel : Student, IDataErrorInfo, INotifyPropertyChanged
    {
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public StudentViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChangedEventHandler eventHandle = PropertyChanged;

            if (eventHandle != null)
                eventHandle(this, new PropertyChangedEventArgs(propertyName));
        }
        string IDataErrorInfo.this[string field]
        {
            get
            {
                switch (field)
                {
                    case "Name":
                        return StringCheck(this.Name) ? null : "String must not be empty";
                    case "CPR":
                        return StringCheck(this.CPR) ? null : "CPR must not be empty";
                    case "Email":
                        return StringCheck(this.Email) ? null : "Email must not be empty";
                }
                return null;
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
