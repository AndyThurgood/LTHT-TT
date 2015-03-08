using System;
using System.Collections.Generic;
using Data.Domain.Models;
using Data.Interfaces;
using Logic.Interfaces;

namespace Logic.Services
{
    public class ColourService: IColourService
    {
        private readonly IRepository<Colour> _repository;

        public ColourService(IRepository<Colour> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Data.Domain.Models.Colour> GetColours()
        {
            return _repository.All();
        }

        public void SaveColour(Data.Domain.Models.Colour colour)
        {
            throw new NotImplementedException();
        }

        public Data.Domain.Models.Colour GetColour(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteColour(int id)
        {
            throw new NotImplementedException();
        }
    }
}
