using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour
{
    public ClickBox clickBox;
    private static MoveCube activeCube;
    private Animator animator;
    private Vector2 currentPos;
    private Vector2 defaultPos;
    private float elapsedTime;
    private float targetHeight = 1.5f;
    private float moveDuration = 0.25f;

    private void Awake()
    {
        defaultPos = transform.position;
    }

    private void Update()
    {
        if (clickBox.isClicked)
        {
            if (activeCube != null && activeCube != this)
            {
                activeCube.MoveDown();
            }
            MoveUp();
            activeCube = this;
        }
    }

    private void MoveUp()
    {
        currentPos = transform.position;
        animator = GetComponent<Animator>();
        animator.Play("Smile");
        StartCoroutine(MoveCoroutine(currentPos, new Vector2(currentPos.x, currentPos.y + targetHeight)));
    }

    private void MoveDown()
    {
        currentPos = transform.position;
        animator = activeCube.GetComponent<Animator>();
        animator.Play("Default");
        StartCoroutine(MoveCoroutine(currentPos, defaultPos));
    }

    IEnumerator MoveCoroutine(Vector2 startPos, Vector2 targetPos)
    {
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector2.Lerp(startPos, targetPos, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}