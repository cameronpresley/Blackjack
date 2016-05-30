module PlayerTurn

open Player
open Participant
open Game
open System
open Printing
open Turn
open Deck
open Scoring
open Dealer
open MakeChoices

let rec private replacePlayer newPlayer players =
    match players with
    | [] -> []
    | h::t -> if h.Id = newPlayer.Id then newPlayer::t else h::(replacePlayer newPlayer t)

let rec PlayerTakesTurn game playerId =
    match game with
    | None -> None
    | Some game ->
        let printGame () = game |> PrintGameDuringPlay 
        let player = game.Players |> List.find(fun x -> x.Id = playerId)
        let makesChoice = PlayerMakesChoice player
        match TakesTurn printGame makesChoice ScoreForHand DrawCard game.Deck player.Participant with
        | None -> None
        | Some (participant,deck) ->
            let player = {player with Participant=participant}
            let game = {game with Deck = deck; Players=game.Players |> replacePlayer player} |> Some
            match participant.Status with
            | Busted x | Stayed x -> game
            | _ -> PlayerTakesTurn game playerId

let PlayersTakeTurn game =
    let (Dealer d) = game.Dealer
    if d.Status = Blackjack then Some game
    else
        let validPlayers = game.Players |> List.filter(fun x -> x.Participant.Status = CardsDealt) |> List.map(fun x-> x.Id)
        let game = Some game

        validPlayers |> List.fold(fun state element -> PlayerTakesTurn state element) game
