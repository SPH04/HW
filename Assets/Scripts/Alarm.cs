using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _fadingSpeed;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeIn()
    {
        if (!_audioSource.isPlaying)
            _audioSource.Play();
        while (_audioSource.volume < 1)
        {
            _audioSource.volume += _fadingSpeed * Time.deltaTime;
            yield return null;
        }
        _audioSource.volume = 1;
    }
    private IEnumerator FadeOut()
    {
        while (_audioSource.volume > 0.01)
        {
            _audioSource.volume -= _fadingSpeed * Time.deltaTime;
            yield return null;
        }
        _audioSource.volume = 0;
        _audioSource.Stop();
    }
}
