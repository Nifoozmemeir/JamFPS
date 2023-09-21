using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class EditorScriptTest
{
    [Test]
    public void Character_InitialLife()
    {
        int initialLife = 100;

        Warrior warrior = new Warrior(initialLife);// 0, 0, 0, 0);

        Assert.AreEqual(warrior.currentHp, initialLife);
    }
}