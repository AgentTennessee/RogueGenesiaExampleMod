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


public class RyeChipEffect : Buff
{

    protected float DashReduce = .80f;
    protected float ReduceCap = 3;
    public RyeChipEffect(int ID, IEntity owner, IEntity origin, BuffStacking buffStacking, float dashReduce,float reduceCap, float duration = 3, float level = 1)
        : base(ID, owner, origin, duration, level, buffStacking)
    {
        DashReduce = dashReduce;
        ReduceCap = reduceCap;
    }

    public override void LoadBuffIcon()
    {
        if (_buffIcon == null)
        {
            _buffIcon = ModGenesia.ModGenesia.LoadPNGTexture(TrailMix.ModFolder + "/RyeChip.png");
        }
    }

    public override void UpdateStats(float newStackLevel)
    {
        if ((PlayerEntity)_entity)
        {
            ((PlayerEntity)_entity).GetPlayerStats.DashCoolDown.SetCurrentMultiplierStat(Mathf.Pow(DashReduce, Mathf.Min(ReduceCap, _buffLevel)));
        }
    }

    public override void AddBuff(Buff buff)
    {
        DashReduce = ((RyeChipEffect)buff).DashReduce;
        ReduceCap = ((RyeChipEffect)buff).ReduceCap;
        base.AddBuff(buff);
    }
}
