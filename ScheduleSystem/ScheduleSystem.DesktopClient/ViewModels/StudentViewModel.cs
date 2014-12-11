using System;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class StudentViewModel : Student, IDataErrorInfo, INotifyPropertyChanged
    {
        // Define _student as a student object
        private Student _student;
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public StudentViewModel()
        {
            _student = new Student();
        }

        public StudentViewModel(Student student)
        {
            _student = student;
        }

        public override string Name
        {
            get
            {
                return _student.Name;
            }
            set
            {
                _student.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override string CPR
        {
            get
            {
                return _student.CPR;
            }
            set
            {
                _student.CPR = value;
                NotifyPropertyChanged("CPR");
            }
        }

        public override string Email
        {
            get
            {
                return _student.Email;
            }
            set
            {
                _student.Email = value;
                NotifyPropertyChanged("Email");
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
                    case "CPR":
                        return StringCheck(this.CPR) ? null : "CPR must not be empty";
                    case "Email":
                        return StringCheck(this.Email) ? null : "Email must not be empty";
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
