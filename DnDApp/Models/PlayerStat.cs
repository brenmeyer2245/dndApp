namespace DnDApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlayerStat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlayerStat()
        {
            PartyMembers = new HashSet<PartyMember>();
        }

        [Key]
        public int StatId { get; set; }

        public int Charisma { get; set; }

        public int Intelligence { get; set; }

        public int Constitution { get; set; }

        public int Strength { get; set; }

        public int Wisdom { get; set; }

        public int Dexterity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartyMember> PartyMembers { get; set; }
    }
}
