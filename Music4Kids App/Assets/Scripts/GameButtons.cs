using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AButton()
    {
        GameManager.instance.CheckNote("A");
    }

    public void BButton()
    {
        GameManager.instance.CheckNote("B");
    }

    public void CButton()
    {
        GameManager.instance.CheckNote("C");
    }

    public void DButton()
    {
        GameManager.instance.CheckNote("D");
    }

    public void EButton()
    {
        GameManager.instance.CheckNote("E");
    }

    public void FButton()
    {
        GameManager.instance.CheckNote("F");
    }

    public void GButton()
    {
        GameManager.instance.CheckNote("G");
    }
}
