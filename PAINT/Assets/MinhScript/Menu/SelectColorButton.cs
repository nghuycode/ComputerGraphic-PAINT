using UnityEngine;
using UnityEngine.UI;
public class SelectColorButton : SelectButton
{
    public Color color;
    private void Awake()
    {
        base.Awake();
        this.GetComponent<Button>().onClick.AddListener(SetColor);
    }

    void SetColor()
    {
        Demo.instance.currentColor = color;
    }
}
