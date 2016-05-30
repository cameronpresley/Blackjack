module Deck

open Card
open Infrastructure

type Deck = Card list

let CreateDeck shuffle = 
    let ranks = GetAllUnionCases<Rank>()
    let suits = GetAllUnionCases<Suit>()

    let cards = seq {
        for r in ranks do
            for s in suits do
                yield {Rank=r; Suit=s}
    }
    cards |> Seq.toList |> shuffle

type DrawResult = {Card:Card; RestOfDeck:Deck}
let DrawCard deck =
    match deck with
    | [] -> None
    | h::t -> {Card=h; RestOfDeck=t} |> Some
