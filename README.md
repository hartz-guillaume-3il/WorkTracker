# WorkTracker

## Présentation

WorkTracker est une application .NET MAUI de suivi de projets et de sessions de travail.
Le projet est structuré autour d’une organisation claire séparant les modèles, les services, les vues et les ViewModels.

L’application permet notamment de :
- gérer des projets ;
- gérer des sessions de travail ;
- utiliser un chronomètre ;
- naviguer entre plusieurs pages via Shell.

## Fonctionnalités principales

| Fonctionnalité | Description | État |
|---|---|---|
| Chronomètre | Démarrage, arrêt et remise à zéro | Disponible |
| Gestion des projets | Liste et ajout de projets | Disponible |
| Gestion des sessions | Association de sessions à un projet | Disponible / en évolution |
| Navigation | Navigation entre les pages principales | Disponible |
| Stockage | Données gérées par services applicatifs | Disponible |

## Architecture du projet

Le projet suit une organisation proche du modèle MVVM.
L’arborescence réelle du projet est la suivante :

```text
WorkTracker/
├── Dépendances/
├── Properties/
├── MonApp/
│   ├── Models/
│   │   ├── ViewModels/
│   │   ├── Project.cs
│   │   └── WorkSession.cs
│   ├── Services/
│   │   ├── ProjectService.cs
│   │   └── SessionService.cs
│   └── Views/
│       ├── AboutPage.xaml
│       ├── ChronoPage.xaml
│       ├── HomePage.xaml
│       ├── ProjectEditPage.xaml
│       ├── ProjectsPage.xaml
│       └── SessionsPage.xaml
├── Platforms/
├── Resources/
│   ├── AppIcon/
│   ├── Fonts/
│   ├── Images/
│   ├── Raw/
│   ├── Splash/
│   └── Styles/
├── .gitattributes
├── .gitignore
├── App.xaml
├── AppShell.xaml
├── MainPage.xaml
├── MauiProgram.cs
├── README.md
└── WorkTracker.csproj.Backup.tmp
```

## Rôle des dossiers et fichiers

| Élément | Rôle |
|---|---|
| `MonApp/Models` | Contient les modèles métiers comme `Project` et `WorkSession` |
| `MonApp/Models/ViewModels` | Contient la logique de présentation selon MVVM |
| `MonApp/Services` | Contient les services de gestion des données |
| `MonApp/Views` | Contient les interfaces XAML |
| `Resources` | Contient les ressources graphiques, polices, images et styles |
| `AppShell.xaml` | Définit la navigation principale |
| `MauiProgram.cs` | Configure l’application MAUI |
| `App.xaml` | Définit les ressources globales de l’application |
| `MainPage.xaml` | Page principale ou point d’entrée UI selon la configuration |

## Détail de l’architecture logique

### 1. Models
Les modèles représentent les données métiers manipulées par l’application.

Exemples :
- `Project.cs` : représente un projet ;
- `WorkSession.cs` : représente une session de travail.

Exemple de modèle :

```csharp
public class Project
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Color { get; set; } = "#005067";
    public string Initials => Name?.Length >= 2
        ? Name.Substring(0, 2).ToUpper()
        : "??";
}
```

### 2. ViewModels
Les ViewModels assurent la liaison entre les vues XAML et la logique applicative.
Ils gèrent les commandes, les propriétés observables et les traitements de l’interface.

Pseudo-code général MVVM :

```text
la vue affiche les données
le ViewModel expose les propriétés et commandes
le service fournit ou modifie les données
le modèle représente les objets métiers
```

### 3. Services
Les services centralisent la gestion des données.

Exemples :
- `ProjectService.cs` : gestion des projets ;
- `SessionService.cs` : gestion des sessions.

Pseudo-code simplifié :

```text
créer une collection en mémoire
ajouter un élément
supprimer un élément
retourner la liste à la vue ou au ViewModel
```

### 4. Views
Les vues XAML définissent l’interface utilisateur.

Pages présentes dans le projet :
- `HomePage.xaml`
- `ChronoPage.xaml`
- `ProjectsPage.xaml`
- `ProjectEditPage.xaml`
- `SessionsPage.xaml`
- `AboutPage.xaml`

## Navigation

La navigation principale s’appuie sur `AppShell.xaml`.
Elle permet d’organiser l’application en plusieurs sections accessibles simplement.

Pseudo-code de navigation :

```text
lancer l’application
charger AppShell
ouvrir une page principale
naviguer vers une autre page selon l’action utilisateur
```

## Technologies utilisées

| Technologie | Usage |
|---|---|
| .NET MAUI | Développement multiplateforme |
| C# | Logique métier et services |
| XAML | Construction des interfaces |
| MVVM Toolkit | Gestion des commandes et propriétés observables |
| Shell | Navigation dans l’application |

## Exemple de logique applicative

Exemple d’ajout de projet :

```csharp
[RelayCommand]
private async Task Save()
{
    if (string.IsNullOrWhiteSpace(Name))
    {
        await Shell.Current.DisplayAlert("Champ requis", "Le nom du projet ne peut pas être vide.", "OK");
        return;
    }

    var project = new Project
    {
        Name = Name.Trim(),
        Description = Description.Trim()
    };

    ProjectService.Instance.Add(project);
    await Shell.Current.GoToAsync("..");
}
```

## Lancer le projet

### Prérequis

| Outil | Besoin |
|---|---|
| Visual Studio | Développement et exécution MAUI |
| Workload .NET MAUI | Obligatoire |
| SDK .NET compatible | Obligatoire |

### Commandes de base

```bash
git clone https://github.com/hartz-guillaume-3il/WorkTracker.git
cd WorkTracker
```

Puis :
1. ouvrir la solution dans Visual Studio ;
2. restaurer les packages NuGet ;
3. choisir une plateforme cible ;
4. lancer l’exécution.

## Résumé architectural

| Couche | Contenu |
|---|---|
| Interface | `Views/*.xaml` |
| Présentation | `Models/ViewModels/*` |
| Métier | `Models/*.cs` |
| Services | `Services/*.cs` |
| Configuration | `App.xaml`, `AppShell.xaml`, `MauiProgram.cs` |
| Ressources | `Resources/*` |

## Conclusion

WorkTracker est organisé selon une architecture propre et progressive, adaptée à un projet pédagogique MAUI.
La structure du dépôt montre une séparation claire entre :
- les données métier ;
- la logique de présentation ;
- les services ;
- les vues ;
- la configuration globale de l’application.

Cette organisation facilite l’évolution future du projet, notamment pour enrichir la gestion des sessions, améliorer la persistance et renforcer la maintenabilité du code.
