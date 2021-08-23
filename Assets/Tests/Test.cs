using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    //cada partida se compone de 10 turnos
    [Test]
    public void gameHasTenTurns()
    {
        //given
        
        //when
        Game game = new Game();
        //then
        Assert.AreEqual(10, game.Turns.Count);
    }

    //hay 10 bolos que se intentan tirar en cada turno
    //en cada turno el jugador hace 2 tiradas
    //si en un turno el jugador no tira los 10 bolos, la puntuación del turno es el total de bolos tirados


}
