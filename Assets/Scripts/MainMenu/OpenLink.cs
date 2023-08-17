
using UnityEngine;
using System.Collections;

namespace Supyrb
{
    public class OpenLink : MonoBehaviour
    {

        public void OpenWebsite(string url)
        {
            Application.OpenURL(url);
        }
    }
}
