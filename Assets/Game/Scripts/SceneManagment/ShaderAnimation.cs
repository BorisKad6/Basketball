using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShaderAnimation : MonoBehaviour
{
    [SerializeField] private string _fullnessKey;
    [SerializeField] private float _speed;
    private float _fullness;
    private Material _shader;
    private bool _isPlaying;
    private Action _onComplete;

    private void Start()
    {
        gameObject.SetActive(false);
        _shader = GetComponent<Image>().material;
        _shader.SetFloat(_fullnessKey, 0);
    }
    public void Update()
    {
        if (_isPlaying)
        {
            _fullness += Time.deltaTime * _speed;
            _shader.SetFloat(_fullnessKey, _fullness);
            if(_fullness >= 1)
            {
                
                _onComplete?.Invoke();
            }
        }
    }
    public void Play(Action OnComplete)
    {
        _fullness = 0;
        _onComplete = OnComplete;
        _isPlaying = true;
        gameObject.SetActive(true);
    }
}