using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLists.DataModel
{
    public class MagicListCollection : ObservableCollection<MagicLists>
    {

        public MagicListCollection()
            : base()
        {

            Add(new MagicLists("1", "Test Clock", "Mini Text", "", "", "", false, 1));

        }




    }
}
