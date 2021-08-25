using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameShould
{
    //cada partida se compone de 10 turnos
    [Test]
    public void Has_TenFrames()
    {
        //given
        Game game = new Game();
        //when

        //then
        Assert.AreEqual(10, game.frames.Length);
    }

    [Test]
    public void Has_NextFrame_ForEachFrame_WhenIsNotTheLastOne()
    {
        //Given
        Game game = new Game();
        //When

        //Then
        for (int frame = 0; frame < game.frames.Length - 1; frame++)
        {
            Assert.IsNotNull(game.frames[frame].NextFrame);
        }
    }

    [Test]
    public void Has_LastFrame_WithoutNextFrame()
    {
        //Given
        Game game = new Game();
        //When

        //Then
        Assert.IsNull(game.frames[game.frames.Length - 1].NextFrame);
    }

    [Test]
    public void HasNot_Score_AtBeginning()
    {
        Game game = new Game();

        Assert.AreEqual(0, game.Score);
    }

    [Test]
    public void Has_Score_EqualTo_FirstFrameBalls_WhenNoStrike()
    {
        Game game = new Game();
        game.ThrowBall(6);

        Assert.AreEqual(6, game.Score);
    }

    [Test]
    public void Has_Score_Equals_AllFrameBalls_WhenNoStrikesOrSpares()
    {
        Game game = new Game();
        game.ThrowBall(6);
        game.ThrowBall(2);

        Assert.AreEqual(8, game.Score);
    }

    [Test]
    public void Has_Score_EqualTo_AllFrameScores_WhenNoStrikesOrSpares()
    {
        Game game = new Game();
        game.ThrowBall(6);
        game.ThrowBall(2);
        game.ThrowBall(2);
        game.ThrowBall(2);
        game.ThrowBall(2);
        game.ThrowBall(2);

        Assert.AreEqual(16, game.Score);
    }

    [Test]
    public void Has_Score_EqualTo_AllFrameScoresPlusStrikeScore_WhenStrikes()
    {
        Game game = new Game();
        game.ThrowBall(6);
        game.ThrowBall(0);
        game.ThrowBall(10);
        game.ThrowBall(2);
        game.ThrowBall(2);
        game.ThrowBall(2);

        Assert.AreEqual(26, game.Score);
    }
}
