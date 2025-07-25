
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
public class GameInstaller : ProjectInstaller
{
    [SerializeField] private ShadedAppearEffect _appearEffect;
    [SerializeField] private ShadedDisappearEffect _disappearEffect;

    public SceneManagerLoader _levelManager { get; private set; }
    public IStorage Storage { get; private set; }
    public ShadedAppearEffect AppearEffect { get; private set; }
    public ShadedDisappearEffect DisappearEffect { get; private set; }
    public ISceneLoader SceneLoader { get; private set; }
    public override void InstallBindings()
    {
        Storage = new PlayerPrefsStorage();

        Canvas canvas = new GameObject("Canvas").AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.sortingOrder = 100;
        DontDestroyOnLoad(canvas);
        AppearEffect = Instantiate(_appearEffect,canvas.transform);
        DisappearEffect = Instantiate(_disappearEffect, canvas.transform);
        SceneManager.sceneLoaded += (_, __) => AppearEffect.Appear(() => AppearEffect.gameObject.SetActive(false));
        SceneManager.sceneUnloaded += (_) => DisappearEffect.gameObject.SetActive(false);

        SceneLoader = new AnimatedSceneLoader(
            new SceneManagerLoader()
            , DisappearEffect);


    }
}
