﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPModellContainer : DbContext
    {
        public RPModellContainer()
            : base("name=RPModellContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Person> Personen { get; set; }
        public virtual DbSet<Auftrag> Aufträge { get; set; }
        public virtual DbSet<Zuweisung> Zuweisungen { get; set; }
        public virtual DbSet<Auftragskategorie> Auftragskategorien { get; set; }
        public virtual DbSet<Zuweisungskategorie> Zuweisungskategorien { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }
}
