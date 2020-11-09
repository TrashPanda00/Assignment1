using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Data
{
    public class AdultService : IAdultService
    {
        private FileContext fileContext;

        public AdultService()
        {
            fileContext = new FileContext();
        }

        public Task<IList<Adult>> getAdult()
        {
            return Task.FromResult(fileContext.Adults);
        }

        public async Task Add(Adult newAdult)
        {
            fileContext.Adults.Add(newAdult);
            fileContext.SaveChanges();
        }

        public async Task Remove(Adult adultToRemove)
        {
            fileContext.Adults.Remove(adultToRemove);
            fileContext.SaveChanges();
        }
    }
}