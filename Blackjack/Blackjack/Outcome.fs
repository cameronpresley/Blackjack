module Outcome

open Dealer
open Player
open Scoring
open Participant

let PrintWinner (Dealer d) player =
    printfn "Outcome for Player %i" player.Number
    printf "\t"

    match d.Status,player.Participant.Status with
    | Blackjack,Blackjack -> printfn "Both Player and Dealer got Blackjack, so it's a push"
    | _, Blackjack -> printfn "Player got a blackjack, Player wins"
    | Blackjack, _ -> printfn "Dealer got blackjack, Dealer wins"

    | _, Busted (Score x) -> printfn "Player busted with %i, Dealer wins" x
    | Busted (Score x), _ -> printfn "Dealer busted with %i, Player wins" x
    
    | Stayed (Score x), Stayed (Score y) -> 
        printfn "Dealer has %i and Player has %i" x y
        if x = y then printfn "\tIt's a push"
        elif x > y then printfn "\tDealer wins"
        else printfn "\tPlayer wins"

    | CardsDealt, _ -> printfn "Dealer never took a turn."
    | _, CardsDealt -> printfn "Player never took a turn."