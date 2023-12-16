using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace learning_management_sys.Data
{
    public interface IUser
    {
        string ID { get; set; }
        string Name { get; set; }
        string Semester { get; set; }
    }

}
