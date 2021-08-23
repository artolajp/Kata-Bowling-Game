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
        Assert.AreEqual(2, frame.BallsCount);
    }

    //si en un turno el jugador no tira los 10 bolos,
    //la puntuación del turno es el total de bolos tirados
    [Test]
    public void scoreIsTheNumberOfKnockedDownIfPinsCountIsLessThanTen()
    {
        Frame frame = new Frame();

        Assert.AreEqual(8, frame.KnockedDownCount);
    }

}
