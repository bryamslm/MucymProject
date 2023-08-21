using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmControl : MonoBehaviour
{

    public GameObject firstSection;
    public Slider sliderFirstSection; // Arrastra el Slider aquí desde el Inspector

    public GameObject secondSection;
    public Slider sliderSecondSection; // Arrastra el Slider aquí desde el Inspector

    public GameObject thirdSection;
    public Slider sliderThirdSection; // Arrastra el Slider aquí desde el Inspector

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveFirstSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderFirstSection.value, -90f, 90f);
        Debug.Log("Normalized Slider value: " + normalizedRotation);
        firstSection.transform.localRotation = Quaternion.Euler(0f, normalizedRotation, 0f);
    }

    public void moveSecondSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderSecondSection.value, -115f, -40f);
        Debug.Log("Normalized Slider value: " + normalizedRotation);
        secondSection.transform.localRotation = Quaternion.Euler(normalizedRotation, 0f, 0f);
    }

    public void moveThirdSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderThirdSection.value, -50f, 13f);
        Debug.Log("Normalized Slider value: " + normalizedRotation);
        thirdSection.transform.localRotation = Quaternion.Euler(normalizedRotation, 0f, 0f);
    }
}
