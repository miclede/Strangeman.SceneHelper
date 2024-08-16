## [1.0.0] - 2024-08-16
### First Release
- Contains core scene loading, configuration, and transition framework
- Contains two inheritence examples for creating custom loading and transition classes
- Scene Configuration -> has Loading Graphic and Transition prefabs and the scene associated with them
- Scene Loader -> async load of a scene, stored in a SceneField from a Scene Configuration
- Scene Loading Graphic -> handles the loading graphic as scenes are async loaded via the Scene Loader
- Scene Transition -> handles the transition out of the loading graphic and into the newly loaded scene