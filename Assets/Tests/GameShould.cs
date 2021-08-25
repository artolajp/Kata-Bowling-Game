using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameShould
{
    //cada partida se compone de 10 turnos
    [Test]
    public void HasTenFrames()
    {
        //given
        Game game = new Game();
        //when

        //then
        Assert.AreEqual(10, game.frames.Length);
    }

    [Test]
    public void HasNextFrameForEachFrameWhenIsNotTheLastOne()
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
    public void HasLastFrameWithoutNextFrame()
    {
        //Given
        Game game = new Game();
        //When

        //Then
        Assert.IsNull(game.frames[game.frames.Length - 1].NextFrame);
    }

    [Test]
    public void HasNoScoreWhenStart()
    {
        Game game = new Game();

        Assert.AreEqual(0, game.Score);
    }

    [Test]
    public void HasScoreEqualToFirstFrameBallsWhenNoStrike()
    {
        Game game = new Game();
        game.ThrowBall(6);

        Assert.AreEqual(6, game.Score);
    }

    [Test]
    public void HasScoreEqualToAllFrameBallsWhenNoStrikeAndNoSpare()
    {
        Game game = new Game();
        game.ThrowBall(6);
        game.ThrowBall(2);

        Assert.AreEqual(8, game.Score);
    }

    [Test]
    public void HasScoreEqualToAllFrameScoresWhenNoStrikesOrSpares()
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
    public void HasScoreEqualToAllFrameScoresPlusStrikeScoreWhenStrikes()
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
