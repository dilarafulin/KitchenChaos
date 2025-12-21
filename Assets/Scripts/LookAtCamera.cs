using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    [SerializeField] private Mode mode;

    private void LateUpdate()
    {
        switch(mode)
        {
            case Mode.LookAt:
                transform.LookAt(Camera.main.transform); //this is really bad for performance because its gonna work everytime and
                                                         //search through all objects in the scene till its gonna find camera
                break;
            case Mode.LookAtInverted:
                //kamera bakis acisini ters cevirerek ornegin progress barin kullaniciya normal bir sekilde soldan saga dogru gozukmesini saglar
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;  //direction point from the camera
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraForward:
                //kameraya duz bir sekilde bakar. (orn progress barin kameranin konumu yanda oldugu icin capraz durmaz.)
                transform.forward = Camera.main.transform.forward;  
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
       
}
