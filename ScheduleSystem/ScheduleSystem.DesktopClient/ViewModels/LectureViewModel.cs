using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class LectureViewModel : Lecture, IDataErrorInfo, INotifyPropertyChanged
    {
        // Creates new lecture object (_lecture) to avoid crashes.
        private Lecture _lecture = new Lecture();
        private static bool StringCheck(string txt)
        {
            // Check if string is valid.
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public LectureViewModel()
        {
            // Create lecture object
            _lecture = new Lecture();
        }
        public LectureViewModel(Lecture lecture)
        {
            // Bind lecture to lectureviewmodel.
            _lecture = lecture;
        }

        public override string Name
        {
            get
            {
                // Returns name of lecture
                return _lecture.Name;
            }
            set
            {
                // Sets name value and notifies "client" of change.
                _lecture.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override DateTime StartDate
        {
            get
            {
                // Returns StartDate of lecture
                return _lecture.StartDate;
            }
            set
            {
                // Sets StartDate value and notifies "client" of change.
                _lecture.StartDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        public override DateTime EndDate
        {
            get
            {
                // Returns EndDate of lecture
                return _lecture.EndDate;
            }
            set
            {
                // Sets EndDate value and notifies "client" of change.
                _lecture.EndDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        public override Collection<Teacher> Teachers
        {
            get
            {
                // Returns Teachers of lecture
                return _lecture.Teachers;
            }
            set
            {
                // Sets Teachers value and notifies "client" of change.
                _lecture.Teachers = value;
                NotifyPropertyChanged("Teachers");
            }
        }

        // Raises property changed event.
        public event PropertyChangedEventHandler PropertyChanged;

        // Notifies "client" of property change
        protected void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChangedEventHandler eventHandle = PropertyChanged;

            if (eventHandle != null)
                eventHandle(this, new PropertyChangedEventArgs(propertyName));
        }

        // Making sure fields are not empty
        // And shows appropriate error message
        // depending on missing information.
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

        //Handeling data errors.
        string IDataErrorInfo.Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
