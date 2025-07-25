using UnityEngine.SceneManagement;

internal class AnimatedSceneLoader : ISceneLoader
{
    private readonly ISceneLoader _loader;
    private readonly ISceneDisappearEffect _animation;
    public AnimatedSceneLoader(ISceneLoader loader, ISceneDisappearEffect transitionAnimation)
    {
        _animation = transitionAnimation;
        _loader = loader;
    }


    public void LoadScene(string name)
    {
        _animation.Disappear(()=>_loader.LoadScene(name));
    }
}