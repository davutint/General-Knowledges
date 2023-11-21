using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class gamemanager2 : MonoBehaviour
{
    public static gamemanager2 Instance;

    public GameObject BaslangicEfekt;



    public GameObject ıpucuobj;

    public GameObject IpUcuObjPanel;



    public Slider slider;

    public GameObject DogruCevapObjesi;

    public TextMeshProUGUI OyuncuIsmi;


    public ReklamManager reklamManager;

    
    void Start()
    {

        OyuncuIsmi.text = PlayerPrefs.GetString("kullanıcı");
        Instance = this;

        BaslangicEfekt.GetComponent<Image>().DOFade(0, 1f);


    }






    public void IpUcunuGoster()// bu da ödüllü bir reklam ip ucunu görmek için kullanıcı bunu seçmeli.
    {
        reklamManager.OdulluReklamgoster();

        if (!IpUcuObjPanel.activeSelf)
            IpUcuObjPanel.SetActive(true);
        IpUcuObjPanel.transform.DOLocalMove(new Vector3(0, 0, 0), .7f);


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

    
}
