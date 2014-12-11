using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    public class CourseViewModel : Course, IDataErrorInfo, INotifyPropertyChanged
    {
        // Creates new Course object (_course) to avoid crashes.
        private Course _course = new Course();
        private static bool StringCheck(string txt)
        {
            // Check if string is valid.
            return (!String.IsNullOrEmpty(txt) && !String.IsNullOrWhiteSpace(txt) && txt.Trim().Length != 0);
        }
        public CourseViewModel()
        {
            // Create Course object
            _course = new Course();
        }
        public CourseViewModel(Course course)
        {
            // Bind course to courseviewmodel.
            _course = course;
        }

        public override string Name
        {
            get
            {
                // Returns name of course
                return _course.Name;
            }
            set
            {
                // Sets name value and notifies "client" of change.
                _course.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public override DateTime StartDate
        {
            get
            {
                // Returns StartDate of course
                return _course.StartDate;
            }
            set
            {
                // Sets StartDate value and notifies "client" of change.
                _course.StartDate = value;
                NotifyPropertyChanged("StartDate");
            }
        }

        public override DateTime EndDate
        {
            get
            {
                // Returns EndDate of course
                return _course.EndDate;
            }
            set
            {
                // Sets EndDate value and notifies "client" of change.
                _course.EndDate = value;
                NotifyPropertyChanged("EndDate");
            }
        }

        public override Collection<Lecture> Lectures
        {
            get
            {
                // Returns Lectures of course
                return _course.Lectures;
            }
            set
            {
                // Sets Lectures value and notifies "client" of change.
                _course.Lectures = value;
                NotifyPropertyChanged("Lectures");
            }
        }

        public override Collection<Student> Students
        {
            get
            {
                // Returns Students of course
                return _course.Students;
            }
            set
            {
                // Sets Students value and notifies "client" of change.
                _course.Students = value;
                NotifyPropertyChanged("Students");
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
                    case "Lectures":
                        return (this.Lectures.Count > 0) ? null : "Course must contain at least one lecture";
                    case "Students":
                        return (this.Students.Count > 0) ? null : "Course should contain at least one student";
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
