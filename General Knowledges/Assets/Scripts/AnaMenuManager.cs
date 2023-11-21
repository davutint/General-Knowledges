using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class AnaMenuManager : MonoBehaviour
{
    public GameObject girisPaneli;

    public TMP_InputField kullanıcıadı;

    public int kaydoldu = 0;

    public GameObject Panel;

    public AudioClip tusclip;
    public AudioSource tussource;
    private void Awake()
    {
        kaydoldu = PlayerPrefs.GetInt(nameof(kaydoldu));
        if (kaydoldu == 0)
        {
            girisPaneli.SetActive(true);
        }
        else
            girisPaneli.SetActive(false);
        
    }
    private void Start()
    {
        Debug.Log(kaydoldu);
    }



    public void StartGame()
    {
        tussource.PlayOneShot(tusclip);
        Panel.GetComponent<Image>().DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
        });
       
    }



    public void QuitGame()
    {
        Application.Quit();
    }

   public void KullaniciyiKaydet()
    {
        string kullanıcı = kullanıcıadı.text;
        PlayerPrefs.SetString("kullanıcı",kullanıcı);
        PlayerPrefs.SetInt(nameof(kaydoldu), 1);

        girisPaneli.transform.DOLocalMove(new Vector3(2500, -337, 0),1);
        Debug.Log(kaydoldu);
       
    }


    public void TurkceBaslat()
    {
        tussource.PlayOneShot(tusclip);
        Panel.GetComponent<Image>().DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(3);
        });
    }

}
