using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdultService
    {
        public Task<IList<Adult>> getAdult();
        public void Add(Adult newAdult);
        public void Remove(Adult adultToRemove);
        public int GetCount();
    }
}