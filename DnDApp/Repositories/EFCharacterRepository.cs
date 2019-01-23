using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.DataBase;
using DnDApp.Repositories;
using DnDApp.Common;

namespace DnDApp.Repositories
{
    public class EFCharacterRepository : ICharacterRepository
    {
        private readonly DnDAppDbContext _db = new DnDAppDbContext();


        public IEnumerable<PartyMember> GetCharacters(bool bypassing = false)
        {
            if (!bypassing && HttpRuntime.Cache["Characters"] is IEnumerable<PartyMember> characters)
            {
                return characters;
            }

            var characterList = _db.PartyMembers.ToList();
            HttpRuntime.Cache.Insert("Characters", characterList, null, DateTime.Now.Add(CacheExpirations.DefaultTimeSpan), TimeSpan.Zero)
            return characterList;
        }

        public PartyMember GetCharacter(int CharacterId)
        {
            return _db.PartyMembers.SingleOrDefault(_ => _.Id == CharacterId);
        }
    }
}