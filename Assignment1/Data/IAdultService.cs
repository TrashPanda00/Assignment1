using System.Collections.Generic;
using Models;

namespace Assignment1.Data
{
    public interface IAdultService
    {
        public IList<Adult> getAdult();
        public void Add(Adult newAdult);
        public void Remove(Adult adultToRemove);
    }
}