using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.DataBase;
using DnDApp.Repositories;

namespace DnDApp.Repositories
{
    public class EFCharacterRepository : ICharacterRepository
    {
        private readonly DnDAppDbContext _db = new DnDAppDbContext();


        public IEnumerable<PartyMember> GetCharacters()
        {
            return _db.PartyMembers.ToList();
        }

        public PartyMember GetCharacter(int CharacterId)
        {
            return _db.PartyMembers.SingleOrDefault(_ => _.Id == CharacterId);
        }
    }
}