using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class CourseViewModel : Course, IDataErrorInfo, INotifyPropertyChanged
    {
        private Course _course = new Course();
        private static bool StringCheck(string txt)
        {
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public CourseViewModel()
        {
            _course = new Course();
        }
        public CourseViewModel(Course course)
        {
            _course = course;
        }

        public override string Name
        {
            get
            {
                return _course.Name;
            }
            set
            {
                _course.Name = value;
            }
        }

        public override DateTime StartDate
        {
            get
            {
                return _course.StartDate;
            }
            set
            {
                _course.StartDate = value;
            }
        }

        public override DateTime EndDate
        {
            get
            {
                return _course.EndDate;
            }
            set
            {
                _course.EndDate = value;
            }
        }

        public override Collection<Lecture> Lectures
        {
            get
            {
                return _course.Lectures;
            }
            set
            {
                _course.Lectures = value;
            }
        }

        public override Collection<Student> Students
        {
            get
            {
                return _course.Students;
            }
            set
            {
                _course.Students = value;
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
                    case "Lectures":
                        return (this.Lectures.Count > 0) ? null : "Course must contain at least one lecture";
                    case "Students":
                        return (this.Students.Count > 0) ? null : "Course should contain at least one student";
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
