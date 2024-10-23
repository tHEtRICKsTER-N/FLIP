using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class GameManager : MonoBehaviour
{
    #region obj
    public static GameManager obj;

    private void Awake()
    {
        obj = this;
    }
    #endregion

    public GameObject player;
    public GameObject spawner;
    public bool gameOver = false;
    public GameObject collectedEffect;

    Bloom _bloom;
    Volume _vol;


    private void Start()
    {
        Time.timeScale = 1;
        _vol = Camera.main.GetComponent<Volume>();
        _vol.profile.TryGet<Bloom>(out _bloom);
    }


    void Update()
    {
        if (gameOver)
        {
            UIM.obj.restartText.gameObject.SetActive(true);

            if(Time.timeScale > 0)
                Time.timeScale -= 0.25f * Time.deltaTime;

            spawner.GetComponent<Spawner>().shouldSpawn = false;
            var playerScipt = player.GetComponent<Player>();
            playerScipt.enabled = false;

            if (Camera.main.orthographicSize > 2.5f)
            {
                var cam = Camera.main;
                cam.transform.localPosition = 
                    new Vector3(Mathf.Lerp(cam.transform.localPosition.x, player.transform.localPosition.x,Time.deltaTime * 0.2f),
                    cam.transform.localPosition.y,
                    cam.transform.localPosition.z);
                cam.orthographicSize -= 0.5f * Time.deltaTime;
            }

            _bloom.intensity.value = Mathf.Lerp(15,2.5f,Time.deltaTime);


            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene(1);
        }
    }
}
