using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiDisk : MonoBehaviour
{
    public int size;

    public ConditionCheck cc;

    public HanoiGameManager gameManager;

    private Rigidbody rb;

    private bool gravity;

    private Vector3 _originalPosition;
    private Vector3 _currentPosition;


    void Start()
    {
        gravity = false;
        rb = GetComponent<Rigidbody>();
        _currentPosition = transform.localPosition;
        _originalPosition = transform.localPosition;
        //_gameManager = GameObject.Find("GameManager").GetComponent<HanoiGameManager>();
    }

    private void Update()
    {
        if (gravity)
        {
            if (!cc.CheckHit() && transform.localPosition.y > 0.791)
            {
                transform.Translate(Vector3.down * 1.7f * Time.deltaTime);
            }
            else
                gravity = false;
        }
    }

    private void OnMouseDrag()
    {
        gameManager.StartTimer();
        gravity = false;

        if (cc.CheckUp()) //Condition: Be the first disk in the pillar
        {
            //rb.isKinematic = true;
            //Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

            // ESTO SI SIRVE---------------------------------------------------------------------------------------------------------------------
            //if (transform.localPosition.y > 1.78f)
            //{
            //    Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //    objPosition.y = 0;
            //    objPosition.z = 0;

            //    transform.Translate(objPosition * 0.7f * Time.deltaTime);
            //}
            //------------------------------------------------------------------------------------------------------------------------------------
            rb.isKinematic = true;
            if (transform.localPosition.y > 1.78f)
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);

                Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                //objPosition.z = z;
                Vector3 direction = new Vector3(objPosition.x, 1.79f, 0.024f);

                //transform.localPosition = transform.TransformDirection(direction);
                transform.localPosition = new Vector3(transform.TransformDirection(direction).x *2f, 1.79f, 0.024f);
            }
            //Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            ////Vector3 objPosition = new Vector3(Input.mousePosition.x, 1.68f, currentX);
            //objPosition.z = originalZ;
            //objPosition.y = 1.4f;

            //if (transform.position.y < 1.39)
            //    objPosition.x = currentX;
            //else
            //    currentX = transform.localPosition.x;

            //transform.position = objPosition;

            //Vector3 A = new Vector3(transform.position.x, 1.73f, originalZ);
            //transform.position = A;
            if (transform.localPosition.y < 1.79f)
                transform.Translate(Vector3.up * 2f * Time.deltaTime);
        }
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
        gravity = true;
        gameManager.AddMovement();
        StartCoroutine(CheckCondition()); //Finished movement, let the piece go down, now check if movement was legal
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Disk") //
        {
            rb.velocity = Vector3.zero;
            gravity = false;
        }
    }

    IEnumerator CheckCondition() //Method to know if the last move made is legal and ok, if not, return piece to last current position
    {
        yield return new WaitForSeconds(1f);
        if (!cc.CheckCondition(this.size)) //Condition breaked, ilegal movement
        {
            Debug.Log("Check1");

            //Debug.Log("Asi no bro >:C");
            transform.localPosition = _currentPosition; //Go back to last current position
            gameManager.RemoveMovement();
        }
        else
        {
            if(transform.localPosition.y < 1.7f)
            {
                Debug.Log("Check2");

                //Debug.Log("Todo en orden");
                _currentPosition = transform.localPosition;
                gameManager.CheckIfWin();
            }
            else
            {
                Debug.Log("Check3");

                //Debug.Log("Asi no bro x2 >:C");
                transform.localPosition = _currentPosition; //Go back to last current position
                gameManager.RemoveMovement();
            }
        }
    }

    public void ResetPosition()
    {
        transform.localPosition = _originalPosition;
    }

}
