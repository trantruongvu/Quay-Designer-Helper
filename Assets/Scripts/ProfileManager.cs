using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    CharacterManager character;

    public Image profileWall;
    public Image profileRace;
    public Image profileCloth;
    public Image profileTable;
    public Image profileHobby;

    public Transform profileControl;
    public Transform profileExecution;
    public Transform profileThinking;
    public Transform profileResilient;

    public TextMeshProUGUI profileText;

    private void Start()
    {
        character = CharacterManager.Instance;
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (character == null)
            character = CharacterManager.Instance;

        profileWall.sprite = character.wall.Sprite;
        profileRace.sprite = character.race.Sprite;
        profileCloth.sprite = character.cloth.Sprite;
        profileTable.sprite = character.table.Sprite;
        profileHobby.sprite = character.hobby.Sprite;

        profileControl.localScale = new Vector3(Mathf.Clamp(character.valueControl / 20f, 0f, 1f), 1, 1);
        profileExecution.localScale = new Vector3(Mathf.Clamp(character.valueExecution / 20f, 0f, 1f), 1, 1);
        profileThinking.localScale = new Vector3(Mathf.Clamp(character.valueThinking / 20f, 0f, 1f), 1, 1);
        profileResilient.localScale = new Vector3(Mathf.Clamp(character.valueResilient / 20f, 0f, 1f), 1, 1);

        profileText.text = "*This is just a general description of your designer trait as a fictional character and should not be taken seriously. For a more qualitative evaluation, please visit and participate in the Weekly Challenge.*";

        // Race
        profileText.text += ("\n" + string.Format(character.race.ProfileInfo, '\n'));

        // Trait
        if (character.race.Name.Equals("Werewolf"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Werewolf:\n- Werewolves are inherently emotional, even with rational characteristics. You tend to focus on the motive of other people, or the story of the design.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Werewolf:\n- Werewolves are active. A creative Werewolf like you is bold. To take your idea further, you are not afraid of repeating the design process.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Werewolf:\n- You pay attention to other people’s feelings and show constant concern of ethnicity in your design. Some emotional Werewolves easily show strong compassion for fictional characters.";
        }
        else if (character.race.Name.Equals("Angel"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Angel:\n- Rational Angels are sometimes assertive. Because you are used to reading the environment, you know how to control the atmosphere.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Angel:\n- The status of Angels rely on their companions. You are naturally playful and your boldness is multiplied when you are with your friends.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Angel:\n- You usually prioritize the tasks based on your interest. The results are usually so expressive that other people can tell if you like it or not during the design process.";
        }
        else if (character.race.Name.Equals("Wisp"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Wisp:\n- Wisps tend to please others rather than themself, therefore, they are often worn out. However, a rational Wisp like you can distinguish the border of responsibility and avoid being led by others.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Wisp:\n- You are more active than other Wisps. Not only follow the instruction, you also find ways to improve it.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Wisp:\n- You are innocent and passionate. Your enthusiasm when supporting others puts a smile on their faces.";
        }
        else if (character.race.Name.Equals("Elf"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Elf:\n- When developing new ideas, you focus on their functionality and practical aspects. You tend to set a goal for each task to make sure each step you took was executed well.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Elf:\n- Elf are naturally playful. A creative Elf like you is usually a workaholic. You have a list of things you want to do and it never stops expanding.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Elf:\n- You easily feel passionate. You constantly inspire others through your design. Sometimes you put too much emotion in negative feedback that it affects your motivation.";
        }
        else if (character.race.Name.Equals("Human"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Human:\n- Humans are usually not self motivated. Rational Humans like you usually work better under pressure.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Human:\n- Humans have wide connections. You can see potential in other people and want to improve with them.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Human:\n- You usually keep the ideas to yourself because you don’t want to take other people's chances to express themself. Keep in mind that sometimes you could be selfish because the people you care about also care about you.";
        }
        else if (character.race.Name.Equals("Mermaid"))
        {
            if (character.trait.Name.Equals("Rational"))
                profileText.text += "\n\nRational Mermaid:\n- Mermaids are born rational, which makes rational Mermaids perfectionists. You value the learning outcomes and foresee how to achieve it.";
            else if (character.trait.Name.Equals("Creative"))
                profileText.text += "\n\nCreative Mermaid:\n- You are bold. You are not stressed out about the design outcome because you are confident and only want to express yourself through design.";
            else if (character.trait.Name.Equals("Emotional"))
                profileText.text += "\n\nEmotional Mermaid:\n- You are expressive and supportive. You like to have a competitive companion to constantly improve each other.";
        }

        profileText.text += ("\n\n" + character.cloth.Name + ":");
        profileText.text += string.Format(character.cloth.ProfileInfo, '\n');
        profileText.text += ("\n\n" + character.hobby.Name + ":");
        profileText.text += string.Format(character.hobby.ProfileInfo, '\n');
        profileText.text += ("\n\n" + character.table.Name + " table :");
        profileText.text += string.Format(character.table.ProfileInfo, '\n');
        profileText.text += ("\n\n" + character.wall.Name + " wall :");
        profileText.text += string.Format(character.wall.ProfileInfo, '\n');
    }


    // Update is called once per frame
    void Update()
    {

    }
}
