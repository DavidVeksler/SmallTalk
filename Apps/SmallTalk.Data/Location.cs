namespace SmallTalk.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location()
        {
            Lessons = new HashSet<Lesson>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool? IsFeature { get; set; }

        public string Address1 { get; set; }

        public string PostalCode { get; set; }

        public int? TimesUsed { get; set; }

        public DateTime? DateCreated { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
