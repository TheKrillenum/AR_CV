using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButtonAR> tabButtons;
    public bool bExposed;
    public AudioSource audioSource;
    public AudioClip tabOnOff;


    

    public Button XO;
    public TMP_Text X;
    public TMP_Text O;

    void Start()
    {
        HideAllText();
        X.enabled = false;
        bExposed = false;
        XO.enabled = false;
        XO.gameObject.SetActive(false);
    }

    public void HideAllText()
    {
        foreach (TabButtonAR button in tabButtons)
        {
            button.VisibilityOff();
        }
    }

    public void SetButtonEnabled(bool b)
    {
        foreach (TabButtonAR button in tabButtons)
        {
            button.enabled = b;
            if (b)
            {
                Vector3 temp = new Vector3(25, button.transform.position.y, button.transform.position.z);
                button.transform.SetPositionAndRotation(temp, transform.rotation);
                audioSource.clip = tabOnOff;
                audioSource.Play();
            }
            else
            {
                button.transform.SetPositionAndRotation(button.basePosition, transform.rotation);
                audioSource.clip = tabOnOff;
                audioSource.Play();
            }

        }
    }

    public void BarExposure()
    {
        if (bExposed)
        {
            bExposed = false;
            SetButtonEnabled(bExposed);
            HideAllText();
            O.enabled = true;
            X.enabled = false;
        }
        else
        {
            bExposed = true;
            SetButtonEnabled(bExposed);
            HideAllText();
            O.enabled = false;
            X.enabled = true;
        }
    }
}
