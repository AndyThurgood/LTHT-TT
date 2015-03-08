using System.Collections.Generic;
using Data.Domain.Models;

namespace Logic.Interfaces
{
    public interface IColourService
    {
        IEnumerable<Colour> GetColours();
        void SaveColour(Colour colour);
        Colour GetColour(int id);
        void DeleteColour(int id);
    }
}
