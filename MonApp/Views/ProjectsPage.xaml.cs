// TODO : ajouter le using pour accéder à la classe Project
// using WorkTracker.MonApp.Models;

using System.Collections.ObjectModel;
using WorkTracker.MonApp.Models;

namespace WorkTracker.MonApp.Views;

public partial class ProjectsPage : ContentPage
{
    public ProjectsPage()
    {
        InitializeComponent();

        ChargerProjets();
    }

    private void ChargerProjets()
    {
        var projets = new ObservableCollection<Project>
        {
        new Project { Id = 1, Name = "Site web", Description = "Refonte du site vitrine" },
        new Project { Id = 2, Name = "API REST", Description = "Développement backend" },
        new Project { Id = 3, Name = "Formation", Description = "Préparation des TPs MAUI" },
        };
        cvProjets.ItemsSource = projets;
        projets.Add(new Project{Name = "Projet tardif",Description = "Ajouté après le binding" });
        }
}