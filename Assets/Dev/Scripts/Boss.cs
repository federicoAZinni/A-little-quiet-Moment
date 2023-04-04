using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator anim; //bossAnim
    SpriteRenderer spriteRender;

    public void GameStart()
    {
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        AnimBoss();
    }

    void AnimBoss()
    {
        spriteRender.enabled = true;
        anim.Play("bossAnim");
        LeanTween.delayedCall(3, ()=> { spriteRender.flipX = true;
            LeanTween.delayedCall(1, _ => anim.Play("bossAnim2"));
            LeanTween.delayedCall(1.3f, ()=> { spriteRender.enabled = false; spriteRender.flipX = false; });
        });
        LeanTween.delayedCall(Random.Range(15, 50), AnimBoss);
    }
}
