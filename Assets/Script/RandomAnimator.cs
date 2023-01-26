using UnityEngine;

public class RandomAnimator : MonoBehaviour
{
    public Animator animator;
    public string[] animationNames;

    void Start()
    {
        int randomIndex = Random.Range(0, animationNames.Length);
        animator.Play(animationNames[randomIndex]);    }

}
