using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleSystem.DesktopClient.ViewModels
{
    class CourseViewModel : Course, ViewModel
    {
        public override string Validate(string fieldname) {
            if (fieldname == "Name")
            {
                return "Hej";
            }
            else
            {
                return null;
            }
        }
    }
}
