# Dependency Injection in Unity without DI Containers  

This is a small Unity project aimed at implementing a "pure" dependency injection approach (without DI containers).  

## Implementation  
The core of the technology is based on the **"Composition Root"** pattern, split into two components:  
- **`ProjectInstaller`** — A `ScriptableObject` responsible for resolving project-wide dependencies.  
- **`SceneInstaller<T>`** — An installer that handles dependencies for a specific scene.  
  - `T` inherits from `ProjectInstaller` and provides access to its dependencies via the `T GameContext` field.  

## Why This Approach?  
- No reliance on third-party DI frameworks.  
- Clear separation between global (project) and local (scene) dependencies.  
- Flexibility when working with multiple scenes.  
