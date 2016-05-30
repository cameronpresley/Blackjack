module Dealer

open Infrastructure
open Participant
open Card

type Dealer = Dealer of Participant

let maybe = new MaybeBuilder()

let CreateDealer drawCard deck =
    maybe {
        let! participant,deck = CreateParticipant drawCard deck
        return (participant |> Dealer),deck
    }