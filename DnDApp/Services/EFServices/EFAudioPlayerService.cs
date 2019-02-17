using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DnDApp.Repositories;

namespace DnDApp.Services
{
    public class EFAudioPlayerService : IAudioPlayerService
    {
        private readonly IAudioPlayerRepository _audioRepo;

        public EFAudioPlayerService(IAudioPlayerRepository audioRepo)
        {
            _audioRepo = audioRepo;
        }

        public void updateAudioUrl(string url, string title)
        {
            _audioRepo.updateAudioUrl(url, title);
        }
    }
}