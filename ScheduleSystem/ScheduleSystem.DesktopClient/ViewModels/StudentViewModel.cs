using System;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class StudentViewModel : Student, IDataErrorInfo, INotifyPropertyChanged
    {
        // Creates new Student object (_student) to avoid crashes.
        private Student _student;
        private static bool StringCheck(string txt)
        {
            // Check if string is valid.
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public StudentViewModel()
        {
            // Create Student object
            _student = new Student();
        }

        public StudentViewModel(Student student)
        {
            // Bind student to studentviewmodel.
            _student = student;
        }

        public override string Name
        {
            get
            {
                // Returns name of _student
                return _student.Name;
            }
            set
            {
                // Sets name value and notifies "client" of change.
                _student.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override string CPR
        {
            get
            {
                // Returns CPR of student
                return _student.CPR;
            }
            set
            {
                // Sets CPR value and notifies "client" of change.
                _student.CPR = value;
                NotifyPropertyChanged("CPR");
            }
        }

        public override string Email
        {
            get
            {
                // Returns Email of student
                return _student.Email;
            }
            set
            {
                // Sets Email value and notifies "client" of change.
                _student.Email = value;
                NotifyPropertyChanged("Email");
            }
        }

        // Notifies "client" of property change
        public event PropertyChangedEventHandler PropertyChanged;

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
                    case "CPR":
                        return StringCheck(this.CPR) ? null : "CPR must not be empty";
                    case "Email":
                        return StringCheck(this.Email) ? null : "Email must not be empty";
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
