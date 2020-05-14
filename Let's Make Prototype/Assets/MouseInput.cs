using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MouseInput : MonoBehaviour
{
    Camera cam;

    private int shouldOpenAnimParamater = Animator.StringToHash("shouldOpen");
    private int shouldCloseAnimParamater = Animator.StringToHash("shouldClose");

    GameObject lastSeenObject;

    Animator deckAnimator;

    [SerializeField]
    GameObject[] DisableDecks;
    [SerializeField]
    GameObject[] enableArtCards;
    [SerializeField]
    GameObject descriptionText;
    [SerializeField]
    GameObject impactDescriptionText;
    [SerializeField]
    GameObject[] impactContextPage;
    [SerializeField]
    GameObject[] impactCardsPage;
    [SerializeField]
    GameObject[] finalPage;
    [SerializeField]
    GameObject[] startPage;
    [SerializeField]
    GameObject[] mediumDecksPage;

    [SerializeField]
    GameObject posterImage;
    [SerializeField]
    GameObject empathyImage;

    [SerializeField]
    GameObject hand1;
    [SerializeField]
    GameObject hand2;
    [SerializeField]
    GameObject hand3;
    [SerializeField]
    GameObject hand4;
    [SerializeField]
    GameObject hand5;
    [SerializeField]
    GameObject continueButton;
    [SerializeField]
    GameObject continueButton2;
    [SerializeField]
    GameObject final1;
    [SerializeField]
    GameObject final2;
    [SerializeField]
    GameObject MediumDescription;
    [SerializeField]
    GameObject ImpactDescription;

    public float lerpTime;

    private float lerpTimeMem;
    private bool isMoving;

    private GameObject handCard1;
    private GameObject handCard2;
    private GameObject handCard3;
    private GameObject handCard4;
    private GameObject handCard5;
    private GameObject lerpToPos;
    private GameObject finalMedium;
    private GameObject finalImpact;
    void Start()
    {
        cam = GetComponent<Camera>();
        lerpTimeMem = lerpTime;

    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(ray.origin, ray.direction, out hitInfo, 1000f);

        if (hitInfo.collider != null)
            lastSeenObject = hitInfo.collider.gameObject;


        if (lastSeenObject != null && lastSeenObject.name != "Plane")
        {
            if (lastSeenObject.GetComponent<Animator>() != null)
            {
                deckAnimator = lastSeenObject.GetComponent<Animator>();
            }
            else
            {
                deckAnimator = lastSeenObject.GetComponentInParent<Animator>();
            }

            if (deckAnimator != null)
            {
                deckAnimator.SetBool(shouldOpenAnimParamater, true);
                deckAnimator.SetBool(shouldCloseAnimParamater, false);


            }
            if (descriptionText.activeSelf && continueButton.activeSelf == false)
            {
                if (lastSeenObject.transform.parent.name == "Posters Card")
                {
                    descriptionText.GetComponent<TextMeshPro>().text = "Posters are a large visual presence wherever they are placed. With proper design, they succeed at catching the eye and relaying information.";
                }
                else if (lastSeenObject.transform.parent.name == "Sticker Art Card")
                {
                    descriptionText.GetComponent<TextMeshPro>().text = "Stickers are great for placing eye catching designs wherever people want.";
                }
                else if (lastSeenObject.transform.parent.name == "Animation Card")
                {
                    descriptionText.GetComponent<TextMeshPro>().text = "Animations are a great way to tell a story, and are easy to distribute digitally!";
                }
                else if (lastSeenObject.transform.parent.name == "Crafts Card")
                {
                    descriptionText.GetComponent<TextMeshPro>().text = "Crafts are a great way to get creative on a budget.";
                }
                else if (lastSeenObject.transform.parent.name == "Collage Card")
                {
                    descriptionText.GetComponent<TextMeshPro>().text = "Collage art is a great way to remix work if you lack technical art skills.";
                }

            }

            if (impactDescriptionText.activeSelf)
            {
                if (lastSeenObject.transform.parent.name == "Awareness Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Raise Awareness: to spread knowledge of a particular problem or cause.";
                }
                else if (lastSeenObject.transform.parent.name == "Community Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Cultivate Community: To nurture the sense of fellowship that a group of people share.";
                }
                else if (lastSeenObject.transform.parent.name == "Empathy Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Empathy: To help people develop the ability to sense other people's emotions and imagine what someone else might be thinking or feeling.";
                }
                else if (lastSeenObject.transform.parent.name == "Voices Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Raise up Other's Voices: to amplify and support the voices of others.";
                }
                else if (lastSeenObject.transform.parent.name == "Dialogue Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Foster Dialogue: to encourage the communication between two or more individuals or groups.";
                }
                else if (lastSeenObject.transform.parent.name == "Change Minds Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Change Minds: to convince others to change their opinion.";
                }
                else if (lastSeenObject.transform.parent.name == "Movement Card")
                {
                    impactDescriptionText.GetComponent<TextMeshPro>().text = "Start a Movement: to gather a group of people around a single idea or cause to take action.";
                }

            }


            if (finalPage[0].activeSelf)
            {

                handCard1.GetComponentInChildren<Animator>().enabled = false;
                handCard2.GetComponentInChildren<Animator>().enabled = false;
                handCard3.GetComponentInChildren<Animator>().enabled = false;
                handCard4.GetComponentInChildren<Animator>().enabled = false;
                handCard5.GetComponentInChildren<Animator>().enabled = false;



                if (finalMedium != null)
                {
                    if (finalMedium.name == "Posters Card")
                    {
                        MediumDescription.GetComponent<TextMeshPro>().text = "Posters are a large visual presence wherever they are placed. With proper design, they succeed at catching the eye and relaying information.";
                    }
                    if (finalMedium.name == "Sticker Art Card")
                    {
                        MediumDescription.GetComponent<TextMeshPro>().text = "Stickers are great for placing eye catching designs wherever people want.";
                    }
                    if (finalMedium.name == "Animation Card")
                    {
                        MediumDescription.GetComponent<TextMeshPro>().text = "Animations are a great way to tell a story, and are easy to distribute digitally!";
                    }
                    if (finalMedium.name == "Crafts Card")
                    {
                        MediumDescription.GetComponent<TextMeshPro>().text = "Crafts are a great way to get creative on a budget.";
                    }
                    if (finalMedium.name == "Collage Card")
                    {
                        MediumDescription.GetComponent<TextMeshPro>().text = "Collage art is a great way to remix work if you lack technical art skills.";
                    }
                }
                if (finalImpact != null)
                {
                    if (finalImpact.name == "Awareness Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Raise Awareness: to spread knowledge of a particular problem or cause.";
                    }
                    if (finalImpact.name == "Community Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Cultivate Community: To nurture the sense of fellowship that a group of people share.";
                    }
                    if (finalImpact.name == "Empathy Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Empathy: To help people develop the ability to sense other people's emotions and imagine what someone else might be thinking or feeling.";
                    }
                    if (finalImpact.name == "Voices Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Raise up Other's Voices: to amplify and support the voices of others.";
                    }
                    if (finalImpact.name == "Dialogue Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Foster Dialogue: to encourage the communication between two or more individuals or groups.";
                    }
                    if (finalImpact.name == "Change Minds Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Change Minds: to convince others to change their opinion.";
                    }
                    if (finalImpact.name == "Movement Card")
                    {
                        ImpactDescription.GetComponent<TextMeshPro>().text = "Start a Movement: to gather a group of people around a single idea or cause to take action.";
                    }
                }

                /*

                if (lastSeenObject.transform.parent.name == "Final Poster Card")
                {
                    posterImage.SetActive(true);
                    Debug.Log("should show poster image");
                }




                if (lastSeenObject.transform.parent.name == "Final Empathy Card")
                {
                    empathyImage.SetActive(true);
                    Debug.Log("should show Empathy image");
                }
                */

            }





            if (Input.GetMouseButtonDown(0))
            {
                if (lastSeenObject.name == "Start")
                {
                    foreach (GameObject g in startPage)
                    {
                        g.SetActive(false);
                    }
                    foreach (GameObject g in mediumDecksPage)
                    {
                        g.SetActive(true);
                    }
                }
                if (lastSeenObject.name == "Visual Art Deck")
                {
                    if (enableArtCards[0].activeSelf)
                    {
                        Debug.Log("Visual Art Deck");
                        foreach (GameObject g in DisableDecks)
                        {
                            g.SetActive(true);
                        }


                        enableArtCards[0].SetActive(false);

                        StartCoroutine(pause());
                    }
                    else
                    {
                        Debug.Log("Visual Art Deck");
                        foreach (GameObject g in DisableDecks)
                        {
                            g.SetActive(false);
                        }

                        foreach (GameObject g in enableArtCards)
                        {
                            g.SetActive(true);
                        }
                    }
                }
                else if ((lastSeenObject.transform.parent.name == "Posters Card" || lastSeenObject.transform.parent.name == "Sticker Art Card" || lastSeenObject.transform.parent.name == "Animation Card" || lastSeenObject.transform.parent.name == "Crafts Card" || lastSeenObject.transform.parent.name == "Collage Card") && impactCardsPage[0].activeSelf == false)
                {

                    if (handCard1 == null && isMoving == false)
                    {
                        Debug.Log("Trying to store 1");
                        handCard1 = lastSeenObject.transform.parent.gameObject;
                        StartCoroutine(LerpToPosition(handCard1, hand1));
                        StartCoroutine(pause());
                        handCard1.transform.SetParent(hand1.transform);
                    }
                    else if (handCard1 != null && handCard2 == null && isMoving == false)
                    {
                        Debug.Log("Trying to store 2");
                        handCard2 = lastSeenObject.transform.parent.gameObject;
                        StartCoroutine(LerpToPosition(handCard2, hand2));
                        StartCoroutine(pause());
                        handCard2.transform.SetParent(hand2.transform);

                    }
                    else if (handCard1 != null && handCard2 != null && handCard3 == null && isMoving == false)
                    {
                        Debug.Log("Trying to store 3");
                        handCard3 = lastSeenObject.transform.parent.gameObject;
                        StartCoroutine(LerpToPosition(handCard3, hand3));
                        handCard3.transform.SetParent(hand3.transform);
                        StartCoroutine(pause());
                        descriptionText.GetComponent<TextMeshPro>().text = "Click below to continue to the next step!";

                        continueButton.SetActive(true);
                    }

                }
                else if ((lastSeenObject.transform.parent.name == "Awareness Card" || lastSeenObject.transform.parent.name == "Community Card" || lastSeenObject.transform.parent.name == "Empathy Card" || lastSeenObject.transform.parent.name == "Voices Card" || lastSeenObject.transform.parent.name == "Dialogue Card" || lastSeenObject.transform.parent.name == "Change Minds Card" || lastSeenObject.transform.parent.name == "Movement Card") && impactCardsPage[0].activeSelf == true)
                {

                    if (handCard4 == null && isMoving == false)
                    {
                        Debug.Log("Trying to store 4");
                        handCard4 = lastSeenObject.transform.parent.gameObject;
                        StartCoroutine(LerpToPosition(handCard4, hand4));
                        handCard4.transform.SetParent(hand4.transform);

                        StartCoroutine(pause());
                    }
                    if (handCard5 == null && isMoving == false)
                    {
                        Debug.Log("Trying to store 5");
                        handCard5 = lastSeenObject.transform.parent.gameObject;
                        StartCoroutine(LerpToPosition(handCard5, hand5));

                        handCard5.transform.SetParent(hand5.transform);
                        StartCoroutine(pause());
                        impactDescriptionText.GetComponent<TextMeshPro>().text = "Click below to continue to the next step!";
                        continueButton2.SetActive(true);
                    }

                }

                /////////////////////////////////////

                if ((lastSeenObject.transform.parent.name == "Awareness Card" || lastSeenObject.transform.parent.name == "Community Card" || lastSeenObject.transform.parent.name == "Empathy Card" || lastSeenObject.transform.parent.name == "Voices Card" || lastSeenObject.transform.parent.name == "Dialogue Card" || lastSeenObject.transform.parent.name == "Change Minds Card" || lastSeenObject.transform.parent.name == "Movement Card" || lastSeenObject.transform.parent.name == "Posters Card" || lastSeenObject.transform.parent.name == "Sticker Art Card" || lastSeenObject.transform.parent.name == "Animation Card" || lastSeenObject.transform.parent.name == "Crafts Card" || lastSeenObject.transform.parent.name == "Collage Card") && finalPage[0].activeSelf == true)
                {

                    Debug.Log("Clicking on Final Page");
                    if (handCard1 == lastSeenObject.transform.parent.gameObject && isMoving == false)
                    {
                        if (finalMedium == null)
                        {
                            finalMedium = handCard1;
                            StartCoroutine(LerpToPosition(handCard1, final1));
                            handCard1.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard1.name;
                        }
                        else
                        {
                            if (finalMedium == handCard2)
                            {

                                handCard2.transform.SetParent(hand2.transform);
                                handCard2.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            else if (finalMedium == handCard3)
                            {
                                handCard3.transform.SetParent(hand3.transform);
                                handCard3.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            finalMedium = handCard1;
                            StartCoroutine(LerpToPosition(handCard1, final1));
                            handCard1.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard1.name;
                        }

                    }
                    if (handCard2 == lastSeenObject.transform.parent.gameObject && isMoving == false)
                    {
                        if (finalMedium == null)
                        {
                            finalMedium = handCard2;
                            StartCoroutine(LerpToPosition(handCard2, final1));
                            handCard2.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard2.name;
                        }
                        else
                        {
                            if (finalMedium == handCard1)
                            {
                                handCard1.transform.SetParent(hand1.transform);
                                handCard1.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            else if (finalMedium == handCard3)
                            {
                                handCard3.transform.SetParent(hand3.transform);
                                handCard3.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            finalMedium = handCard2;
                            StartCoroutine(LerpToPosition(handCard2, final1));
                            handCard2.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard2.name;
                        }

                    }
                    if (handCard3 == lastSeenObject.transform.parent.gameObject && isMoving == false)
                    {
                        if (finalMedium == null)
                        {
                            finalMedium = handCard3;
                            StartCoroutine(LerpToPosition(handCard3, final1));
                            handCard3.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard3.name;
                        }
                        else
                        {
                            if (finalMedium == handCard1)
                            {
                                handCard1.transform.SetParent(hand1.transform);
                                handCard1.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            else if (finalMedium == handCard2)
                            {
                                handCard2.transform.SetParent(hand2.transform);
                                handCard2.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            finalMedium = handCard3;
                            StartCoroutine(LerpToPosition(handCard3, final1));
                            handCard3.transform.SetParent(final1.transform);
                            StartCoroutine(pause());
                            MediumDescription.GetComponent<TextMeshPro>().text = handCard3.name;
                        }

                    }
                    if (handCard4 == lastSeenObject.transform.parent.gameObject && isMoving == false)
                    {
                        if (finalImpact == null)
                        {
                            finalImpact = handCard4;
                            StartCoroutine(LerpToPosition(handCard4, final2));
                            handCard4.transform.SetParent(final2.transform);
                            StartCoroutine(pause());
                            ImpactDescription.GetComponent<TextMeshPro>().text = handCard4.name;
                        }
                        else
                        {
                            if (finalImpact == handCard5)
                            {
                                handCard5.transform.SetParent(hand5.transform);
                                handCard5.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            finalImpact = handCard4;
                            StartCoroutine(LerpToPosition(handCard4, final2));
                            handCard4.transform.SetParent(final2.transform);
                            StartCoroutine(pause());
                            ImpactDescription.GetComponent<TextMeshPro>().text = handCard4.name;
                        }

                    }
                    if (handCard5 == lastSeenObject.transform.parent.gameObject && isMoving == false)
                    {
                        if (finalImpact == null)
                        {
                            finalImpact = handCard5;
                            StartCoroutine(LerpToPosition(handCard5, final2));
                            handCard5.transform.SetParent(final2.transform);
                            StartCoroutine(pause());
                            ImpactDescription.GetComponent<TextMeshPro>().text = handCard5.name;
                        }
                        else
                        {
                            if (finalImpact == handCard4)
                            {
                                handCard4.transform.SetParent(hand4.transform);
                                handCard4.transform.localPosition = Vector3.zero;
                                StartCoroutine(pause());
                            }
                            finalImpact = handCard5;
                            StartCoroutine(LerpToPosition(handCard5, final2));
                            handCard5.transform.SetParent(final2.transform);
                            StartCoroutine(pause());
                            ImpactDescription.GetComponent<TextMeshPro>().text = handCard5.name;
                        }

                    }


                }
                if (lastSeenObject.name == "Continue")
                {
                    foreach (GameObject g in enableArtCards)
                    {
                        g.SetActive(false);
                    }
                    foreach (GameObject g in impactCardsPage)
                    {
                        g.SetActive(true);
                    }
                }
                if (lastSeenObject.name == "Continue2")
                {
                    foreach (GameObject g in impactCardsPage)
                    {
                        g.SetActive(false);
                    }
                    foreach (GameObject g in finalPage)
                    {
                        g.SetActive(true);
                    }
                }

                if (lastSeenObject.name == "Restart")
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

            }

        }
        else if (deckAnimator != null)
        {
            deckAnimator.SetBool(shouldCloseAnimParamater, true);
            deckAnimator.SetBool(shouldOpenAnimParamater, false);


            posterImage.SetActive(false);
            empathyImage.SetActive(false);



        }








    }


    IEnumerator LerpToPosition(GameObject card, GameObject handNum)
    {

        lerpToPos = handNum;

        Debug.Log("Beginning Lerp");

        while (lerpTime > 0)
        {
            yield return null;
            isMoving = true;
            lerpTime -= Time.deltaTime;

            card.transform.position = Vector3.Lerp(card.transform.position, lerpToPos.transform.position, Time.deltaTime * 4);
            // card.transform.localRotation = Quaternion.Lerp(card.transform.localRotation, lerpToPos.transform.rotation, Time.deltaTime * 2);

            if (lerpTime <= 0)
            {
                Debug.Log("Lerp Done!");
                isMoving = false;
                lerpTime = lerpTimeMem;
                break;
            }
        }
    }


    IEnumerator pause()
    {
        isMoving = true;
        yield return new WaitForSeconds(1);
        isMoving = false;
    }

}
