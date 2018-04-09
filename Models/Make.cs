using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Models
{
    public class Make
    {
        // 'prop' for property abbrev.
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }


        // 'ctor' for constructor abbrev
        // 'cmd .' on objects to give context menu and option to add namespace to top of file.
        // difference between lists and collections is that a list gives the ability to access the objects in a collection using their index.
        public Make()
        {
            Models = new Collection<Model>();
        }
    }
}