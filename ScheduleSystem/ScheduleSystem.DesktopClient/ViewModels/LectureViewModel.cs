using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class LectureViewModel : Lecture, IDataErrorInfo, INotifyPropertyChanged
    {
        private Lecture _lecture = new Lecture();
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public LectureViewModel()
        {
            _lecture = new Lecture();
        }
        public LectureViewModel(Lecture lecture)
        {
            _lecture = lecture;
        }

        public override string Name
        {
            get
            {
                return _lecture.Name;
            }
            set
            {
                _lecture.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override DateTime StartDate
        {
            get
            {
                return _lecture.StartDate;
            }
            set
            {
                _lecture.StartDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        public override DateTime EndDate
        {
            get
            {
                return _lecture.EndDate;
            }
            set
            {
                _lecture.EndDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        public override Collection<Teacher> Teachers
        {
            get
            {
                return _lecture.Teachers;
            }
            set
            {
                _lecture.Teachers = value;
                NotifyPropertyChanged("Teachers");
            }
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
                    case "StartDate":
                        return (this.StartDate.CompareTo(this.EndDate) < 0) ? null : "StartDate must be before end date";
                    case "EndDate":
                        return (this.StartDate.CompareTo(this.EndDate) < 0) ? null : "EndDate must be later than start date";
                    case "Teachers":
                        return (this.Teachers.Count > 0) ? null : "Lecture must contain at least one teacher";
                }
                return null;
            }
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
