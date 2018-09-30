using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;



namespace WPFTestAppRessourcen
{

    
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : MetroWindow
    {
        RPModellContainer context = new RPModellContainer();

        public MainWindow()
        {
            InitializeComponent();
            context.Personen.Load();
            PersonenListView.ItemsSource = context.Personen.Local;


            context.Aufträge.Load();
            AufträgeListview.ItemsSource = context.Aufträge.Local;




            //initialdatenErfassen();


        }




        void PersonListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Person p = ((ListViewItem)sender).Content as Person;
            PersonWindow pwin = new PersonWindow();
            var collectionViewSource = pwin.FindResource("Teams") as CollectionViewSource;
            collectionViewSource.Source = context.Teams.ToList<Team>();
           


            pwin.DataContext = p;
            pwin.ShowDialog();
            if (pwin.DialogResult.HasValue && pwin.DialogResult.Value)
            {
                context.SaveChanges();
            }
            else
            {
                context.Entry<Person>(p).State = EntityState.Unchanged;
                PersonenListView.Items.Refresh();
            }
        }


        public void initialdatenErfassen()
        {
            Team team = new Team();
            team.Bezeichnung = "Objekte";
            team.Kürzel = "OBJ";

            Team team2 = new Team();
            team2.Bezeichnung = "Finanzen";
            team2.Kürzel = "FIN";

            context.Teams.Add(team);
            context.Teams.Add(team2);
            context.SaveChanges();

            Auftragskategorie akat = new Auftragskategorie();
            akat.Bezeichnung = "Neueinführung";
            akat.Kürzel = "Neu";

            Auftragskategorie akat2 = new Auftragskategorie();
            akat2.Bezeichnung = "Standardauftrag";
            akat2.Kürzel = "STAND";

            context.Auftragskategorien.Add(akat);
            context.Auftragskategorien.Add(akat2);
            context.SaveChanges();
            
            Person p = new Person();
            p.Vorname = "Thomas";
            p.Name = "Diethelm";
            p.Team = context.Teams.First();
            p.Kürzel = "TD208";

            Person p1 = new Person();
            p1.Vorname = "Doris";
            p1.Name = "Alder";
            p1.Team = context.Teams.First();
            p1.Kürzel = "AD111";


            context.Personen.Add(p);
            context.Personen.Add(p1);
            context.SaveChanges();

            Zuweisungskategorie zkat = new Zuweisungskategorie();
            zkat.Bezeichnung = "Ausführung";
            zkat.Kürzel = "Normal";
            context.Zuweisungskategorien.Add(zkat);
            context.SaveChanges();



            Zuweisung z = new Zuweisung();
            z.Auftrag = context.Aufträge.First();
            z.Person = context.Personen.First();
            z.Stunden = 15;
            z.Zuweisungskategorie = context.Zuweisungskategorien.First();
            z.Von = System.DateTime.Now;
            z.Bis = System.DateTime.Now;

            context.Zuweisungen.Add(z);
            context.SaveChanges();






            Auftrag x = new Auftrag();
            x.Auftragskategorie = context.Auftragskategorien.First<Auftragskategorie>();
            x.Beginn = DateTime.Now;
            x.Bezeichnung = "Testauftrag";

            x.Status = Status.Aktiv;
            context.Aufträge.Add(x);
            context.SaveChanges();



        }

        private void RibbonBtnPersonNeu_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow pwin = new PersonWindow();
            Person newPerson = new Person();
            pwin.DataContext = newPerson;
            var collectionViewSource = pwin.FindResource("Teams") as CollectionViewSource;
            collectionViewSource.Source = context.Teams.ToList<Team>();

            pwin.ShowDialog();
            if (pwin.DialogResult.HasValue && pwin.DialogResult.Value)
            {
                context.Personen.Add(newPerson);
                context.SaveChanges();
            }
            else
            {
            }

        }

        private void RibbonBtnPersonMut_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow pwin = new PersonWindow();
            var collectionViewSource = pwin.FindResource("Teams") as CollectionViewSource;
            collectionViewSource.Source = context.Teams.ToList<Team>();

            Person p = PersonenListView.SelectedItem as Person;

            if (p == null)
            {

                this.ShowMessageAsync("Hinweis: Person mutieren","Keine Person ausgewählt");
            }
            else
            {
                pwin.DataContext = p;
                pwin.ShowDialog();
                if (pwin.DialogResult.HasValue && pwin.DialogResult.Value)
                {
                    context.SaveChanges();
                }
                else
                {
                    context.Entry<Person>(p).State = EntityState.Unchanged;
                    PersonenListView.Items.Refresh();
                }

            }



        }

        private void RibbonBtnPersonDelete_Click(object sender, RoutedEventArgs e)
        {
            context.Personen.RemoveRange(PersonenListView.SelectedItems.Cast<Person>());
            context.SaveChanges();
        }

        private void RibbonBtnAuftragNeu_Click(object sender, RoutedEventArgs e)
        {
            AuftragWindow awin = new AuftragWindow();
            var collectionViewSource = awin.FindResource("Auftragskategorien") as CollectionViewSource;
            collectionViewSource.Source = context.Auftragskategorien.ToArray<Auftragskategorie>();

            Auftrag auftrag = new Auftrag();
            awin.DataContext = auftrag;
            awin.ShowDialog();
            if (awin.DialogResult.HasValue && awin.DialogResult.Value)
            {
                context.Aufträge.Add(auftrag);
                context.SaveChanges();
            }
            else
            {
                context.Entry<Auftrag>(auftrag).State = EntityState.Unchanged;
                AufträgeListview.Items.Refresh();
            }

        }

        private void RibbonBtnAuftragMut_Click(object sender, RoutedEventArgs e)
        {
            AuftragWindow awin = new AuftragWindow();
            var collectionViewSource = awin.FindResource("Auftragskategorien") as CollectionViewSource;
            collectionViewSource.Source = context.Auftragskategorien.ToArray<Auftragskategorie>();

            Auftrag a = AufträgeListview.SelectedItem as Auftrag;


            if (a == null)
            {

                this.ShowMessageAsync("Hinweis: Auftrag mutieren", "Kein Auftrag ausgewählt");
            }

            else
            {
                awin.DataContext = a;
                awin.ShowDialog();
                if (awin.DialogResult.HasValue && awin.DialogResult.Value)
                {
                    context.SaveChanges();
                }
                else
                {
                    context.Entry<Auftrag>(a).State = EntityState.Unchanged;
                    AufträgeListview.Items.Refresh();
                }
            }

        }

        private void RibbonBtnAuftragDelete_Click(object sender, RoutedEventArgs e)
        {
            context.Aufträge.RemoveRange(AufträgeListview.SelectedItems.Cast<Auftrag>());
            context.SaveChanges();
        }
    }
}
