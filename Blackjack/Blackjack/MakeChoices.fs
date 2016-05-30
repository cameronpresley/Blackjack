module MakeChoices

open Player
open Dealer
open System
open Scoring


type Action = Hit | Stay

let rec PlayerMakesChoice player () = 
    printfn "Player %i's turn" player.Id
    printfn "1). Hit"
    printfn "2). Stay"
    match Console.ReadLine() with
    | "1" -> Hit
    | "2" -> Stay
    | _ -> PlayerMakesChoice player ()

let DealerMakesChoice (Dealer d) () =
    match d.Hand |> ScoreForHand with
    | Score s when s < 17 -> Hit
    | _ -> Stay
