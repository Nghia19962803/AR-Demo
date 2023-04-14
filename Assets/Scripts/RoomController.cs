using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RoomController : MonoBehaviour
{
    //public ARRaycastManager raycastManager;
    //public Camera arCam;
    //private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //public GameObject prefab;
    [Header("Wall Materials")]
    public Material[] wallMaterials;

    [Header("Floor Materials")]
    public Material[] floorMaterials;

    [Header("Roof Materials")]
    public Material[] roofMaterials;

    [Header("Chair type")]
    public GameObject[] chairs;

    [Header("Bed type")]
    public GameObject[] beds;

    [Header("Table type")]
    public GameObject[] tables;

    [Header("Button")]
    public Button WallBtn;
    public Button FloorBtn;
    public Button RoofBtn;
    public Button ChairBtn;
    public Button TableBtn;
    public Button BedBtn;

    public Button NextBtn;
    public Button Previous;

    public Text NameOfObject;

    private string ObjectWannaChange;
    private Renderer wallRenderer;
    private Renderer floorRenderer;
    private Renderer roofRenderer;

    private int wallIndex;
    private int floorIndex;
    private int roofIndex;
    private int chairIndex;
    private int bedIndex;
    private int tableIndex;
    private void Awake()
    {
        wallRenderer = transform.GetChild(0).GetComponent<Renderer>();
        floorRenderer = transform.GetChild(1).GetComponent<Renderer>();
        roofRenderer = transform.GetChild(2).GetComponent<Renderer>();

        wallIndex = 0;
        floorIndex = 0;
        roofIndex = 0;

        chairIndex = 0;
        bedIndex = 0;
        tableIndex = 0;

        wallRenderer.sharedMaterial = wallMaterials[wallIndex];
        floorRenderer.sharedMaterial = floorMaterials[floorIndex];
        roofRenderer.sharedMaterial = roofMaterials[roofIndex];

        chairs[chairIndex].SetActive(true);
        beds[bedIndex].SetActive(true);
        tables[tableIndex].SetActive(true);
    }
    private void Start()
    {

        WallBtn.onClick.AddListener(() =>       //wall
        {
            ObjectWannaChange = "wall";
        }); 
        FloorBtn.onClick.AddListener(() =>      //floor
        {
            ObjectWannaChange = "floor";
        });
        RoofBtn.onClick.AddListener(() =>      //Roof
        {
            ObjectWannaChange = "roof";
        });
        //==============================================//
        //change merchandise button
        ChairBtn.onClick.AddListener(() =>      //chair
        {
            ObjectWannaChange = "chair";
        });
        TableBtn.onClick.AddListener(() =>      //table
        {
            ObjectWannaChange = "table";
        });

        BedBtn.onClick.AddListener(() =>        //bed
        {
            ObjectWannaChange = "bed";
        });

        // next and previous button
        NextBtn.onClick.AddListener(() =>   //NEXT
        {
            MainControl(true);
        }); 
        Previous.onClick.AddListener(() =>  //PREVIOUS
        {
            MainControl(false);
        });
    }
    public void MainControl(bool inscease)
    {
        switch (ObjectWannaChange)
        {
            case "wall":
                //ham thay wall
                ChangeWallMaterial(inscease);
                break;
            case "floor":
                ChangeFloorMaterial(inscease);
                break;
            case "roof":
                ChangeRoofMaterial(inscease);
                break;
            case "chair":
                ChangeChair(inscease);
                break;
            case "table":
                ChangeTable(inscease);
                break;
            case "bed":
                ChangeBed(inscease);
                break;
            default:
                // do nothing
                break;
        }
    }

    public void ChangeWallMaterial(bool inscease)   // change Wall
    {
        if(inscease) wallIndex++;
        else wallIndex--;

        if (wallIndex >= wallMaterials.Length) wallIndex = wallMaterials.Length - 1;
        if (wallIndex < 0) wallIndex = 0;

        wallRenderer.sharedMaterial = wallMaterials[wallIndex];
    }
    public void ChangeFloorMaterial(bool inscease)  // change Floor
    {
        if (inscease) floorIndex++;
        else floorIndex--;

        if (floorIndex >= floorMaterials.Length) floorIndex = floorMaterials.Length - 1;
        if (floorIndex < 0) floorIndex = 0;

        floorRenderer.sharedMaterial = floorMaterials[floorIndex];
    }
    public void ChangeRoofMaterial(bool inscease)   // change Roof
    {
        if (inscease) roofIndex++;
        else roofIndex--;

        if (roofIndex >= roofMaterials.Length) roofIndex = roofMaterials.Length - 1;
        if (roofIndex < 0) roofIndex = 0;

        roofRenderer.sharedMaterial = roofMaterials[roofIndex];
    }
    public void ChangeChair(bool inscease)      //change chair
    {
        chairs[chairIndex].SetActive(false);

        if (inscease) chairIndex++;
        else chairIndex--;

        if (chairIndex >= chairs.Length) chairIndex = chairs.Length - 1;
        if (chairIndex < 0) chairIndex = 0;

        chairs[chairIndex].SetActive(true);
    }
    public void ChangeBed(bool inscease)        //change bed
    {
        beds[bedIndex].SetActive(false);

        if (inscease) bedIndex++;
        else bedIndex--;

        if (bedIndex >= beds.Length) bedIndex = beds.Length - 1;
        if (bedIndex < 0) bedIndex = 0;

        beds[bedIndex].SetActive(true);
    }
    public void ChangeTable(bool inscease)      // change Table
    {
        tables[tableIndex].SetActive(false);

        if (inscease) tableIndex++;
        else tableIndex--;

        if (tableIndex >= tables.Length) tableIndex = tables.Length - 1;
        if (tableIndex < 0) tableIndex = 0;

        tables[tableIndex].SetActive(true);
    }
}
//Touch touch = Input.GetTouch(0);
//Ray ray = arCam.ScreenPointToRay(touch.position);
////if (raycastManager.Raycast(ray, hits, TrackableType.Planes))
//if (raycastManager.Raycast(ray, hits, TrackableType.AllTypes))
//{
//    Pose pose = hits[0].pose;
//    Instantiate(prefab, pose.position, pose.rotation);
//    distanceText.text = Vector3.Distance(arCam.transform.position, pose.position).ToString();
//}