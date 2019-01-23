using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.Repositories;

namespace DnDApp.Services
{
    public class EFCharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public EFCharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public PartyMember GetCharacter(int id)
        {
            return _characterRepository.GetCharacter(id);
        }

        public IEnumerable<PartyMember> GetCharacters(bool bypassing = false)
        {
            return _characterRepository.GetCharacters(bypassing);
        }
    }
}