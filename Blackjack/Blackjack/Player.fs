module Player

open Participant
open Infrastructure

type Player = {Participant:Participant; Number:int}

let CreatePlayer drawCard deck id =
    maybe {
        let! participant,deck = CreateParticipant drawCard deck
        return {Participant=participant; Number=id},deck
    }

let CreatePlayers drawCard deck numberOfPlayers =
    let foldPlayer state playerNumber =
        maybe {
            let! players,deck = state
            let! player,deck = CreatePlayer drawCard deck playerNumber
            return (players@[player], deck)
        }
    let state = Some ([], deck)
    [1 .. numberOfPlayers] |> List.fold foldPlayer state


