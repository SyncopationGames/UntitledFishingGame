using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject helpPanel;
    public int slideTime;
    bool slide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slide)
        {
            StartCoroutine(slideUpUI(helpPanel, slideTime));
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

    IEnumerator slideUpUI(GameObject slidingUI, int time)
    {
        float i = 0;
        float rate = .7f / time;

        Vector3 toPos = new Vector3(0, 0, 0);
        Vector3 fromPos = new Vector3(0, -600, 0);
        while (i < 1)
        {
            i += Time.deltaTime * rate;
            slidingUI.transform.localPosition = Vector3.Lerp(fromPos, toPos, i);
            yield return 0;
        }
        slide = false;
    }
}
