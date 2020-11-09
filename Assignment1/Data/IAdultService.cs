using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdultService
    {
        public Task<IList<Adult>> getAdult();
        public Task Add(Adult newAdult);
        public Task Remove(Adult adultToRemove);
    }
}