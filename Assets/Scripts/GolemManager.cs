using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemManager : MonoBehaviour
{
    List<IdleTalk> idleTalks;
    IdleTalk idleTalk;

    List<CoolTalk> coolTalks;
    CoolTalk coolTalk;
    int count = 0;

    List<PlanTalk> planTalks;
    PlanTalk planTalk;

    [Header("Talk buttons")]
    public Button btnIdle;
    public Button btnCool;
    public Button btnPlan;

    [Header("Golem")]
    public Image imgHead;
    public Sprite neutral;
    public Sprite happy;
    public Sprite sad;
    public Text txtGolem;
    private string txtDefault = "Good to see you again! What would like to talk about?";

    [Header("Interact")]
    public Button btnNext;
    public Button btnYes;
    public Button btnNo;
    public Button btnEnter;
    public InputField inputAnswer;

    // Start is called before the first frame update
    void Start()
    {
        idleTalks = new List<IdleTalk>();
        idleTalks.Add(new IdleTalk()
        {
            ask = "Is there any food you want to try?",
            startNo = "Not at all? I have strong apatite so I eat all the time.",
            endNo = "Last time I heard someone want to try Dimsum. I want to try it too.",
            startYes = "What is it?",
            endYes = "That sounds delicious! I want to try it too!",
            retry = "Have you tried your favourite food! Next time tell me about it.",
        });

        idleTalks.Add(new IdleTalk()
        {
            ask = "You look lovely today! Do you like fashion?",
            startNo = "Oh! It's just that I have some question relate to it, but maybe for another time.",
            endNo = "Last time I heard someone like fashion because they feel good wearing handmade clothes.",
            startYes = "Why do you like fashion?",
            endYes = "That's good to know. I hope one day there are clothes for Golems like me.",
            retry = "I hope you still like fashion!",
        });

        idleTalks.Add(new IdleTalk()
        {
            ask = "Is there any place you want to visit?",
            startNo = "Sometimes I also enjoy staying at one place. But I like to go out more.",
            endNo = "Last time I heard someone want to go to Taiwan.",
            startYes = "Where is it?",
            endYes = "That sounds lovely! When you go there please take me with you!",
            retry = "I hope you already been to the place you like!",
        });

        idleTalks.Add(new IdleTalk()
        {
            ask = "Do you like to stay at one place?",
            startNo = "I guess you are an outgoing person? If you go somewhere interesting please share with me also.",
            endNo = "Last time I heard someone like to stay at one place because it's quite and convenient.",
            startYes = "Why don't you like to go somewhere else?",
            endYes = "That's so relatable! I wish I could stay with you.",
            retry = "Are you still loving what you do? I know you can do anything because you are amazing!",
        });

        idleTalks.Add(new IdleTalk()
        {
            ask = "Is there any designer you like?",
            startNo = "It's okay. I think that learning from a model might help we grow faster.",
            endNo = "Last time I heard someone like a designer because they are Lovely designs, Gentle, Care about environment",
            startYes = "Please tell me 1 thing you like about them!",
            endYes = "Amazing! I think that learning from a model will help we grow faster.",
            retry = "Do you still remember the designer you told me? I did some research and they are amazing!",
        });


        coolTalks = new List<CoolTalk>();
        coolTalks.Add(new CoolTalk()
        {
            start = "So I met this Human, Alan Fletcher, a graphic designer, he said:",
            middle = "“I don’t know where I’m going, but I’m on my way”.",
            end = "Not sure if he has reach the destination yet, but I'm glad that he's happy!"
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Yesterday, I met a Mermaid name Zara Hadid, an architecture, she said:",
            middle = "\"You have to be very focused and work very hard, but it’s not about working hard without knowing what your aim is.\"",
            end = "Knowing my aim? And working hard? I just want to be happy."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "You know what Rachel always says?",
            middle = "\"Great start!\"",
            end = "I feel her, and I feel you, too."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Andy usually told me:",
            middle = "\"Confusion is good.\"",
            end = "I guess confusion is a part of the design process? We got confused, then we solve it, and then we got confused, then..."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Of all Elves I met, I love this guy Harry Winston, a jeweler. He said:",
            middle = "\"People will stare, make it worth their while.\"",
            end = "Like, look at me, I am so big that people can see with their eyes closed."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "\"Can I disagree with you ?\"",
            middle = "You know who said that? Ken! He always disagree with me!",
            end = "But I don't hate it. Actually I feel like he's trying to help me understand my ideas deeper."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Quick motivational speech from Manny:",
            middle = "\"Pull all nighter if you have to.\"",
            end = "Are you feeling motivated?"
        });
        coolTalks.Add(new CoolTalk()
        {
            start = "Sometimes, I find myself in a complete mess, and things fall out of plans.",
            middle = "Then Rachel told me to make a list, a detailed list of things I could do.",
            end = "Tick the list while doing it, and everything was done before I knew it."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "When i'm out of ideas, I remember this Werewolf Philippe Starck, an industrial designer:",
            middle = "\"I wait, I read magazines. After a while, my brain sends me a product.\"",
            end = "It's true, my ideas always come when I take a bath."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Paul Daviz, a Wisp artist once told me:",
            middle = "\"Leave your excuses and live your dreams!\"",
            end = "Man I didn't give any excuses. I was just... need to rest abit."
        });

        coolTalks.Add(new CoolTalk()
        {
            start = "Beatriz Potter, an Angel, and a writer, used to say:",
            middle = "\"I have just made stories to please myself, because I never grew up.\"",
            end = "You know I might look this big, but I am still very little compared to other Golems. And it's okay."
        });

        planTalks = new List<PlanTalk>();
        planTalks.Add(new PlanTalk()
        {
            start1 = "It is a good day! Did you spend time on your personal hobbies?",
            start2 = "Okay! Did you spend time on your personal hobbies today?",
            startNo1 = "No? You know if your hobby is sleep, I still consider it working.",
            startNo2 = "Then I suppose you are busy with other things. Hope you get them done!",
            endNo1 = "It's always good to spend time for yourself.",
            endNo2 = "Remember to spend time for yourself.",
            startYes1 = "Ooh, may I know what you have done?",
            startYes2 = "Great! What did you do?",
            endYes1 = "That sounds amazing. Next time teach me how to do it!",
            endYes2 = "Really, I wish I could join you too!",
        });

        planTalks.Add(new PlanTalk()
        {
            start1 = "It is a good time to meet your friends! Have you talk with them recently?",
            start2 = "I think the weather is nice. Did you hang out or talk with your friend?",
            startNo1 = "Oh... I hope you do. I bet they have all fun stories to share with you.",
            startNo2 = "Oh okay... maybe today you don't feel like it.",
            endNo1 = "Anyway, I am also your friend, so I will consider that was a \"yes\".",
            endNo2 = "If something trouble you, promise me you would share it with me.",
            startYes1 = "Great! I would love to meet your friends, too.",
            startYes2 = "Great! It's nice to share all things with your friends!",
            endYes1 = "Next time please introduce me with them!",
            endYes2 = "I am doing my homework and it's so hard. I want to rant about it with my friends, too.",
        });

        planTalks.Add(new PlanTalk()
        {
            start1 = "You seem weary... Need a rest?",
            start2 = "Do you find raining relaxing?",
            startNo1 = "Okay... Just don't stress yourself too much.",
            startNo2 = "You don't? It's just that I find the sounds of it very relaxing.",
            endNo1 = "If you need accompany, I am always here with you!",
            endNo2 = "Talking about relax, I feel sleepy now. I hope you also get enough sleep.",
            startYes1 = "Great! I don't know much about design work but it's always important to relax.",
            startYes2 = "Nice! I also find the sounds of it very relaxing.",
            endYes1 = "If you need me, I am always here!",
            endYes2 = "Talking about relax, I feel sleepy now. I hope you also get enough sleep.",
        });

        planTalks.Add(new PlanTalk()
        {
            start1 = "Tick tock! Have you done your work today?",
            start2 = "What's that you are bringing? Are you working?",
            startNo1 = "Haha I guess so... Make sure to have it done today or it will stack double tomorrow.",
            startNo2 = "Oh! You seem relaxed, I thought you had just finished your work.",
            endNo1 = "Or you can spend today to rest and have it done later actually.",
            endNo2 = "Anyway, make sure to have your work done and you can play then.",
            startYes1 = "Haha I know you do! You are amazing!",
            startYes2 = "Great! I like to keep myself busy sometimes.",
            endYes1 = "I always slack off. Next time I will ask you to help me with my study.",
            endYes2 = "But don't forget to balance work and life.",
        });

    }

    public void StartIdleTalk()
    {

    }

    public void StartCoolTalk()
    {
        btnIdle.gameObject.SetActive(false);
        btnCool.gameObject.SetActive(false);
        btnPlan.gameObject.SetActive(false);

        if (count >= coolTalks.Count)
            count = 0;
        coolTalk = coolTalks[count];
        count++;

        btnNext.gameObject.SetActive(true);

        imgHead.sprite = neutral;
        txtGolem.text = coolTalk.start;

        btnNext.onClick.RemoveAllListeners();
        btnNext.onClick.AddListener(() =>
        {
            imgHead.sprite = neutral;
            txtGolem.text = coolTalk.middle;

            btnNext.onClick.RemoveAllListeners();
            btnNext.onClick.AddListener(() =>
            {
                imgHead.sprite = happy;
                txtGolem.text = coolTalk.end;

                btnNext.onClick.RemoveAllListeners();
                btnNext.onClick.AddListener(() =>
                {
                    imgHead.sprite = neutral;
                    txtGolem.text = txtDefault;

                    btnIdle.gameObject.SetActive(true);
                    btnCool.gameObject.SetActive(true);
                    btnPlan.gameObject.SetActive(true);
                });
            });
        });
    }

    public void StartPlanTalk()
    {

    }
}

public class IdleTalk
{
    public string ask; // neutral
    public string startNo; // sad
    public string endNo; // happy
    public string startYes; // neutral
    public string endYes; // happy
    public string retry; // neutral
}

public class CoolTalk
{
    public string start; // neutral
    public string middle; // neutral
    public string end; // happy
}

public class PlanTalk
{
    public string start1; // neutral
    public string start2; // neutral
    public string startNo1; // sad
    public string startNo2; // sad
    public string endNo1; // happy
    public string endNo2; // happy
    public string startYes1; // happy
    public string startYes2; // happy
    public string endYes1; // neutral
    public string endYes2; // neutral
}