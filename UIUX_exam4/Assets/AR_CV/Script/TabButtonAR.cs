using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonAR : MonoBehaviour
{
    public TabGroup tabGroup;
    public Image textCV;
    public Vector3 basePosition;

    private void Start()
    {
        basePosition = gameObject.transform.position;
    }
    public void VisibilityOn()
    {
        if (tabGroup.bExposed == true)
        {
            tabGroup.HideAllText();
            textCV.enabled = true;
            textCV.GetComponentInChildren<TMP_Text>().enabled = true;
        }
    }

    public void VisibilityOff()
    {
        textCV.enabled = false;
        textCV.GetComponentInChildren<TMP_Text>().enabled = false;
    }
}