module Game

open Player
open Deck
open Dealer
open Infrastructure

type Game = {Players:Player list; Dealer:Dealer; Deck:Deck}

let CreateGame shuffle drawCard numPlayers =
    maybe {
        let deck = CreateDeck shuffle
        let! dealer,deck = CreateDealer drawCard deck
        let! players,deck = CreatePlayers drawCard deck numPlayers
        return {Dealer=dealer; Players=players; Deck=deck}
    }

