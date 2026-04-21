# WorkTracker

## Présentation

WorkTracker est une application .NET MAUI de suivi de projets et de sessions de travail.
Le projet propose une interface simple, organisée autour de plusieurs écrans accessibles depuis une navigation par onglets.

L’application permet actuellement de :
- consulter une liste de projets ;
- ajouter un nouveau projet ;
- utiliser un chronomètre ;
- afficher une page d’information « À propos ».

## Fonctionnalités principales

| Fonctionnalité | Description | État |
|---|---|---|
| Chronomètre | Démarrage, arrêt, remise à zéro d’un chrono | Disponible |
| Gestion des projets | Affichage d’une liste de projets en mémoire | Disponible |
| Ajout de projet | Création d’un projet avec nom et description | Disponible |
| Navigation Shell | Navigation par onglets entre les pages principales | Disponible |
| Persistance | Stockage en mémoire via un service singleton | En cours d’évolution |

## Architecture du projet

Le projet suit une organisation proche du modèle MVVM.

```text
WorkTracker/
├── AppShell.xaml
├── MonApp/
│   ├── Models/
│   │   └── Project.cs
│   ├── Services/
│   │   └── ProjectService.cs
│   ├── Models/ViewModels/
│   │   ├── ChronoViewModel.cs
│   │   ├── ProjectEditViewModel.cs
│   │   ├── HomeViewModel.cs
│   │   ├── AboutViewModel.cs
│   │   └── RelayCommand.cs
│   └── Views/
│       ├── ChronoPage.xaml
│       ├── ProjectsPage.xaml
│       ├── ProjectEditPage.xaml
│       ├── AboutPage.xaml
│       └── HomePage.xaml
```

## Composants importants

### 1. Navigation
La navigation principale repose sur `Shell` avec trois onglets visibles :
- `Chrono`
- `Projets`
- `À propos`

### 2. Modèle métier
Le modèle `Project` contient les informations suivantes :

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

### 3. Service de données
Le service `ProjectService` gère actuellement les projets en mémoire avec un singleton simple.
Cela permet de séparer la logique d’accès aux données de l’interface utilisateur.

Pseudo-code simplifié :

```text
initialiser la liste des projets
si ajout d’un projet
    générer un identifiant
    ajouter le projet à la collection
si suppression d’un projet
    retirer le projet de la collection
retourner la liste pour l’affichage
```

### 4. ViewModels
Le projet utilise `CommunityToolkit.Mvvm` pour simplifier les propriétés observables et les commandes.

Exemples :
- `ChronoViewModel` : logique du chronomètre ;
- `ProjectEditViewModel` : validation et sauvegarde d’un projet ;
- `AboutViewModel` et `HomeViewModel` : logique des pages d’information/accueil.

## Fonctionnement du chronomètre

Le chronomètre repose sur un `IDispatcherTimer` mis à jour chaque seconde.

Pseudo-code :

```text
au démarrage
    créer un timer de 1 seconde
à chaque tick
    incrémenter le temps écoulé
si bouton démarrer
    lancer le timer
si bouton arrêter
    arrêter le timer
si bouton reset
    remettre le temps à zéro
```

## Gestion des projets

La page `ProjectsPage` affiche les projets via un `CollectionView`.
Un bouton dans la barre d’outils permet d’ouvrir la page d’ajout.

Pseudo-code :

```text
quand la page apparaît
    charger les projets depuis ProjectService
quand l’utilisateur clique sur Ajouter
    naviguer vers la page d’édition
quand l’utilisateur sélectionne un projet
    naviguer vers la page de sessions associée
```

## Technologies utilisées

| Technologie | Rôle |
|---|---|
| .NET MAUI | Application multiplateforme |
| C# | Logique applicative |
| XAML | Interface utilisateur |
| CommunityToolkit.Mvvm | MVVM, propriétés observables et commandes |
| Shell | Navigation structurée |

## Lancer le projet en local

### Prérequis

| Outil | Version conseillée |
|---|---|
| Visual Studio 2022 ou plus récent | avec charge .NET MAUI |
| .NET SDK | compatible avec le projet |
| Émulateur Android / Windows | selon la cible testée |

### Étapes

```bash
git clone https://github.com/hartz-guillaume-3il/WorkTracker.git
cd WorkTracker
```

Ensuite :
1. ouvrir la solution dans Visual Studio ;
2. restaurer les dépendances NuGet ;
3. choisir une cible d’exécution ;
4. lancer l’application.

## Limites actuelles

| Point | Observation |
|---|---|
| Stockage des données | Les projets sont stockés uniquement en mémoire |
| Persistance | Pas encore de SQLite ou base distante intégrée |
| Sessions de travail | La navigation vers `SessionsPage` est prévue dans le code, mais dépend de l’implémentation associée |
| Documentation | README initial très minimal avant cette mise à jour |

## Évolutions possibles

- ajout d’une persistance SQLite ;
- gestion complète des sessions par projet ;
- statistiques de temps passé ;
- amélioration du design UI ;
- injection de dépendances au lieu d’un singleton manuel ;
- tests unitaires sur les services et ViewModels.

## Exemple de logique d’ajout de projet

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

## Résumé

WorkTracker constitue une base propre pour un projet pédagogique MAUI autour du suivi de projets et du temps de travail.
L’application met déjà en place :
- une navigation Shell ;
- une séparation entre vues, modèles, services et ViewModels ;
- un chronomètre fonctionnel ;
- un module simple de gestion de projets.

Le projet est donc bien adapté pour une montée en complexité progressive, notamment avec l’ajout de persistance et de fonctionnalités métiers supplémentaires.
