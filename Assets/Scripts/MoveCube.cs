using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public ClickBox clickBox;
    private static MoveCube activeCube;
    private Vector2 defaultPos;
    public float upDistance = 1.5f;

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
        transform.position = new Vector2(transform.position.x, defaultPos.y + upDistance);
    }

    private void MoveDown()
    {
        transform.position = defaultPos;
    }
}
