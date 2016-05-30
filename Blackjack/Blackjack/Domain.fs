module Domain

type Rank = Ace | Two | Three | Four | Five | Six | Seven
            | Eight | Nine | Ten | Jack | Queen | King
type Suit = Hearts | Clubs | Spades | Diamonds
type Card = {Rank:Rank; Suit:Suit}

type Deck = Card list
type Hand = Card list

type Score = Score of int
type Status = Busted of Score | Stayed of Score | Blackjack | CardsDealt

type Participant = {Hand:Hand; Status:Status}
type Player = {Id:int; Participant:Participant}
type Dealer = Dealer of Participant

type Game = {Players:Player list; Dealer:Dealer; Deck:Deck} 
