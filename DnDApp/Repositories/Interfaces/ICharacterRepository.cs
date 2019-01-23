using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;

namespace DnDApp.Repositories
{
    public interface ICharacterRepository
    {
        IEnumerable<PartyMember> GetCharacters(bool bypassing = false);
         PartyMember GetCharacter(int id);
    }
}