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
    
    public partial class Zuweisung
    {
        public int Id { get; set; }
        public int Stunden { get; set; }
        public System.DateTime Von { get; set; }
        public System.DateTime Bis { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Auftrag Auftrag { get; set; }
        public virtual Zuweisungskategorie Zuweisungskategorie { get; set; }
    }
}
