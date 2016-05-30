module Scoring
open Card

type Points = Hard of int | Soft of int*int
type Score = Score of int

let PointsForCard c =
    match c.Rank with
    | Ace -> Soft(1, 11)
    | Two -> Hard 2
    | Three -> Hard 3
    | Four -> Hard 4
    | Five -> Hard 5
    | Six -> Hard 6
    | Seven -> Hard 7
    | Eight -> Hard 8
    | Nine -> Hard 9
    | Ten | Jack | Queen | King -> Hard 10

let NormalizePoints points =
    match points with
    | Hard x -> Hard x
    | Soft(x,y) -> if y > 21 then Hard x else Soft(x,y)

let PointsForHand hand =
    let addPoints a b =
        match a,b with
        | Hard x, Hard y -> Hard(x+y)
        | Hard x, Soft (y,z) | Soft(y,z), Hard x -> Soft(x+y, x+z)
        | Soft(x,y), Soft(z,_) -> Soft(x+z, y+z)
        
    hand |> List.map PointsForCard |> List.reduce addPoints |> NormalizePoints
    
let ScoreForHand hand =
    match hand |> PointsForHand with
    | Hard x -> Score x 
    | Soft(x,y) -> Score y 