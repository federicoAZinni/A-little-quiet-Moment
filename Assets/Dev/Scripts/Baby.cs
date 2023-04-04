using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    [SerializeField] GameObject[] bebeSprites;
    [SerializeField] GameObject babyuiImg;
    [SerializeField] AudioSource babyAudioSource;
    [SerializeField] AudioClip clipCry;
    [SerializeField] AudioClip clipSmile;
    BabyState actualState;

    public enum BabyState
    {
        Sleeping, Crying, Eating
    }
    public void GameStart()
    {
        BabyChangeState(BabyState.Sleeping);
        Invoke("RandomCrying", 13);
    }

    void RandomCrying()
    {
        LeanTween.delayedCall(Random.Range(20, 50), RandomCrying);
        babyAudioSource.PlayOneShot(clipCry);
        if (actualState != BabyState.Crying) { BabyChangeState(BabyState.Crying); babyuiImg.SetActive(true); }
    }

    public void BabyChangeState(BabyState state)
    {
        foreach (var item in bebeSprites)
        {
            item.SetActive(false);
        }
        bebeSprites[(int)state].SetActive(true);
        actualState = state;
        if (state == BabyState.Eating) { babyAudioSource.Stop(); babyAudioSource.PlayOneShot(clipSmile); LeanTween.delayedCall(3, _ => BabyChangeState(BabyState.Sleeping));  }
    }


}


