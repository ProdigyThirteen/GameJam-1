using System.Collections;
using UnityEngine;

public class CameraHijack : MonoBehaviour
{
    [SerializeField] private GameObject pawDoubleJump;
    [SerializeField] private GameObject camPanLocation;
    [SerializeField] private float camPanPauseTime = 3.0f;
    private GameObject _traps;
    
    
    // Private references
    private CameraController _cameraController;
    private GameObject _player;
    private Rigidbody2D _playerRb;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _camPanLocationRb;
    
    private void Start()
    {
        pawDoubleJump = GameObject.Find("Paw_DoubleJump");
        if (Camera.main != null) _cameraController = Camera.main.GetComponent<CameraController>();
        
        _player = GameObject.FindWithTag("Player");
        _playerRb = _player.GetComponent<Rigidbody2D>();
        _playerMovement = _player.GetComponent<PlayerMovement>();
        
        _camPanLocationRb = camPanLocation.GetComponent<Rigidbody2D>();
        
        _traps = GameObject.Find("PawTraps");
        
        // Disable the original trigger to overwrite it
        pawDoubleJump.GetComponent<Collider2D>().enabled = false;
        
        
        // Set up the trigger to hijack the camera
        transform.position = pawDoubleJump.transform.position;
        BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
        boxCollider2D.isTrigger = true;
        var localScale = pawDoubleJump.transform.localScale;
        boxCollider2D.size = new Vector2(localScale.x, localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        // Disable triggers
        GetComponent<BoxCollider2D>().enabled = false;
        _playerMovement.SetCanMove(false);
        
        // Hijack the camera
        _cameraController.SetTarget(camPanLocation, _camPanLocationRb);
        
        StartCoroutine(EnableTraps());
        StartCoroutine(RestoreCamera());
        StartCoroutine(EnableMovement());
        StartCoroutine(Destroy());
    }
    
    IEnumerator EnableTraps()
    {
        yield return new WaitForSeconds(camPanPauseTime);
        
        for(int i = 0; i < _traps.transform.childCount; i++)
        {
            _traps.transform.GetChild(i).gameObject.SetActive(true);
        }
        
        pawDoubleJump.GetComponent<MonkeyPawDoubleJump>().Collect();
    }
    
    IEnumerator RestoreCamera()
    {
        yield return new WaitForSeconds(camPanPauseTime + 2.0f);
        _cameraController.SetTarget(_player, _playerRb);
    }

    IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(camPanPauseTime + 2.0f);
        _playerMovement.SetCanMove(true);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(camPanPauseTime + 3.0f);
        Destroy(gameObject);
    }
}
