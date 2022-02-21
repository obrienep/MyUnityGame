using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanInSequence : MonoBehaviour
{
    public GameObject Cam;
    public Animator anim;
    private AnimationClip clip;
    //private float clipTime;
    void Start()
    {
        
        StartCoroutine(TheSequence());

    }
            IEnumerator TheSequence() {
                yield return new WaitForSeconds(GetAnimationLength());
                Debug.Log("This has run!");
                Cam.SetActive (false);
                Destroy(GetComponent<CameraPanInSequence>());
        }
            public float GetAnimationLength() {
                float clipTime = 0;
                AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
                foreach(AnimationClip clip in clips) {
                    clipTime = clip.length;
                }
                return clipTime;
            }

            public float GetAnimationLength(Animator anim, AnimationClip clipp) {
                float clipTime = 0;
                AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
                foreach(AnimationClip clip in clips) {
                    clipTime = clip.length;
                }
                return clipTime;
            }

    // Update is called once per frame
    void Update()
    {
        
    }
}
