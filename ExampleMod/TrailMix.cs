using System;
using System.IO;
using System.Reflection;
using ModGenesia;
using System.Collections.Generic;
using RogueGenesia.Data;
using RogueGenesia.Actors.Survival;
using UnityEngine;
using RogueGenesia.GameManager;
using RogueGenesia.Sound;
using RogueGenesia.UI;

public class TrailMix : RogueGenesiaMod
{
    //so we can track the mod folder to load texture from
    static public string ModFolder;

    //This happen before the game load any contents
    public override void OnModLoaded(ModData modData)
    {

        ModFolder = modData.ModDirectory.FullName;

        Debug.Log("Example Mod Loaded");
    }


    //We add content at this stage, as it happen after game registered the vanilla content, but before it initiated all the IDs
    //Adding stuff before can work but you won't be able to add requirement from vanilla content
    //Adding stuff after won't work because their ID will be conflicting with other vanilla content
    public override void OnRegisterModdedContent()
    {

        AddRyeChip();


        Debug.Log("Trail Mix Added");
    }



    //This function is called when the game is finishing loading all the mods and the vanilla content
    public override void OnAllContentLoaded()
    {
        Debug.Log("Game Finished Loading Mods Step");
    }

    //Adding in Rye Chip
    public void AddRyeChip()
    {


        //card creation of soulcardcreation data is the same as the preview example
        SoulCardCreationData soulCardCreationData = new SoulCardCreationData();


        soulCardCreationData.Tags = CardTag.Wind | CardTag.Moon;

        soulCardCreationData.MaxLevel = 3;
        soulCardCreationData.Texture = ModGenesia.ModGenesia.LoadSprite(ModFolder + "/RyeChip.png");

        soulCardCreationData.NameOverride = new List<LocalizationData>();
        soulCardCreationData.NameOverride.Add(new LocalizationData());
        soulCardCreationData.NameOverride[0].Key = "en";
        soulCardCreationData.NameOverride[0].Value = "Rye Chip";

        soulCardCreationData.DescriptionOverride = new List<LocalizationData>();
        soulCardCreationData.DescriptionOverride.Add(new LocalizationData());
        soulCardCreationData.DescriptionOverride[0].Key = "en";
        soulCardCreationData.DescriptionOverride[0].Value = "When you dash, decrease your dash cooldown by 20% (+20% per level). Stacks last 10 seconds.";

        soulCardCreationData.DropWeight = 0.1f;
        soulCardCreationData.LevelUpWeight = 0.2f;


        soulCardCreationData.Rarity = CardRarity.Heroic;
        soulCardCreationData.ModSource = "TrailMix";

        //the main difference is that we send the constructor of the class linked to the card, so the game know which class to instantiate when we obtain the card
        // typeof(YOURCLASS).GetConstructor(Type.EmptyTypes)
        CardAPI.AddCustomCard("Rye Chip", typeof(RyeChip).GetConstructor(Type.EmptyTypes), soulCardCreationData, true);
    }
}
