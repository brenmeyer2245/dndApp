using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Repositories
{
    public interface IAudioPlayerRepository
    {
        void updateAudioUrl(string url, string title);
    }
}
