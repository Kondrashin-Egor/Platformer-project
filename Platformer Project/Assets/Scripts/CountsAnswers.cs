using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountsAnswers : MonoBehaviour
{
    public GameObject buttonNext;
    public void InputMenu1(int value)
    {
        if (value != 0)
        {
            DropDownMenu.V1 = 1;
        }
        else
        {
            DropDownMenu.V1 = 0;
        }
        Debug.Log("V1 " + DropDownMenu.V1);
        Debug.Log("V2 " + DropDownMenu.V2);
        Debug.Log("V3 " + DropDownMenu.V3);
        
    }
    public void InputMenu2(int value)
    {
        if (value != 0)
        {
            DropDownMenu.V2 = 1;
        }
        else
        {
            DropDownMenu.V2 = 0;
        }
        Debug.Log("V1 " + DropDownMenu.V1);
        Debug.Log("V2 " + DropDownMenu.V2);
        Debug.Log("V3 " + DropDownMenu.V3);
        
    }
    public void InputMenu3(int value)
    {
        if (value != 0)
        {
            DropDownMenu.V3 = 1;
        }
        else
        {
            DropDownMenu.V3 = 0;
        }
        Debug.Log("V1 " + DropDownMenu.V1);
        Debug.Log("V2 " + DropDownMenu.V2);
        Debug.Log("V3 " + DropDownMenu.V3);
        
    }
    void Start()
    {
        DropDownMenu.V1 = 0;
        DropDownMenu.V2 = 0;
        DropDownMenu.V3 = 0;
        buttonNext.SetActive(false);
    }
    void Update()
    {
       if (DropDownMenu.V1 != 0 && DropDownMenu.V2 != 0 && DropDownMenu.V3 != 0)
        {
            buttonNext.SetActive(true);
        }
        else
        {
            buttonNext.SetActive(false);
        }
    }
}
