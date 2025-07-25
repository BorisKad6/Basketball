using System;
using UnityEngine;

public class ShadedAppearEffect : ShaderAnimation,  ISceneAppearEffect
{
    public void Appear(Action onComplete)
    {
        Play(onComplete);
    }
}
public interface ISceneAppearEffect
{
    public void Appear(Action onComplete);
}