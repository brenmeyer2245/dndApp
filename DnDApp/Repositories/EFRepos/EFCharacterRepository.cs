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
            if (!bypassing && HttpRuntime.Cache[CacheKeys.AllCharacters] is IEnumerable<PartyMember> characters)
            {
                return characters;
            }

            var characterList = _db.PartyMembers.ToList();
            HttpRuntime.Cache.Insert(CacheKeys.AllCharacters, characterList, null, DateTime.Now.Add(CacheExpirations.DefaultTimeSpan), TimeSpan.Zero);
            return characterList;
        }

        public PartyMember GetCharacter(int CharacterId)
        {
            return _db.PartyMembers.SingleOrDefault(_ => _.Id == CharacterId);
        }

        public void CreateCharacter(PartyMember character)
        {
            _db.PartyMembers.Add(character);
            _db.SaveChanges();

            HttpRuntime.Cache.Remove(CacheKeys.AllCharacters);
        }

        public PartyMember EditCharacter(PartyMember character)
        {
            var characterToEdit = _db.PartyMembers.SingleOrDefault(_ => _.Id == character.Id);
            if (characterToEdit == null) return null;

            characterToEdit.Headshot = character.Headshot;
            characterToEdit.Name = character.Name;
            characterToEdit.Level = character.Level;

            characterToEdit.Bio = character.Bio;
            characterToEdit.PlayerStat.Charisma = character.PlayerStat.Charisma;
            characterToEdit.PlayerStat.Constitution = character.PlayerStat.Constitution;
            characterToEdit.PlayerStat.Dexterity = character.PlayerStat.Dexterity;
            characterToEdit.PlayerStat.Intelligence = character.PlayerStat.Intelligence;
            characterToEdit.PlayerStat.Wisdom = character.PlayerStat.Wisdom;
            characterToEdit.PlayerStat.Strength = character.PlayerStat.Strength;
            _db.SaveChanges();

            HttpRuntime.Cache.Remove(CacheKeys.AllCharacters);

            return characterToEdit;
        }
    }
}