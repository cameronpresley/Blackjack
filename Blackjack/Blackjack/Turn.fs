module Turn

open Infrastructure
open Participant
open Deck
open Game 
open System
open Scoring
open MakeChoices

let TakesTurn printsGame makesChoice scoreHand drawCard deck participant =
    printsGame ()
    match makesChoice () with
    | Hit ->
        maybe {
            let! drawResult = deck |> drawCard
            let participant = {participant with Hand=participant.Hand @ [drawResult.Card]}
            return match participant.Hand |> scoreHand with
                    | Score busted when busted > 21 -> {participant with Status = Busted (Score busted)},drawResult.RestOfDeck
                    | _ -> participant,drawResult.RestOfDeck
        }
    | Stay ->
        let score = participant.Hand |> scoreHand
        ({participant with Status=Stayed score},deck) |> Some