using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    private int _volume;
    private AudioSource _sirenAudioSource;
    private Coroutine _startSirenCorutine;
    private Coroutine _stopSirenCorutine;

    private void Start()
    {
        _sirenAudioSource = GetComponent<AudioSource>();
        _volume = 250;
    }

    public void StartSiren()
    {
        if (_stopSirenCorutine != null)
            StopCoroutine(_stopSirenCorutine);

        _startSirenCorutine = StartCoroutine(StartSirenCorutine());
    }

    public void StopSiren()
    {
        if (_startSirenCorutine != null)
            StopCoroutine(_startSirenCorutine);

        _stopSirenCorutine = StartCoroutine(StopSirenCorutine());
    }

    private IEnumerator StartSirenCorutine()
    {
        while (++_volume <= 1000)
        {

            if (!_sirenAudioSource.isPlaying)
            {
                _sirenAudioSource.Play();
            }

            _sirenAudioSource.volume = _volume * 0.001f;

            yield return null;
        }
    }

    private IEnumerator StopSirenCorutine()
    {
        while (--_volume >= 250)
        {
            _sirenAudioSource.volume = _volume * 0.001f;

            if (_sirenAudioSource.isPlaying && _volume == 250)
            {
                _sirenAudioSource.Stop();
            }

            yield return null;
        }
    }
}
