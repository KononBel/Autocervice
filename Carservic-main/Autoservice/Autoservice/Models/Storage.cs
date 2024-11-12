using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    class Storage
    {
        private List<Part> _parts;

        public Storage(int countPartEch)
        {
            _parts = Parts.Get(countPartEch);
        }

        public Part GetAvailablePart(string partName)
        {
            Part availablePart = _parts.Find(part => part.Name == partName);

            if (availablePart != null)
                _parts.Remove(availablePart);

            return availablePart;
        }
    }
}