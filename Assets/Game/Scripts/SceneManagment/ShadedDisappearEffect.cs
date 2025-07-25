using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadedDisappearEffect : ShaderAnimation, ISceneDisappearEffect
{
    public void Disappear(Action OnComplete)
    {
        Play(OnComplete);
    }
}
public interface ISceneDisappearEffect
{
    public void Disappear(Action OnComplete);
}