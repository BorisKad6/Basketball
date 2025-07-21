using UnityEngine;

public class InteractiveRatioCalculator
{
    public float Calculate(Vector2 standartAspect)
    {
        Camera cam = Camera.main;
        float currentRatio = cam.aspect;
        float standartRatio = standartAspect.x/standartAspect.y;
        float ratio = currentRatio / standartRatio;
        return ratio;
    }
}
