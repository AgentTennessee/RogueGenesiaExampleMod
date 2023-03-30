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

public class RyeChip : SoulCard
{
    public override void OnDash(PlayerEntity owner)
    {
        owner.AddBuff(new RyeChipEffect(BuffIDManager.GetID("RyeChipBuff"), owner, owner, BuffStacking.IncreaseLevelByLevel | BuffStacking.IndepentStackDuration, 0.80f, 3f, 10f, 1));
    }




}

