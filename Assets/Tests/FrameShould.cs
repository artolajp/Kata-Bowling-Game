using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FrameShould
{

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
    public void scoreIsTenPlusNextFrameScoreOnStrike() {
        Frame frame = new Frame();
        Frame frame2 = new Frame();

        frame.NextFrame = frame2;
        frame.KnockDown(10);
        frame2.KnockDown(1);
        frame2.KnockDown(3);

        Assert.AreEqual(14, frame.Score);
    }

    [Test]
    public void scoreIsTenPlusNextTwoBallsScoreOnTwoStrikes()
    {
        Frame frame = new Frame();
        Frame frame2 = new Frame();
        Frame frame3 = new Frame();

        frame.NextFrame = frame2;
        frame2.NextFrame = frame3;
        frame.KnockDown(10);
        frame2.KnockDown(10);
        frame3.KnockDown(2);
        frame3.KnockDown(2);


        Assert.AreEqual(22, frame.Score);
    }

    //si el jugador logra un spare o un strike en el último turno,
    //obtiene una o dos tiradas más (respectivamente) de bonificación.
    //Esas tiradas cuentan como parte del mismo turno (el décimo).
    //SPARE
    [Test]
    public void whenIsLastFrameAndWasSparePlayerHasOneMoreBall() {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(5);
        lastFrame.KnockDown(5);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }

    //si el jugador logra un spare o un strike en el último turno,
    //obtiene una o dos tiradas más (respectivamente) de bonificación.
    //Esas tiradas cuentan como parte del mismo turno (el décimo).
    //STRIKE
    [Test]
    public void whenIsLastFrameAndWasStrikePlayerHasTwoMoreBalls()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }
    //Si en las tiradas de bonificación el jugador derriba todos los bolos,
    //el proceso no se repite, es decir que no se vuelven a generar más
    //lanzamientos de  bonificación.
    [Test]
    public void whenIsLastFrameAndHasTwoStrikesHasNotMoreBalls()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);
        lastFrame.KnockDown(10);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }

    [Test]
    public void whenIsLastFrameAndHasStrikeAndSpareHasNotMoreBalls()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);
        lastFrame.KnockDown(0);
        lastFrame.KnockDown(10);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }

    //Nota: el puntaje generado en las tiradas de bonificación se suma
    //a la  puntuación del turno final.

    [Test]
    public void whenIsLastFrameAndHasBonusTheScoreIsAddedToFinalFrameScore()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);
        lastFrame.KnockDown(0);
        lastFrame.KnockDown(10);

        Assert.AreEqual(20, lastFrame.Score);
    }

}
