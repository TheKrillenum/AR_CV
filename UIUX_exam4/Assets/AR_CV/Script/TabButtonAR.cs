using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabButtonAR : MonoBehaviour
{
    public TabGroup tabGroup;
    public Image textCV;
    public Vector3 basePosition;
    public bool available = false;
    public AudioSource audioSource;
    public AudioClip pressButton;

    private void Start()
    {
        basePosition = gameObject.transform.position;
        gameObject.SetActive(false);
    }

    public void SetAvailable()
    {
        gameObject.SetActive(true);
        available = true;
    }
    public void VisibilityOn()
    {
        if (tabGroup.bExposed == true && available)
        {
            tabGroup.HideAllText();
            tabGroup.SetButtonEnabled(true);
            Vector3 temp = new Vector3(75, transform.position.y, transform.position.z);
            transform.SetPositionAndRotation(temp, transform.rotation);
            textCV.enabled = true;
            textCV.GetComponentInChildren<TMP_Text>().enabled = true;
            foreach (Image img in textCV.GetComponentsInChildren<Image>())
            {
                img.enabled = true;
            }

            audioSource.clip = pressButton;
            audioSource.Play();
        }
    }

    public void VisibilityOff()
    {
        textCV.enabled = false;
        textCV.GetComponentInChildren<TMP_Text>().enabled = false;
        foreach (Image img in textCV.GetComponentsInChildren<Image>())
        {
            img.enabled = false;
        }
    }
}