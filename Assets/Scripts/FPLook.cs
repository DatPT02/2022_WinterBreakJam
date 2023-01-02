using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPLook : MonoBehaviour
{

    [Header("Look Handle")]
    [SerializeField] private float mouseSensitivity = 100f;

    [SerializeField] private Transform playerBody;

    [Header("Interaction")]
    [SerializeField] private float interactionDistance;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Light flashLight;
    private Interactable currentInteractable;
    private Transform cameraTransform;
    private GameManager myGameManager;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private bool lookEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;

        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myGameManager.IsPaused)
            return;
        
        if(lookEnabled)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerBody.Rotate(Vector3.up * mouseX);

            HandleInteraction();
            HandleFlashLight();
        }
    }

    void HandleInteraction()
    {
        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactionDistance, interactionLayer))
        {
            if(currentInteractable == null )
            {
                hit.collider.TryGetComponent(out currentInteractable);

                if(currentInteractable != null)
                {
                    currentInteractable.onFocus();
                    myGameManager.updateNarration(currentInteractable.description);
                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.onInteract();
                }
            }
        }
        else if (currentInteractable != null)
        {
            currentInteractable.onLoseFocus();
            currentInteractable = null;
        }
    }

    void HandleFlashLight()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = ! flashLight.isActiveAndEnabled;
        }
    }

    public bool LookEnabled
    {
        get
        {
            return lookEnabled;
        }

        set
        {
            lookEnabled = value;
        }
    }
}
