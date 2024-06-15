using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class Days_GroceriesDAO : Repository<Days_Groceries>
    {
        public Days_GroceriesDAO() : base(new DatabaseModel())
        {
        }
        public int AddGroceryToDate(Days_Groceries entity, bool saveChanges = true)
        {
            var dayGrocery = new Days_Groceries
            {
                day_id = entity.day_id,
                gram_amount = entity.gram_amount,
                grocery_id = entity.grocery_id
            };

            Entities.Add(dayGrocery);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else return 0;
        }

        public IQueryable<Days_Groceries> GetDayGroceries(string username, string date)
        {
            var query = from g in Entities
                        where g.Day.date == date && g.Day.User.username == username
                        select g;
            return query;
        }

        public override int Update(Days_Groceries entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
