using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    private int _volume;
    private int _minVolume;
    private int _maxVolume;
    private float _volumeNormalizationCoef;
    private AudioSource _sirenAudioSource;
    private Coroutine _startSirenCorutine;
    private Coroutine _stopSirenCorutine;

    private void Start()
    {
        _sirenAudioSource = GetComponent<AudioSource>();
        _volume = _minVolume = 250;
        _maxVolume = 1000;
        _volumeNormalizationCoef = 0.001f;
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
        while (++_volume <= _maxVolume)
        {

            if (!_sirenAudioSource.isPlaying)
            {
                _sirenAudioSource.Play();
            }

            _sirenAudioSource.volume = _volume * _volumeNormalizationCoef;

            yield return null;
        }
    }

    private IEnumerator StopSirenCorutine()
    {
        while (--_volume >= _minVolume)
        {
            _sirenAudioSource.volume = _volume * _volumeNormalizationCoef;

            if (_sirenAudioSource.isPlaying && _volume == _minVolume)
            {
                _sirenAudioSource.Stop();
            }

            yield return null;
        }
    }
}
