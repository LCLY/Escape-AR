using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraView : MonoBehaviour
{  
    public GameObject ARCamera;
    public GameObject viewCamera1;    

    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    public GameObject floor6;
    public GameObject floor7;

    public Material floorMaterialDefault; //Mat_Tile01
    public Material floorMaterial1; //Indoor 03 PBS
    public Material floorMaterial2; //Indoor 10 PBS
    public Material floorMaterial3; //whiteblacktile

    public GameObject wall;
    public Material wallMaterialDefault; //Mat_wallime01_C
    public Material wallMaterial1; //wall01
    public Material wallMaterial2; //stone 8 PBS
    public Material wallMaterial3; //Indoor 09 PBS

    public GameObject ceiling;
    public Material ceilingMaterialDefault; //Mat_Wallime02
    public Material ceilingMaterial1; //wall03
    public Material ceilingMaterial2; //blocks
    public Material ceilingMaterial3; //wall18

    public GameObject keybase;
    public Material keybaseDefault; //base
    public Material keybase1; //wall10
    public Material keybase2; //Dark Red

    public GameObject screen;
    public Material screenDefault; //screen
    public Material screen1; //blue
    public Material screen2; //video

    public GameObject keypad;
    public Material keypadDefault; //darker
    public Material keypad1; //metal05
    public Material keypad2; //Orange

    public GameObject screw1;
    public GameObject screw2;
    public GameObject screw3;
    public GameObject screw4;
    public Material screwDefault; //bolt metal   
    public Material screwColor1; //shiny black
    public Material screwColor2; //yellow

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject key6;
    public GameObject key7;
    public GameObject key8;
    public GameObject key9;
    public GameObject key10;
    public GameObject key11;
    public GameObject key12;
    public Material keyDefault; //Pliers metal   
    public Material mat_keyColor1; //yellow
    public Material mat_keyColor2_a; //a
    public Material mat_keyColor2_b; //b
    public Material mat_keyColor2_c; //c
    public GameObject keypadLight; //for the keypad light when the camera is looking towards the keypad

    public GameObject chestObj;
    public Material mat_chestDefault; //chest 
    public Material mat_chestColor1; //Red chest
    public Material mat_chestColor2; //White chest
    public GameObject chestLight;
    public GameObject chestParentObj;
    Animation chestAnimation;
    AudioSource openChestSound;
    Animator chestAnimator;
    public bool chestOpened = false;

    Vector3 oriKeyPos;
    Quaternion oriKeyRotation;
    public GameObject keyLight1;
    public GameObject keyObj;
    public GameObject keyLight2;
  
    public GameObject thirdTableDrawer;
    public bool tableDrawerOpened = false;
    public GameObject tableObj; //to get the animator
    public GameObject tableLight;

    public bool handleDrawerOpened = false;
    public GameObject drawerObj;
    public GameObject drawerHandle2Parent;
    public GameObject drawerSpotlight;

    public GameObject phone;
    public GameObject rubiksCube;
    public GameObject rubiksCubeSolved;
    public GameObject xylophone;
    public GameObject metronome;
    public GameObject puzzle1Light;
    public GameObject puzzle2Light;

    public GameObject solvedMessagePanel;
    public GameObject solvedPanel1;
    public GameObject solvedPanel2;
    public bool inSolvedPanel1;
    public bool inSolvedPanel2;
    public GameObject solvedTextObj;
    Text solvedText;

    public GameObject slider1;
    public GameObject slider2;

    Animator openTable;
    AudioSource openSound;

    Animator openDrawer;
    AudioSource openDrawerSound;

    public GameObject cameraObj;
    CameraTransition cameraScript;
   
    private void Start()
    {       
        viewCamera1.SetActive(false);
        cameraScript = cameraObj.GetComponent<CameraTransition>();
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);      

        oriKeyPos = keyObj.transform.position;
        oriKeyRotation = keyObj.transform.rotation;     

        openTable = tableObj.GetComponent<Animator>();
        openSound = tableObj.GetComponent<AudioSource>();

        openDrawer = drawerObj.GetComponent<Animator>();
        openDrawerSound = tableObj.GetComponent<AudioSource>();

        chestAnimation = chestParentObj.GetComponent<Animation>();
        chestAnimator = chestParentObj.GetComponent<Animator>();
        openChestSound = chestParentObj.GetComponent<AudioSource>();

        solvedText = solvedTextObj.GetComponent<Text>();
        
        rubiksCube.SetActive(false);
        metronome.SetActive(false);

        cameraScript.currentView = cameraScript.views[0];
    }
    //THIS SCRIPT IS IN CUSTOMIZATION PANEL
    public void roomColorTheme1()
    {        
        //change floor
        floor1.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor2.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor3.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor4.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor5.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor6.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        floor7.GetComponent<MeshRenderer>().material = floorMaterialDefault;
        //change ceiling
        ceiling.GetComponent<MeshRenderer>().material = ceilingMaterialDefault;
        //change wall
        wall.GetComponent<MeshRenderer>().material = wallMaterialDefault;

        cameraScript.currentView = cameraScript.views[0];//look at first camera target
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 112, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);     
    }

    public void roomColorTheme2()
    {      
        //change floor
        floor1.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor2.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor3.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor4.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor5.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor6.GetComponent<MeshRenderer>().material = floorMaterial1;
        floor7.GetComponent<MeshRenderer>().material = floorMaterial1;
        //change ceiling
        ceiling.GetComponent<MeshRenderer>().material = ceilingMaterial1;
        //change wall
        wall.GetComponent<MeshRenderer>().material = ceilingMaterial1;

        cameraScript.currentView = cameraScript.views[0];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 112, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);     
    }
    
    public void roomColorTheme3()
    {       
        //change floor
        floor1.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor2.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor3.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor4.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor5.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor6.GetComponent<MeshRenderer>().material = floorMaterial2;
        floor7.GetComponent<MeshRenderer>().material = floorMaterial2;
        //change ceiling
        ceiling.GetComponent<MeshRenderer>().material = ceilingMaterial2;
        //change wall
        wall.GetComponent<MeshRenderer>().material = wallMaterial2;

        cameraScript.currentView = cameraScript.views[0];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 112, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);      
        tableLight.SetActive(false);
    }

    public void roomColorTheme4()
    {
        //change floor
        floor1.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor2.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor3.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor4.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor5.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor6.GetComponent<MeshRenderer>().material = floorMaterial3;
        floor7.GetComponent<MeshRenderer>().material = floorMaterial3;
        //change ceiling
        ceiling.GetComponent<MeshRenderer>().material = ceilingMaterial3;
        //change wall
        wall.GetComponent<MeshRenderer>().material = wallMaterial3;

        cameraScript.currentView = cameraScript.views[0];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 112, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);    
    }

    public void keyDefaultColor()
    {      
        //materials
        keybase.GetComponent<MeshRenderer>().material = keybaseDefault;
        keypad.GetComponent<MeshRenderer>().material = keypadDefault;
        screen.GetComponent<MeshRenderer>().material = screenDefault;
        screw1.GetComponent<MeshRenderer>().material = screwDefault;
        screw2.GetComponent<MeshRenderer>().material = screwDefault;
        screw3.GetComponent<MeshRenderer>().material = screwDefault;
        screw4.GetComponent<MeshRenderer>().material = screwDefault;
        key1.GetComponent<MeshRenderer>().material = keyDefault;
        key2.GetComponent<MeshRenderer>().material = keyDefault;
        key3.GetComponent<MeshRenderer>().material = keyDefault;
        key4.GetComponent<MeshRenderer>().material = keyDefault;
        key5.GetComponent<MeshRenderer>().material = keyDefault;
        key6.GetComponent<MeshRenderer>().material = keyDefault;
        key7.GetComponent<MeshRenderer>().material = keyDefault;
        key8.GetComponent<MeshRenderer>().material = keyDefault;
        key9.GetComponent<MeshRenderer>().material = keyDefault;
        key10.GetComponent<MeshRenderer>().material = keyDefault;
        key11.GetComponent<MeshRenderer>().material = keyDefault;
        key12.GetComponent<MeshRenderer>().material = keyDefault;

        cameraScript.currentView = cameraScript.views[1];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 65, 3f);
        keypadLight.SetActive(true);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);      
    }

    public void keyColor1()
    {      
        keybase.GetComponent<MeshRenderer>().material = keybase1;
        keypad.GetComponent<MeshRenderer>().material = keypad1;
        screen.GetComponent<MeshRenderer>().material = screen1;
        screw1.GetComponent<MeshRenderer>().material = screwColor1;
        screw2.GetComponent<MeshRenderer>().material = screwColor1;
        screw3.GetComponent<MeshRenderer>().material = screwColor1;
        screw4.GetComponent<MeshRenderer>().material = screwColor1;
        key1.GetComponent<MeshRenderer>().material = mat_keyColor2_a;
        key2.GetComponent<MeshRenderer>().material = mat_keyColor2_c;
        key3.GetComponent<MeshRenderer>().material = mat_keyColor2_b;
        key4.GetComponent<MeshRenderer>().material = mat_keyColor2_b;
        key5.GetComponent<MeshRenderer>().material = mat_keyColor2_a;
        key6.GetComponent<MeshRenderer>().material = mat_keyColor2_c;
        key7.GetComponent<MeshRenderer>().material = mat_keyColor2_c;
        key8.GetComponent<MeshRenderer>().material = mat_keyColor2_b;
        key9.GetComponent<MeshRenderer>().material = mat_keyColor2_a;
        key10.GetComponent<MeshRenderer>().material = mat_keyColor2_a;
        key11.GetComponent<MeshRenderer>().material = mat_keyColor2_c;
        key12.GetComponent<MeshRenderer>().material = mat_keyColor2_b;

        cameraScript.currentView = cameraScript.views[1];       
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 65, 3f);
        keypadLight.SetActive(true);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);       
    }

    public void keyColor2()
    {      
        keybase.GetComponent<MeshRenderer>().material = keybase2;
        keypad.GetComponent<MeshRenderer>().material = keypad2;
        screen.GetComponent<MeshRenderer>().material = screen2;
        screw1.GetComponent<MeshRenderer>().material = screwColor2;
        screw2.GetComponent<MeshRenderer>().material = screwColor2;
        screw3.GetComponent<MeshRenderer>().material = screwColor2;
        screw4.GetComponent<MeshRenderer>().material = screwColor2;
        key1.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key2.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key3.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key4.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key5.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key6.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key7.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key8.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key9.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key10.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key11.GetComponent<MeshRenderer>().material = mat_keyColor1;
        key12.GetComponent<MeshRenderer>().material = mat_keyColor1;

        cameraScript.currentView = cameraScript.views[1];       
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 65, 3f);
        keypadLight.SetActive(true);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);     
    }

    public void keyPasscode()
    {      
        cameraScript.currentView = cameraScript.views[1];       
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 65, 3f);
        keypadLight.SetActive(true);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);      
    }

    public void chestDefault()
    {      
        chestObj.GetComponent<SkinnedMeshRenderer>().material = mat_chestDefault; //material

        cameraScript.currentView = cameraScript.views[2];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);   
    }
    
    public void chestColor1()
    {      
        chestObj.GetComponent<SkinnedMeshRenderer>().material = mat_chestColor1;

        cameraScript.currentView = cameraScript.views[2];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);     
    }
    
    public void chestColor2()
    {      
        chestObj.GetComponent<SkinnedMeshRenderer>().material = mat_chestColor2;

        cameraScript.currentView = cameraScript.views[2];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);       
    }

    public void keyPosition1()
    {       
        keyObj.transform.position = oriKeyPos;
        keyObj.transform.rotation = oriKeyRotation; //restore to old rotation and position when go back to keyposition 1

        cameraScript.currentView = cameraScript.views[3];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 70, 3f);

        keyObj.transform.parent = null;//dont set parent

        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(true); //only turn on the light when look at key position 1
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);      
    }

    public void keyPosition2()
    {       
        cameraScript.currentView = cameraScript.views[4];              
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 110, 3f);
        keyObj.transform.parent = GameObject.Find("first_aid_box").transform;
        keyObj.transform.localPosition = new Vector3(-1.953f, 4.664f, -0.991f);
        keyObj.transform.rotation = Quaternion.Euler(90, 335, 0);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false); //only turn on the light when look at key position 1
        keyLight2.SetActive(true); //only turn on light when look at key position 2
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);      
    }

    public void keyPosition3()
    {
        cameraScript.currentView = cameraScript.views[5];       

        keyObj.transform.position = new Vector3(-1.4f, 0.91f, -0.8f);
        keyObj.transform.rotation = Quaternion.Euler(90,0, 64.98901f);

        keyObj.transform.parent = thirdTableDrawer.transform; //set the key object parent to the drawer

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 97, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false); //only turn on the light when look at key position 1
        keyLight2.SetActive(false); //only turn on light when look at key position 2
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(true);      
        tableDrawerOpened = true;
        openTable.SetTrigger("table3");
        openSound.Play();
    }

    public void keyPosition4()
    {
        cameraScript.currentView = cameraScript.views[6];    

        keyObj.transform.position = new Vector3(0.9f, 0.35f, -3.8f);
        keyObj.transform.rotation = Quaternion.Euler(90, 0, 0);

        keyObj.transform.parent = drawerHandle2Parent.transform; //set the key object parent to the drawer handle

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 97, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false); //only turn on the light when look at key position 1
        keyLight2.SetActive(false); //only turn on light when look at key position 2
        drawerSpotlight.SetActive(true);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);       
        tableLight.SetActive(false);
        handleDrawerOpened = true;
        openDrawer.SetTrigger("handle3");
        openDrawerSound.Play();
    }
    public void openChest()
    {
        chestAnimator.SetTrigger("openchest");
    }

    public void closeChest()
    {
        chestAnimator.SetTrigger("closechest");
    }

    public void chestItemDefault()
    {

        cameraScript.currentView = cameraScript.views[7];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 120, 3f);       
      
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);     
        if (chestOpened == false)
        {
            openChest();
            chestOpened = true;
            StartCoroutine(playOpenChestSound());
        }       
       
    }

    public void chestItem1()
    {
        cameraScript.currentView = cameraScript.views[7];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 120, 3f);      
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);
        puzzle2Light.SetActive(false);     
        tableLight.SetActive(false);
        if (chestOpened == false)
        {
            openChest();
            chestOpened = true;
            StartCoroutine(playOpenChestSound());
        }
    }

    public void chestItem2()
    {

        cameraScript.currentView = cameraScript.views[7];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 120, 3f);      
        keypadLight.SetActive(false);
        chestLight.SetActive(true);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle1Light.SetActive(false);       
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);
        if (chestOpened == false)
        {
            openChest();
            chestOpened = true;
            StartCoroutine(playOpenChestSound());
        }
    }

    IEnumerator playOpenChestSound()
    {
        yield return new WaitForSeconds(1.2f);
        openChestSound.Play();
    }

    public void puzzleDeco1()
    {
        cameraScript.currentView = cameraScript.views[8];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        puzzle2Light.SetActive(false);
        tableLight.SetActive(false);
        if (!puzzle1Light.activeInHierarchy)
        {
            puzzle1Light.SetActive(true);
        }
        phone.SetActive(true);
        rubiksCube.SetActive(false);
        if (rubiksCubeSolved.activeInHierarchy)
        {
            rubiksCubeSolved.SetActive(false);
        }
    }

    public void puzzleDeco2()
    {
        cameraScript.currentView = cameraScript.views[8];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        phone.SetActive(false);        
        tableLight.SetActive(false);
        if (!puzzle1Light.activeInHierarchy)
        {
            puzzle1Light.SetActive(true);
        }
        puzzle2Light.SetActive(false);
        rubiksCube.SetActive(true);
        if (rubiksCubeSolved.activeInHierarchy)
        {
            rubiksCubeSolved.SetActive(false);
        }
    }

    public void puzzleDeco3()
    {
        cameraScript.currentView = cameraScript.views[9];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        xylophone.SetActive(true);
        metronome.SetActive(false);
        tableLight.SetActive(false);
        puzzle1Light.SetActive(false);        
        if (!puzzle2Light.activeInHierarchy)
        {
            puzzle2Light.SetActive(true);
        }
    }

    public void puzzleDeco4()
    {
        cameraScript.currentView = cameraScript.views[9];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        xylophone.SetActive(false);
        metronome.SetActive(true);
        tableLight.SetActive(false);
        puzzle1Light.SetActive(false);       
        if (!puzzle2Light.activeInHierarchy)
        {
            puzzle2Light.SetActive(true);
        }
    }

    public void solvedMessage1()
    {      
        cameraScript.currentView = cameraScript.views[10];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        solvedPanel1.SetActive(true);
        tableLight.SetActive(false);
        slider1.SetActive(true);
        slider2.SetActive(false);
        if (solvedPanel2.activeInHierarchy)
        {
            solvedPanel2.SetActive(false);
        }
        if (!solvedMessagePanel.activeInHierarchy)
        {
            solvedMessagePanel.SetActive(true);           
        }
        inSolvedPanel1 = true;
    }


    public void solvedMessage2()
    {
      
        cameraScript.currentView = cameraScript.views[11];
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 100, 3f);
        keypadLight.SetActive(false);
        chestLight.SetActive(false);
        keyLight1.SetActive(false);
        keyLight2.SetActive(false);
        drawerSpotlight.SetActive(false);
        tableLight.SetActive(false);
        solvedPanel2.SetActive(true);
        slider1.SetActive(false);
        slider2.SetActive(true);
        if (solvedPanel1.activeInHierarchy)
        {
            solvedPanel1.SetActive(false);
        }
        //if the solved panel is inactive set it to active
        if (!solvedMessagePanel.activeInHierarchy)
        {
            solvedMessagePanel.SetActive(true);
            
        }
        inSolvedPanel2 = true;
    }
}
