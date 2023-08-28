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

    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftGrapple;
    public GameObject rightGrapple;
    public Slider sliderFourthSection; // Arrastra el Slider aquí desde el Inspector

    public GameObject cubo;

    private bool fisrtTime = true;

    

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

        firstSection.transform.localRotation = Quaternion.Euler(0f, normalizedRotation, 0f);

        if(fisrtTime)
        {
            fisrtTime = false;
            //activar gravedad del cubo
            cubo.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void moveSecondSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderSecondSection.value, -115f, -40f);
       
        secondSection.transform.localRotation = Quaternion.Euler(normalizedRotation, 0f, 0f);
    }

    public void moveThirdSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderThirdSection.value, -50f, 13f);
     
        thirdSection.transform.localRotation = Quaternion.Euler(normalizedRotation, 0f, 0f);
    }

    public void moveFourthSection()
    {
        float normalizedRotation = Mathf.Clamp(sliderFourthSection.value, 61f, 125f);

        leftArm.transform.localRotation = Quaternion.Euler(0f, 0f, normalizedRotation);
        leftGrapple.transform.LookAt(rightGrapple.transform.position);
        rightArm.transform.localRotation = Quaternion.Euler(0f, -180f, normalizedRotation);
        rightGrapple.transform.LookAt(leftGrapple.transform.position);
    }
}
