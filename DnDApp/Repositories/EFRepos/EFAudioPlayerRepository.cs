using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.DataBase;
using DnDApp.Services;

namespace DnDApp.Repositories
{
    public class EFAudioPlayerRepository : IAudioPlayerRepository
    {

        private readonly DnDAppDbContext _db = new DnDAppDbContext();
        private readonly CurrentUserService userService = new CurrentUserService();

        public void updateAudioUrl(string url, string title)
        {
            //get the current user's audio player
            var currentUser = userService.GetCurrentUser();
            var audioPlayer = _db.AudioPlayer.SingleOrDefault(plyr => plyr.Id == currentUser.AudioPlayerId);

            //update the audio player in the db
            audioPlayer.episodeTitle = title;
            audioPlayer.audioUrl = url;
            _db.SaveChanges();

            //update the audio player in the current User in Cache
            currentUser.AudioPlayer.audioUrl = url;
            currentUser.AudioPlayer.episodeTitle = title; 
        }
    }
}