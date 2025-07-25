using UnityEngine;

public abstract class SceneInstaller<T> : SceneInstaller where T : ProjectInstaller
{
    public T GameContext { get; private set; }
    public void Init(T context)
    {
        GameContext = context;
    }
    public override void Init()
    {
        if(Root.GetGameContext<T>(out T context))
        {
            GameContext = context;
        }
        else
        {
            throw new System.Exception("GameContext not found");
        }

    }
}
public abstract class SceneInstaller : MonoBehaviour
{
    public CompositionRoot Root { get; private set; }
    public void Init(CompositionRoot root)
    {
        Root = root;
        Init();
    }
    public abstract void Init();
    public abstract void InstallBindings();
}