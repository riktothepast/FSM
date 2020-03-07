using System;
using UnityEngine;

namespace net.fiveotwo.fsm
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true)]
    public class AnimationStateNameAttribute : PropertyAttribute
    {
    }
}
