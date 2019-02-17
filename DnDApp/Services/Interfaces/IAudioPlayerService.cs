using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Services
{
   public interface IAudioPlayerService
    {
        void updateAudioUrl(string url, string episodeTitle);

    }
}
