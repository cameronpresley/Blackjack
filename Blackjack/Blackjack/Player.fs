module Player

open Participant
open Infrastructure

type Player = {Participant:Participant; Number:int}

let CreatePlayer drawCard deck id =
    maybe {
        let! participant,deck = CreateParticipant drawCard deck
        return {Participant=participant; Number=id},deck
    }