using UnityEngine;
using UnityEngine.UI;

public class ShowMenuButton : MonoBehaviour
{
    public GameObject Menu;

    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(ShowMenu);
    }

    public void ShowMenu()
    {
        if (Demo.instance.currentMenu != null)
            Demo.instance.currentMenu.SetActive(false);
        Menu.SetActive(true);
        Demo.instance.currentMenu = Menu;
    }
}
