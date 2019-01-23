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
        IEnumerable<PartyMember> GetCharacters();
        PartyMember GetCharacter(int id);
    }
}
