using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    //cada partida se compone de 10 turnos
    [Test]
    public void gameHasTenFrames()
    {
        //given
        
        //when
        Game game = new Game();
        //then
        Assert.AreEqual(10, game.frames.Length);
    }

    //hay 10 bolos que se intentan tirar en cada turno

    [Test]
    public void frameHasTenPins()
    {
        Frame frame = new Frame();

        Assert.AreEqual(10,frame.PinsCount);
    }

    //en cada turno el jugador hace 2 tiradas
    [Test]
    public void frameHasTwoBalls()
    {
        Frame frame = new Frame();
        Assert.AreEqual(2, frame.balls.Length);
    }

    //si en un turno el jugador no tira los 10 bolos,
    //la puntuación del turno es el total de bolos tirados
    [Test]
    public void scoreIsTheNumberOfKnockedDownIfPinsCountIsLessThanTen()
    {
        Frame frame = new Frame();

        frame.KnockDown(8);

        Assert.AreEqual(8, frame.Score);
    }

    //si en un turno el jugador tira los 10 bolos (un spare)
    //la puntuación es 10 más el número de bolos tirados en la siguiente tirada (del siguiente turno)
    [Test]
    public void scoreIsTenPlusNextKnockDownCountOnSpare() {
        Frame frame = new Frame();
        Frame frame2 = new Frame();

        frame.NextFrame = frame2;
        frame.KnockDown(8);
        frame.KnockDown(2);
        frame2.KnockDown(2);
        frame2.KnockDown(2);

        Assert.AreEqual(12, frame.Score);
    }

    //si en la primera tirada del turno tira los 10 bolos (un strike)
    //el turno acaba y la puntuación es 10 más el número de bolos de las 2 jugadas siguientes
    [Test]
    public void scoreIsTenPlusNextFrameScoreOntrike() {
        Frame frame = new Frame();
        Frame frame2 = new Frame();

        frame.NextFrame = frame2;
        frame.KnockDown(10);
        frame2.KnockDown(2);
        frame2.KnockDown(2);

        Assert.AreEqual(14, frame.Score);
    }

    //si el jugador logra un spare o un strike en el último turno,
    //obtiene una o dos tiradas más (respectivamente) de bonificación.
    //Esas tiradas cuentan como parte del mismo turno (el décimo).
    [Test]
    public void whenIsLastFrameAndWasSparePlayerHasOneMoreBall() {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(5);
        lastFrame.KnockDown(5);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }


}
