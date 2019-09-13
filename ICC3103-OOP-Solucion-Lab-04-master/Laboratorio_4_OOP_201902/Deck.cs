using Laboratorio_4_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_4_OOP_201902
{
    public class Deck
    {

        private List<Card> cards;

        public Deck()
        {
        
        }

        public List<Card> Cards { get => cards; set => cards = value; }

        public void AddCard(Card card)
        {
            //Agregue la carta card a la lista cards
            cards.AddCard(card);
        }
        public void DestroyCard(int cardId)
        {
            /* Debe eliminar la carta segun el parametro cardId. Para esto
                1- Utilice el metodo RemoveAt de las listas para eliminar la carta en cards
            */
            cards.RemoveAt(cardId);
        }
        public void Shuffle()
        {
            // Lo que hago es recorrer carta por carta la lista.
            // Luego,  para cada carta en la lista se genera un numero aleatorio
            // Accedo al elemento que esta en la posicion aleatoria, y creo una nueva carta con los mismos atributos que esa
            // Hago lo mismo con la carta actual en la que nos encontramos en el foreach
            // Eliminamos las referencias anteriores a las cartas (solo nos quedamos con las nuevas)
            // Y luego, las agregamos al mazo.
            // Es equivalente a ir tomando dos cartas aleatorias del mazo y moverlas de lugar
            int cardId = 0;
            Random random = new Random();
            int randomNumber;
            // Reordenar el mazo de manera aleatoria (barajar).
            foreach (Card carta in cards)
            {
                randomNumber = random.Next(0, cards.Length);

                if (GetType(cards[randomNumber]) == typeof(CombatCard))
                {
                    CombatCard randomCard = this.cards[randomNumber];
                    CombatCard newCard = new CombatCard(randomCard.Name, randomCard.Type, randomCard.Effect, randomCard.AttackPoints, randomCard.Hero);
                    DestroyCard(randomNumber);
                    if (GetType(carta) == typeof(CombatCard))
                    {
                        CombatCard newCard2 = new CombatCard(carta.Name, carta.Type, carta.Effect, carta.AttackPoints, carta.Hero);
                        DestroyCard(cardId);
                    }
                    else
                    {
                        SpecialCard newCard2 = new SpecialCard(carta.Name, carta.Type, carta.Effect);
                        DestroyCard(cardId);
                    }
                }
                else
                {
                    SpecialCard randomCard = this.cards[randomNumber];
                    SpecialCard newCard = new SpecialCard(randomCard.Name, randomCard.Type, randomCard.Effect);
                    DestroyCard(randomNumber);
                    if (GetType(carta) == typeof(CombatCard))
                    {
                        CombatCard newCard2 = new CombatCard(carta.Name, carta.Type, carta.Effect, carta.AttackPoints, carta.Hero);
                        DestroyCard(cardId);
                    }
                    else
                    {
                        SpecialCard newCard2 = new SpecialCard(carta.Name, carta.Type, carta.Effect);
                        DestroyCard(cardId);
                    }
                }
                AddCard(newCard);
                AddCard(newCard2);
                cardId++;
            }
        }
    }
}
