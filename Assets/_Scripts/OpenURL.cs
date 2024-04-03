using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public void OpenWebsite(string url = "http://www.ecambiental.org.mx")
    {
        Application.OpenURL(url);
    }
}
