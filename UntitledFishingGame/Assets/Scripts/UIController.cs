using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject helpPanel;
    public int slideTime;
    bool slide;
    bool slideDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slide)
        {
            StartCoroutine(slideUpUI(helpPanel, slideTime, 1));
        } 
        
        if (slideDown)
        {
            StartCoroutine(slideUpUI(helpPanel, slideTime, -1));
        }
    }

    public void Open(string path)
    {
        SceneManager.LoadScene(path);
    }

    public void startSlide()
    {
        slide = true;
    }

    public void startSlideDown()
    {
        slideDown = true;
    }

    // dir is either 1 (up) or -1 (down)
    IEnumerator slideUpUI(GameObject slidingUI, int time, int dir)
    {
        float i = 0;
        float rate = .7f / time;

        // default up
        Vector3 toPos = new Vector3(0, 0, 0);
        Vector3 fromPos = new Vector3(0, -600, 0);

        // if going down
        if (dir == -1)
        {
            toPos = new Vector3(0, -600, 0);
            fromPos = new Vector3(0, 0, 0);
        }

        while (i < 1)
        {
            i += Time.deltaTime * rate;
            slidingUI.transform.localPosition = Vector3.Lerp(fromPos, toPos, i);
            yield return 0;
        }

        slide = false;
        slideDown = false;
    }
}
