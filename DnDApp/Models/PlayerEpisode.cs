namespace DnDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlayerEpisode
    {
        public int Id { get; set; }

        public int? PlayerId { get; set; }

        public int? EpisodeId { get; set; }

        public virtual Episode Episode { get; set; }

        public virtual PartyMember PartyMember { get; set; }
    }
}
