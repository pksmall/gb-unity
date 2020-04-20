using UnityEngine;
using UnityEngine.UI;


public class MyHealthBar : MonoBehaviour
{
    #region Fields
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    #endregion

    #region Methods
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    #endregion
}
