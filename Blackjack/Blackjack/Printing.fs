module Printing

open Player
open Dealer
open Game
open Card
open Scoring

let PrintScore hand =
    match hand |> Scoring.PointsForHand with
    | Hard x -> sprintf "(%i)" x
    | Soft(x,y) -> sprintf "(%i/%i)" x y

let PrintDealerDuringGame (Dealer d) =
    let hand = d.Hand |> List.skip 1
    printfn "Dealer has: %s" (hand |> PrintScore)
    hand |> List.iter PrintCard

let PrintDealerAfterGame (Dealer d) =
    printfn "Dealer has: %s" (d.Hand |> PrintScore)
    d.Hand |> List.iter PrintCard

let PrintPlayer p = 
    printfn "Player %i has %s" p.Number (p.Participant.Hand |> PrintScore)
    p.Participant.Hand |> List.iter PrintCard
    printfn ""

let private printGame printDealer printPlayer game =
    System.Console.Clear()
    game.Dealer |> printDealer
    printfn ""
    game.Players |> List.iter printPlayer

let PrintFinalGameStanding game = printGame PrintDealerAfterGame PrintPlayer game
let PrintGameDuringPlay game = printGame PrintDealerDuringGame PrintPlayer game