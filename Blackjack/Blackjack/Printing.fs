module Printing

open Player
open Dealer
open Game
open Card

let PrintDealerDuringGame (Dealer d) =
    printfn "Dealer has:"
    d.Hand |> List.skip 1 |> List.iter PrintCard

let PrintDealerAfterGame (Dealer d) =
    printfn "Dealer has:"
    d.Hand |> List.iter PrintCard

let PrintPlayer p = 
    printfn "Player %i has:" p.Id
    p.Participant.Hand |> List.iter PrintCard
    printfn ""

let private printGame printDealer printPlayer game =
    System.Console.Clear()
    game.Dealer |> printDealer
    printfn ""
    game.Players |> List.iter printPlayer

let PrintFinalGameStanding game = printGame PrintDealerAfterGame PrintPlayer game
let PrintGameDuringPlay game = printGame PrintDealerDuringGame PrintPlayer game