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

    let game = maybe {
        let! game = CreateGame shuffle DrawCard 2
        let! game = game |> PlayersTakeTurn
        let! game = game |> DealerTakesTurn
        return game
    }
    match game with
    | None -> printfn "Error while playing the game"
    | Some game -> 
        game |> PrintFinalGameStanding
        game.Players |> List.iter (fun x -> PrintWinner game.Dealer x)
    0 // return an integer exit code
