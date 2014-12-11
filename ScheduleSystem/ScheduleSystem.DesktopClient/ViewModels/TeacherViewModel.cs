using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class TeacherViewModel : Teacher, IDataErrorInfo, INotifyPropertyChanged
    {
        // Define _teacher as a Teacher object
        private Teacher _teacher;
        
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }

        public TeacherViewModel()
        {
            _teacher = new Teacher();
        }
        
        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher;
        }

        public override string Name
        {
            get
            {
                return _teacher.Name;
            }
            set
            {
                _teacher.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override string Skills
        {
            get
            {
                return _teacher.Skills;
            }
            set
            {
                _teacher.Skills = value;
                NotifyPropertyChanged("Skills");
            }
        }

        public override string Email
        {
            get
            {
                return _teacher.Email;
            }
            set
            {
                _teacher.Email = value;
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
                    case "Skills":
                        return StringCheck(this.Skills) ? null : "Skills must not be empty";
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
