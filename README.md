# Strangeman.SceneHelper
[![GitHub package.json version]][ReleasesLink] [![ChangelogBadge]](CHANGELOG.md) [![InstallationBadge]](#installation) [![WikiBadge]][WikiLink]

This package provides a data-first Unity Scene loading & transition management solution for Unity.

The package will be updated as I implement new features and fix issues, and create new examples.

Feel free to create your own projects using this as a resource. While it is not required to state that a product / project is using this solution, I would like to shout-out those that do.

## Planned Features
- Create prefabs: Create prefabs for the TimedSceneTransition and LogoLoading load:transition example.
- Mecanim Expansion: Load scenes dynamically from animation states following the load:transition system design.
- Example Scenes: Example scenes with loading and transition visuals.

## Dependency
[![UtilsBadge]][UtilsLink]

## Installation
Option 1: Add to Unity from Package Manager:

Step 1.
```
https://github.com/miclede/Strangeman.Utils.git
```
Step 2.
```
https://github.com/miclede/Strangeman.SceneHelper.git
```

Option 2: from manifest.json:
```
"com.strangemangames.utils": "https://github.com/miclede/Strangeman.Utils.git",
"com.strangemangames.scenehelper": "https://github.com/miclede/Strangeman.SceneHelper.git"
```

Option 3: .unitypackage from releases:
```
https://github.com/miclede/Strangeman.SceneHelper/releases
```

<!------>
[ChangelogBadge]: https://img.shields.io/badge/Changelog-light
[GitHub package.json version]: https://img.shields.io/github/package-json/v/miclede/Strangeman.SceneHelper

[InstallationBadge]: https://img.shields.io/badge/Installation-red
[WikiBadge]: https://img.shields.io/badge/Documentation-purple
[UtilsBadge]: https://img.shields.io/badge/Strangeman.Utils-darkred

[ReleasesLink]: https://github.com/miclede/Strangeman.SceneHelper/releases/latest
[WikiLink]: https://github.com/miclede/Strangeman.SceneHelper/wiki
[UtilsLink]: https://github.com/miclede/Strangeman.Utils