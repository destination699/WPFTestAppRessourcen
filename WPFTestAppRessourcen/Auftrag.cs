//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFTestAppRessourcen
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auftrag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auftrag()
        {
            this.Zuweisungen = new HashSet<Zuweisung>();
        }
    
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public int Stunden { get; set; }
        public System.DateTime Beginn { get; set; }
        public Status Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zuweisung> Zuweisungen { get; set; }
        public virtual Auftragskategorie Auftragskategorie { get; set; }
    }
}
