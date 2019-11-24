using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipUIController : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    Slider sheildShlider;
    [SerializeField]
    Slider StorageShlider;
    [SerializeField]
    Slider PowerShlider;

    [SerializeField]
    TextMeshProUGUI horSpeedText;
    [SerializeField]
    TextMeshProUGUI verSpeedText;

    [SerializeField]
    Image DirectionImage;

    [SerializeField]
    List<Sprite> SpeedArrowImages;
    // 0 is the mutual State
    // 1 up 2 down
    // 3 right 4 left
    // 5 up & right
    // 6 down & right
    // 7 down & left
    // 8 up & left

    public void setSliders(float Maxhealth, float MaxShield)
    {
        healthSlider.maxValue = Maxhealth;
        healthSlider.value = healthSlider.maxValue;
        sheildShlider.maxValue = MaxShield;
        sheildShlider.value = sheildShlider.maxValue;
    }

    public void setSpeed()
    {
        verSpeedText.text = "" + 0;
        horSpeedText.text = "" + 0;
        DirectionImage.sprite = SpeedArrowImages[0];
    }

    public void ChangeSlider(char Slider, float Value)
    {
        switch (Slider)
        {
            case 'H': healthSlider.value = Value;
                break;
            case 'S': sheildShlider.value = Value;
                break;
            case 'P': PowerShlider.value = Value;
                break;
            case 'M': StorageShlider.value = Value;
                break;
        }
    }

    public void ChangeSpeed(Vector2 moveVector)
    {
        moveVector.x = Mathf.Round(moveVector.x * 10f) / 10f;
        moveVector.y = Mathf.Round(moveVector.y * 10f) / 10f;

        int spriteIndex = 0;

        if (moveVector.x == 0 && moveVector.y == 0)
            spriteIndex = 0;
        else
        {
            if (moveVector.x == 0)
            {
                if (moveVector.y > 0)
                    spriteIndex = 1;
                else
                    spriteIndex = 2;
            }
            else
                if (moveVector.y == 0)
                {
                    if (moveVector.x > 0)
                        spriteIndex = 3;
                    else
                        spriteIndex = 4;
                }
                else
                {
                    if(moveVector.x > 0 && moveVector.y >0)
                        spriteIndex = 5;
                    if (moveVector.x > 0 && moveVector.y < 0)
                        spriteIndex = 6;
                    if (moveVector.x < 0 && moveVector.y < 0)
                        spriteIndex = 7;
                    if (moveVector.x < 0 && moveVector.y > 0)
                        spriteIndex = 8;
                }

        }


        DirectionImage.sprite = SpeedArrowImages[spriteIndex];
        horSpeedText.text = "" + Mathf.Abs(moveVector.x);
        verSpeedText.text = "" + Mathf.Abs(moveVector.y);
    }

}
