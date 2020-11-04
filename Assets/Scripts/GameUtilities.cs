using System.Collections.Generic;

/* Randomize the order of items in a list */
public class GameUtilities {

    public static void RandomizeList<T>(ref List<T> list) {
        System.Random rand = new System.Random();

        // For each spot in the list, pick a random item to swap into that spot.
        for (int i = 0; i < list.Count - 1; i++) {
            int j = rand.Next(i, list.Count);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}