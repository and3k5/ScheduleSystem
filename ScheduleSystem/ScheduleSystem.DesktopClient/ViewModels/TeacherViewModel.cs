using System;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class TeacherViewModel : Teacher, IDataErrorInfo, INotifyPropertyChanged
    {
        // Creates new teacher object (_teacher) to avoid crashes.
        private Teacher _teacher;
        
        private static bool StringCheck(string txt)
        {
            // Check if string is valid.
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }

        public TeacherViewModel()
        {
            // Create teacher object
            _teacher = new Teacher();
        }
        
        public TeacherViewModel(Teacher teacher)
        {
            // Bind teacher to teacherviewmodel.
            _teacher = teacher;
        }

        public override string Name
        {
            get
            {
                // Returns name of _teacher
                return _teacher.Name;
            }
            set
            {
                // Sets name value and notifies "client" of change.
                _teacher.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override string Skills
        {
            get
            {
                // Returns Skills of teacher
                return _teacher.Skills;
            }
            set
            {
                // Sets Skills value and notifies "client" of change.
                _teacher.Skills = value;
                NotifyPropertyChanged("Skills");
            }
        }

        public override string Email
        {
            get
            {
                // Returns Email of teacher
                return _teacher.Email;
            }
            set
            {
                // Sets Email value and notifies "client" of change.
                _teacher.Email = value;
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
                    case "Skills":
                        return StringCheck(this.Skills) ? null : "Skills must not be empty";
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
