using UnityEngine;

public class BoxController : MonoBehaviour
{
    public ClickBox[] boxes;
    private ClickBox chosenBox;

    void Update()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].isClicked)
            {
                boxes[i].LockClick = true;
                if (chosenBox == null)
                {
                    chosenBox = boxes[i];
                }
                else
                {
                    if (chosenBox != boxes[i])
                    {
                        chosenBox.LockClick = false;
                        chosenBox = boxes[i];
                    }
                } 
            }
        }
    }
}
