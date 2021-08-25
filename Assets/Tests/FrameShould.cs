using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class FrameShould
{

    //hay 10 bolos que se intentan tirar en cada turno

    [Test]
    public void Has_TenPins()
    {
        Frame frame = new Frame();

        Assert.AreEqual(10,frame.PinsCount);
    }

    //en cada turno el jugador hace 2 tiradas
    [Test]
    public void Has_TwoBalls()
    {
        Frame frame = new Frame();
        Assert.AreEqual(2, frame.balls.Length);
    }

    //si en un turno el jugador no tira los 10 bolos,
    //la puntuación del turno es el total de bolos tirados
    [Test]
    public void Has_Score_EqualTo_TheNumberOfKnockedDown()
    {
        Frame frame = new Frame();

        frame.KnockDown(8);

        Assert.AreEqual(8, frame.Score);
    }

    //si en un turno el jugador tira los 10 bolos (un spare)
    //la puntuación es 10 más el número de bolos tirados en la siguiente tirada (del siguiente turno)
    [Test]
    public void Has_Score_EqualTo_TenPlusNextKnockDownCountOnSpare() {
        Frame frame1 = new Frame();
        Frame frame2 = new Frame();

        frame1.NextFrame = frame2;
        frame1.KnockDown(8);
        frame1.KnockDown(2);
        frame2.KnockDown(2);
        frame2.KnockDown(2);

        Assert.AreEqual(12, frame1.Score);
    }

    //si en la primera tirada del turno tira los 10 bolos (un strike)
    //el turno acaba y la puntuación es 10 más el número de bolos de las 2 jugadas siguientes
    [Test]
    public void Has_Score_EqualTo_TenPlusNextFrameScoreOnStrike() {
        Frame frame1 = new Frame();
        Frame frame2 = new Frame();

        frame1.NextFrame = frame2;
        frame1.KnockDown(10);
        frame2.KnockDown(1);
        frame2.KnockDown(3);

        Assert.AreEqual(14, frame1.Score);
    }

    [Test]
    public void Has_Score_EqualTo_TenPlusNextTwoBallsOnTwoStrikes()
    {
        Frame frame1 = new Frame();
        Frame frame2 = new Frame();
        Frame frame3 = new Frame();

        frame1.NextFrame = frame2;
        frame2.NextFrame = frame3;
        frame1.KnockDown(10);
        frame2.KnockDown(10);
        frame3.KnockDown(2);
        frame3.KnockDown(2);


        Assert.AreEqual(22, frame1.Score);
    }

    //si el jugador logra un spare o un strike en el último turno,
    //obtiene una o dos tiradas más (respectivamente) de bonificación.
    //Esas tiradas cuentan como parte del mismo turno (el décimo).
    //SPARE
    [Test]
    public void Has_OneMoreBall_When_IsLastFrameAndWasSparePlayer() {
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
    public void Has_TwoMoreBalls_When_IsLastFrameAndWasStrikePlayer()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }
    //Si en las tiradas de bonificación el jugador derriba todos los bolos,
    //el proceso no se repite, es decir que no se vuelven a generar más
    //lanzamientos de  bonificación.
    [Test]
    public void HasNot_MoreBalls_When_IsLastFrameAndHasTwoStrikes()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);
        lastFrame.KnockDown(10);

        Assert.AreEqual(3, lastFrame.balls.Length);
    }

    [Test]
    public void HasNot_MoreBalls_When_IsLastFrameAndHasStrikeAndSpare()
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
    public void Has_Score_EqualTo_AllKnockedDown_When_IsLastFrame()
    {
        Frame lastFrame = new Frame();

        lastFrame.KnockDown(10);
        lastFrame.KnockDown(0);
        lastFrame.KnockDown(10);

        Assert.AreEqual(20, lastFrame.Score);
    }

    [Test]
    public void Has_OneBall_IfIsStrike() {
        Frame frame1 = new Frame();
        Frame frame2 = new Frame();
        frame1.NextFrame = frame2;

        frame1.KnockDown(10);

        Assert.AreEqual(1, frame1.balls.Length);
    }

}
