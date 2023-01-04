using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediasButtons : MonoBehaviour
{
    public void InstagramLink()
    {
        Application.OpenURL("https://www.instagram.com/dudubertol_");
    }

    public void TwitterLink()
    {
        Application.OpenURL("https://twitter.com/dudubertoldev");
    }

    public void ItchIoLink()
    {
        Application.OpenURL("http://dudubertoldev.itch.io");
    }

    public void GitHubLink()
    {
        Application.OpenURL("https://github.com/DuduBertol");
    }

    public void TwitchLink()
    {
        Application.OpenURL("https://twitch.tv/dudubertol_");
    }
}
