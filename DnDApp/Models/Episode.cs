namespace DnDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Episode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Episode()
        {
            PlayerEpisodes = new HashSet<PlayerEpisode>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string EpisodeName { get; set; }

        public int? ChapterNumber { get; set; }

        public int? BookId { get; set; }

        [StringLength(1500)]
        public string Description { get; set; }

        public virtual Book Book { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerEpisode> PlayerEpisodes { get; set; }
    }
}
