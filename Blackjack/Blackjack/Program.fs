// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Game
open Deck
open Infrastructure
open Player
open Dealer
open Outcome
open Printing
open Participant
open PlayerTurn
open DealerTurn

[<EntryPoint>]
let main argv = 
    let shuffle c =
        let rand = new System.Random() 
        c |> List.sortBy(fun _ -> rand.Next())

    let deck = shuffle |> CreateDeck
    let maybe = new MaybeBuilder()

    let game = maybe {
        let! game = Game.CreateGame DrawCard deck 2
        let! game = game |> PlayersTakeTurn
        let! game = game |> DealerTakesTurn
        do game |> PrintFinalGameStanding
        do game.Players |> List.iter (fun x -> PrintWinner game.Dealer x)
        return game
    }
    0 // return an integer exit code
