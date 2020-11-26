using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class AdultService : IAdultService
    {
        
        private CustomDBContext DBContext;

        public AdultService()
        {
            DBContext = new CustomDBContext();
        }

        public async Task<IList<Adult>> getAdult()
        {
            IList<Adult> adults = DBContext.Adults.ToList();
            return adults;
        }

        public async Task Add(Adult newAdult)
        {
            DBContext.Adults.AddAsync(newAdult);
            DBContext.SaveChangesAsync();
        }

        public async Task Remove(Adult adultToRemove)
        {
            DBContext.Adults.Remove(adultToRemove);
            DBContext.SaveChangesAsync();
        }
    }
}