using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Phone
    public GameObject PhonePanel;
    public GameObject PhoneBackground;
    public GameObject ShowPhoneButton;
    public GameObject HidePhoneButton;
    float move, alpha;
    float PhoneMinimum = -1000;
    float PhoneMaximum = -1000;
    float PanelMinimum = 0.0F;
    float PanelMaximum = 0.0F;

    // starting value for the Lerp
    static float t1 = 0.0f;
    static float t2 = 0.0f;

    //Desktop
    public GameObject DesktopPanel;
    public GameObject DesktopBackground;

    float move2, alpha2;
    float DesktopMinimum = -1100;
    float DesktopMaximum = -1100;
    float PanelMinimum2 = 0.0F;
    float PanelMaximum2 = 0.0F;

    static float t3 = 0.0f;
    static float t4 = 0.0f;

    bool onDisplay;
    bool atDesk;
    bool bootActive;
    float timer;

    public GameObject BootImage;
    public GameObject HomeScreen;
    public GameObject ShutdownMenu;
    public GameObject VascanScreen;

    // Start is called before the first frame update
    void Start()
    {
        StartPhone();
        StartDesktop();
    }

    // Update is called once per frame
    void Update()
    {
        //Phone
        MovePhone();
        PhoneKeyControl();

        //Desktop
        MoveDesktop();
        DesktopKeyControl();
        OperateSystem();

        //Update all translations
        Draw();
    }

    void Draw()
    {
        //Phone
        PhoneBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, move);
        PhonePanel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha);
        //Desktop
        DesktopBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, move2);
        DesktopPanel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha2);
    }

    void StartPhone()
    {
        move = -1000;
        alpha = 0;
        onDisplay = false;
        PhoneBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, move);
        PhonePanel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha);
    }

    public void DisplayPhone()
    {
        PhoneMinimum = -1000;
        PhoneMaximum = 0;
        PanelMinimum = 0;
        PanelMaximum = 80;
        t1 = 0.0f;
        t2 = 0.0f;
        onDisplay = true;
        ShowPhoneButton.SetActive(false);
        HidePhoneButton.SetActive(true);
    }

    public void HidePhone()
    {
        PhoneMinimum = 0;
        PhoneMaximum = -1000;
        PanelMinimum = 80;
        PanelMaximum = 0;
        t1 = 0.0f;
        t2 = 0.0f;
        onDisplay = false;
        HidePhoneButton.SetActive(false);
        ShowPhoneButton.SetActive(true);
    }

    void MovePhone()
    {
        //Animating movement of phone
        move = Mathf.SmoothStep(PhoneMinimum, PhoneMaximum, t1);
        
        t1 += 1.5f * Time.deltaTime;
    
        
        //Animating background fade
        alpha = Mathf.SmoothStep(PanelMinimum, PanelMaximum, t2);
        
        t2 += 1.5f * Time.deltaTime;
    }

//Keyboard inputs to open and close the phone
    void PhoneKeyControl()
    {
        if (Input.GetKeyUp(KeyCode.P) && !onDisplay) 
        {
           DisplayPhone();
        } 

        if (Input.GetKeyUp(KeyCode.Escape) && onDisplay) 
        {
           HidePhone();
        }
    }

    void StartDesktop()
    {
        move2 = -1100;
        alpha2 = 0;
        onDisplay = false;
        DesktopBackground.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, move2);
        DesktopPanel.GetComponent<Image>().color = new Color32(255, 255, 255, (byte)alpha2);
    }

    void MoveDesktop()
    {
        //Animating movement of phone
        move2 = Mathf.SmoothStep(DesktopMinimum, DesktopMaximum, t3);
        
        t3 += 1.5f * Time.deltaTime;
    
        
        //Animating background fade
        alpha2 = Mathf.SmoothStep(PanelMinimum2, PanelMaximum2, t4);
        
        t4 += 1.5f * Time.deltaTime;
    }

    public void DisplayDesktop()
    {
        DesktopMinimum = -1100;
        DesktopMaximum = 0;
        PanelMinimum2 = 0;
        PanelMaximum2 = 80;
        t3 = 0.0f;
        t4 = 0.0f;
        onDisplay = true;
        bootActive = true;
    }

    public void HideDesktop()
    {
        DesktopMinimum = 0;
        DesktopMaximum = -1100;
        PanelMinimum2 = 80;
        PanelMaximum2 = 0;
        t3 = 0.0f;
        t4 = 0.0f;
        onDisplay = false;
        bootActive = false;
        HomeScreen.SetActive(false);
        ShutdownMenu.SetActive(false);
    }

    //Called from DeskTrigger script with a boolean if the player is at the desk or not.
    public void DeskCheck(bool status)
    {
      atDesk = status;
    }

    void DesktopKeyControl()
    {
        if (Input.GetKeyUp(KeyCode.Return) && !onDisplay && atDesk)  //Allow the player to open the desktop if they are on / near the desk
        {
           //Hide phone button as it is the top layer and because of that still visible
           ShowPhoneButton.SetActive(false);
           //Display the desktop
           DisplayDesktop();
        }

        if (Input.GetKeyUp(KeyCode.Escape) && onDisplay) 
        {
           HideDesktop();
        }
    }

    //Amimated boot sequece
    void OperateSystem()
    {
        //Debug.Log(timer);
        if(bootActive)
        {
            timer += Time.deltaTime; 

            if (timer >= 1 && timer < 2)
            {
                BootImage.SetActive(true);
                LeanTween.alpha(BootImage.GetComponent<RectTransform>(), 1f, 1f);
            } else if (timer >= 3)
            {
                BootImage.SetActive(false);
                HomeScreen.SetActive(true);
            } else if (timer >= 5)
            {
                //End of current animation
            }
        } else
        {
            timer = 0;
        }
    }

    //Toggle shutdown menu on desktop
    public void ToggleMenu()
    {
        if(ShutdownMenu.activeSelf){
            ShutdownMenu.SetActive(false);
        } else
        {
            ShutdownMenu.SetActive(true);
        }
    }

    public void Vascan()
    {
        if(VascanScreen.activeSelf){
            VascanScreen.SetActive(false);
        } else
        {
            VascanScreen.SetActive(true);
        }
    }
}
