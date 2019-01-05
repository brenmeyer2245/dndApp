using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Models;
using DnDApp.DataBase;
namespace DnDApp.Repositories
{
    public class CharacterRepository
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

        public void MakePlayerBrendan(int CharacterId)
        {
            var character = _db.PartyMembers.SingleOrDefault(_ => _.Id == CharacterId);
            character.Name = "Brendan";
            _db.SaveChanges();
        }
    }
}