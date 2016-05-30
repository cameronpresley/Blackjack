module DealerTurn

open Deck
open Dealer
open Turn
open Scoring
open Player
open Game
open Printing
open Participant
open MakeChoices

let CanDealerTakeTurn (Dealer dealer) players =
    if dealer.Status = Blackjack then false
    elif players |> List.forall(fun x -> x.Participant.Status = Blackjack) then false
    else true

let rec DealerTakesTurn game =
    if CanDealerTakeTurn game.Dealer game.Players then
        let (Dealer dealer) = game.Dealer
        let printGame game () = PrintGameDuringPlay game

        match TakesTurn (printGame game) (DealerMakesChoice game.Dealer) ScoreForHand DrawCard game.Deck dealer with
        | None -> None
        | Some (participant, deck) -> 
            let game = {game with Deck=deck; Dealer=(participant |> Dealer)}
            match participant.Status with
            | Busted x | Stayed x -> game |> Some
            | _ -> DealerTakesTurn game

    else Some game