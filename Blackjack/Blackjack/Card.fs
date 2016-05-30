module Card

type Rank = Ace | Two | Three | Four | Five | Six | Seven
            | Eight | Nine | Ten | Jack | Queen | King

type Suit = Diamonds | Clubs | Spades | Hearts

type Card = {Rank:Rank; Suit:Suit}

let PrintCard c =
    printfn "%A of %A" c.Rank c.Suit 
