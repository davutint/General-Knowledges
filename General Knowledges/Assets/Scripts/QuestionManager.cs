using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using GoogleMobileAds.Api;
using System;
public class QuestionManager : MonoBehaviour
{
    public GameManager gameManager;

    private int correctAnswerIndex;

    public Question[] questions;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] buttonTexts;

    public TextMeshProUGUI CevapAcıklamaText;


    public Button[] buttons;
    float ArttırılacakMiktar;
    private int currentQuestion = 0;

    public GameObject Sertifika;
    public GameObject AltinYildiz;
    public GameObject exitbutonu;

    public GameObject butonlar;
    public GameObject anapanel;
    //üstteki ikisini sallamak için referans aldım.

    public AudioSource DogruSes;
    public AudioClip dogrusesclip;

    public AudioSource YanlisSes;
    public AudioClip yanlısclip;

    public AudioSource BolumSonuSes;
    public AudioClip bolumsonusesclip;


    public ReklamManager reklamManager;

    void Start()
    {

        currentQuestion = 0;
        SetQuestion();
        Debug.Log(questions.Length);
        ArttırılacakMiktar = (float)1 / questions.Length;
        Debug.Log(ArttırılacakMiktar);
        
    }


    private void SetQuestion()
    {

        if (currentQuestion >= questions.Length)
        {
            currentQuestion = questions.Length - 1;
        }

        questionText.text = questions[currentQuestion].questionText;
        CevapAcıklamaText.text = questions[currentQuestion].CevanınAcıklaması;
        
        GameManager.Instance.ıpucuobj.GetComponent<Image>().sprite= questions[currentQuestion].ıpucu;

        for (int i = 0; i < buttonTexts.Length; i++)
        {
            buttonTexts[i].text = questions[currentQuestion].answers[i];
            buttons[i].image.color =Color.white ;
            //DogruTikleri[i].GetComponent<Image>().DOFade(0, .2f);

        }
        correctAnswerIndex = questions[currentQuestion].correctAnswerIndex;

        
        
        //Buraya 20/20 veya artık ne kadar soru varsa tamamını bilen dolayısı ile
         // yukarıdaki barı doldurabilen kullanıcıyı karşılayacak bir son paneli gerekiyor onu buraya yazmalısın. currectquestion toplam soru-1 olduğunda gelecek o panel





        
        

        
    }



    public void AnswerButton(int AnswerIndex)
    {
        for (int i = 0; i < buttons.Length; i++) // butona bastığımızda butonları pasif ediyor ki artarda basamayalım
        {
            buttons[i].interactable = false;
        }

        if (AnswerIndex == correctAnswerIndex) //RIGHT ANSWER
        {
            DogruCevapSesi();
           
            Debug.Log(currentQuestion);
            IpUcuControl();
            currentQuestion+=1;

            
            if (currentQuestion == questions.Length)// Sertifika burada gösteriliyor..Ses buraya eklenecek  questions.Length
            {
                BolumSonuSesi();
                GameManager.Instance.OyunSonuPaneli();
                /*Sertifika.GetComponent<Image>().DOFade(1, .7f).OnComplete(() =>
                {
                    AltinYildiz.transform.DOLocalMove(new Vector3(0, 1250, 0), 1f);
                    GameManager.Instance.OyuncuIsmi.DOFade(1, 2f);
                    exitbutonu.SetActive(true);
                });*/

            }

            if (currentQuestion>=questions.Length)
            {
                currentQuestion =questions.Length;
            }
            StartCoroutine(SoruBekleme());
            SliderArttır();
            buttons[correctAnswerIndex].image.color =Color.yellow;

            //DogruTikleri[correctAnswerIndex].GetComponent<Image>().DOFade(1, .5f);  olm niye xccode hata veriyor

            


        }
        else // Wrong Answer
        {
            Debug.Log("YANLIŞ CEVAP");
            YanlısCevapSesi();
            IpUcuControl();
            CameraSalla();

            Color kırmızı = Color.magenta;    //burayı new color diyerek var sayılan color olarak ayarla ama farklı script ile yapmalısın

            buttons[AnswerIndex].image.color = kırmızı;

            StartCoroutine(Dogrubekleme());
            
        }

        

    }



    void IpUcuControl()
    {
        
        GameManager.Instance.IpUcuObjPanel.transform.DOLocalMove(new Vector3(-2000f, 0, 0), .5f);
    }

    void SliderArttır()
    {
        GameManager.Instance.slider.value += ArttırılacakMiktar;
    }

    IEnumerator SoruBekleme()
    {
        yield return new WaitForSeconds(.7f);
        SetQuestion();
        for (int i = 0; i < buttons.Length; i++) //butonları aktif hale getiriyor
        {
            buttons[i].interactable = true;
        }
    }

    IEnumerator Dogrubekleme()
    {
        yield return new WaitForSeconds(.7f);
        GameManager.Instance.DogruyuGoster();
        for (int i = 0; i < buttons.Length; i++) //butonları aktif hale getiriyor
        {
            buttons[i].interactable = true;
        }
    }


    IEnumerator SertifikayıGoster()
    {
        yield return new WaitForSeconds(.8f);

    }

    void CameraSalla()// soru panelini ve butonları sallıyor
    {
        anapanel.transform.DOShakeRotation(1, 5, fadeOut: true);
        butonlar.transform.DOShakeRotation(1, 5, fadeOut: true);
    }

    void DogruCevapSesi()
    {
        DogruSes.PlayOneShot(dogrusesclip);
    }
    void YanlısCevapSesi()
    {
        YanlisSes.PlayOneShot(yanlısclip);
    }
    void BolumSonuSesi()
    {
        BolumSonuSes.PlayOneShot(bolumsonusesclip);
    }

}
