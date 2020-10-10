using System.Collections.Generic;
using System.Threading.Tasks;
using FileData;
using Models;

namespace Assignment1.Data
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

        public void Add(Adult newAdult)
        {
            fileContext.Adults.Add(newAdult);
            fileContext.SaveChanges();
        }

        public void Remove(Adult adultToRemove)
        {
            fileContext.Adults.Remove(adultToRemove);
            fileContext.SaveChanges();
        }
    }
}