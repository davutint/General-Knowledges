using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject BaslangicEfekt;

    

    public GameObject ıpucuobj;

    public GameObject IpUcuObjPanel;

   

    public Slider slider;

    public GameObject DogruCevapObjesi;

    public TextMeshProUGUI OyuncuIsmi;


    public ReklamManager reklamManager;

    private int ıpucuSayac;

    private int devamettin;

    public TextMeshProUGUI ıpucuSayacText;
    public TextMeshProUGUI devamEttinText;

    public GameObject IstatisticPaneli;
    void Start()
    {
        ıpucuSayac = 0;
        devamettin = 0;
        OyuncuIsmi.text=PlayerPrefs.GetString("kullanıcı");
        Instance = this;

        BaslangicEfekt.GetComponent<Image>().DOFade(0, 1f);
        
        
    }

   

    


    public void IpUcunuGoster()// bu da ödüllü bir reklam ip ucunu görmek için kullanıcı bunu seçmeli.
    {
        reklamManager.OdulluReklamgoster();
        
        if (!IpUcuObjPanel.activeSelf)
            IpUcuObjPanel.SetActive(true);
        IpUcuObjPanel.transform.DOLocalMove(new Vector3(0, 0, 0), .7f);

        ıpucuSayac += 1;
        /*f (!IpUcuObjPanel.activeSelf)
        {
            IpUcuObjPanel.SetActive(true);
        }
        else
            IpUcuObjPanel.SetActive(false);*/

    }

    public void DogruyuGoster()
    {

        DogruCevapObjesi.transform.DOLocalMove(new Vector3(0, 0, 0), .7f);
    }

    public void ReklamİzleyipDevamEt()// ödüllü reklam izlendikten sonra bu fonksiyon çalışıcak. 
    {
        reklamManager.OdulluReklamgoster();

        devamettin += 1;
        DogruCevapObjesi.transform.DOLocalMove(new Vector3(0, 3800f, 0), .7f);
    }

    public void YenidenBasla()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Istatistik()
    {
        devamEttinText.SetText("You have continued " + devamettin + " times to pass the level.");
        ıpucuSayacText.SetText("You also saw " + ıpucuSayac + " clues.");
    }

    public void OyunSonuPaneli()
    {
        Istatistik();
        IstatisticPaneli.transform.DOLocalMove(new Vector3(0, 0, 0), .7f);
    }

    public void SonrakiBolum()
    {
        BaslangicEfekt.GetComponent<Image>().DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(2);
        });
    }

}
