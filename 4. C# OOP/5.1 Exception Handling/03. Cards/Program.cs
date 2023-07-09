
using _3;

List<Card> cards = new List<Card>();

string[] cardsInput = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

foreach (var card in cardsInput)
{
    try
    {
        cards.Add(CreateCard(card));
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(String.Join(" ", cards));

static Card CreateCard(string card)
{
    string[] cardElem = card
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string face = cardElem[0];

    if (!CheckCardFace(face))
    {
        throw new ArgumentException("Invalid card!");
    }

    string cardSuit = cardElem[1];

    CardSuit suit;

    switch (cardSuit)
    {
        case "S":
            suit = CardSuit.Spades;
            break;
        case "H":
            suit = CardSuit.Hearts;
            break;
        case "D":
            suit = CardSuit.Diamonds;
            break;
        case "C":
            suit = CardSuit.Clubs;
            break;
        default:
            throw new FormatException("Invalid card!");
    }

    return new Card(face, suit);
}
static bool CheckCardFace(string face)
{
    string[] allPossible =
        new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    if (!allPossible.Contains(face))
    {
        return false;
    }

    return true;
}