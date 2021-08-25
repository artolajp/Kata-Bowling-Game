using System;
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
        game.Roll(6);

        Assert.AreEqual(6, game.Score);
    }

    [Test]
    public void Has_Score_Equals_AllFrameBalls_WhenNoStrikesOrSpares()
    {
        Game game = new Game();
        game.Roll(6);
        game.Roll(2);

        Assert.AreEqual(8, game.Score);
    }

    [Test]
    public void Has_Score_EqualTo_AllFrameScores_WhenNoStrikesOrSpares()
    {
        Game game = new Game();
        game.Roll(6);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);

        Assert.AreEqual(16, game.Score);
    }

    [Test]
    public void Has_Score_EqualTo_AllFrameScoresPlusStrikeScore_WhenStrikes()
    {
        Game game = new Game();
        game.Roll(6);
        game.Roll(0);
        game.Roll(10);
        game.Roll(2);
        game.Roll(2);
        game.Roll(2);

        Assert.AreEqual(26, game.Score);
    }

    /*
    X X X X X X X X X X X X(12 rolls: 12 strikes) = 10 frames* 30 points = 300
5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5 (21 rolls: 10 pairs of 5 and spare, with a final 5) = 10 frames* 15 points = 150
    */

    [Test]
    public void Has_Score_EqualsTo_300_when_rollsTwelvesStrikes() {
        Game game = new Game();

        for (int i = 0; i < 12; i++) {
            game.Roll(10);
        }

        Assert.AreEqual(300, game.Score);
    }

    [Test]
    public void Has_Score_EqualsTo_30_OnPenultimateFrame_when_rollsTwelvesStrikes() {
        Game game = new Game();

        for (int i = 0; i < 12; i++) {
            game.Roll(10);
        }

        Assert.AreEqual(30, game.frames[game.frames.Length - 2].Score);
    }

    //9- 9- 9- 9- 9- 9- 9- 9- 9- 9- (20 rolls: 10 pairs of 9 and miss) = 10 frames* 9 points = 90
    [Test]
    public void Has_Score_EqualsTo_Ninety_when_rollsNinePinsTenTimes() {
        Game game = new Game();

        for (int i = 0; i < 10; i++) {
            game.Roll(9);
        }

        Assert.AreEqual(90, game.Score);
    }

    // 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5 (21 rolls: 10 pairs of 5 and spare, with a final 5) = 10 frames* 15 points = 150
    [Test]
    public void Has_Score_EqualsTo_AHundredFifty_when_rollsFivePinsTwentyOneTimes() {
        Game game = new Game();

        for (int i = 0; i < 21; i++) {
            game.Roll(5);
        }

        Assert.AreEqual(150, game.Score);
    }

    [Test]
    public void BeFinished_When_LastFrameIsFinished() {
        Game game = new Game();

        for (int i = 0; i < 12; i++) {
            game.Roll(10);
        }

        Assert.IsTrue(game.IsFinished);
    }
}
