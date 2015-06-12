using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLists.DataModel
{
    public class MagicListsDal
    {

        public async Task<List<MagicLists>> GetListsAync()
        {
            var query = ParseObject.GetQuery("lists");


            IEnumerable<ParseObject> result = new List<ParseObject>();


            result = await query.FindAsync();

            var listItems = new List<MagicLists>();
            foreach (var listItemParseObject in result)
            {
                var listItem = await MagicLists.CreateFromParseObject(listItemParseObject);
                listItems.Add(listItem);
            }
            return listItems;




        }
    }
}
