using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoservice.Models
{
    class Vehicle
    {
        private List<Part> _parts;
        private Random _random;

        public Vehicle(string name, List<Part> parts)
        {
            _random = new Random(Guid.NewGuid().GetHashCode());

            Name = name;
            _parts = parts;
        }

        public string Name { get; private set; }

        public List<Part> Parts => new List<Part>(_parts);

        public void ReplacePart(Part currentPart, Part newPart)
        {
            int currentPartIndex = _parts.FindIndex(part => part == currentPart);

            _parts[currentPartIndex] = newPart;
        }

        public void BreakDown()
        {
            foreach (Part part in _parts)
            {
                if (_random.Next(0, 100) < 50)
                    part.GoBad();
            }
        }
    }
}