using UnityEngine;

public class ClickBox : MonoBehaviour
{
    public bool isClicked = false;
    public bool lockClick = false;

    public bool LockClick
    {
        get { return lockClick; }
        set { lockClick = value; }
    }

    private void OnMouseDown()
    {
        if (!lockClick)
        {
            isClicked = true;
            Debug.Log("Kutuya týklandý.");
        }
    }

    private void OnMouseUp()
    {
        isClicked = false;
        Debug.Log("Kutuya týklanma kaldýrýldý.");
    }
}
