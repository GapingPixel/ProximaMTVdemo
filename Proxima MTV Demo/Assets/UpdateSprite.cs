using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{
    public Toggle toggleA;
    public Image toggleAImage;
    public Sprite trueA;
    public Sprite falseA;
    private bool isOn;

    private void Start()
    {
        toggleA.graphic = null;
    }

    public void Update() {
        
        
        if (toggleA.isOn == true) {
               toggleAImage.sprite = trueA;
        } else {
            toggleAImage.sprite = falseA;
        }

        //toggleAImage.sprite = isOn ? trueA : falseA;
        //isOn = !isOn;
    }
    /*
    public void CheckAnswer()
    {
        toggleAImage.sprite = isOn ? trueA : falseA;
        isOn = !isOn;
    }*/
}
