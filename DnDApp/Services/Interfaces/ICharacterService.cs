using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.Models;

namespace DnDApp.Services
{
    public interface ICharacterService
    {
        IEnumerable<PartyMember> GetCharacters(bool bypassing = false);
        PartyMember GetCharacter(int id);
        void CreateCharacter(PartyMember character);
        PartyMember EditCharacter(PartyMember character);

    }
}
