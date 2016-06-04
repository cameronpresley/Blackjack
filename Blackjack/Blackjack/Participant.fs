module Participant

open Card
open Deck
open Infrastructure
open Scoring

type Hand = Card list
type Status = Busted of Score | Stayed of Score | Blackjack | CardsDealt

type Participant = {Hand:Hand; Status:Status}

let wasDealtBlackjack hand =
    if hand |> List.length <> 2 then CardsDealt
    elif (hand |> ScoreForHand) = Score 21 then Blackjack
    else CardsDealt

let CreateParticipant drawCard deck =
    maybe {
        let! firstResult = deck |> drawCard
        let! secondResult = firstResult.RestOfDeck |> drawCard
        let hand = [firstResult.Card; secondResult.Card]
        let status = wasDealtBlackjack hand 
        return {Hand=hand; Status=status},secondResult.RestOfDeck
    }