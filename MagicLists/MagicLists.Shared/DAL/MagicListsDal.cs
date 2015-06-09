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
            try
            {
                result = await query.FindAsync();
            }
            catch (Exception ex) { }

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
