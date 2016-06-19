///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Authors: Gus
/// Editors:
/// Purpose: This function should allow us to save decks. Down the line when we understand our player's progression more we may have to change some of these function names
/// to be less generic. This is, however, a start. Also if this funciton ends up failing it may be because we are trying to save a list of game objects.
/// It doesn't like game objects and so if that is the case we'll have to save instead a list of strings or id's.
/// Tutorials Used: http://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Dynamic lists in C#
using System.Runtime.Serialization.Formatters.Binary; // Allows Serialization within the script
using System.IO; // Allows us to write and read to our Computer

public static class SaveLoad {

    public static List<Deck> savedDecks = new List<Deck>(); // Creates a list of saved decks to manipulate

    // Function to save a deck to a list of decks specific to the player.
    public static void Save()
    {
        savedDecks.Add(Deck.current); // Adds the current deck to the list
        BinaryFormatter bf = new BinaryFormatter(); // To serialize something we need to create this to handle the work
        FileStream file = File.Create(Application.persistentDataPath + "/savedDecks.dd"); // Creates a pathway to where we want to store files, creates a file there,
        // uses the built in data path, and then specified its name and file type (dd for deck data).
        bf.Serialize(file, SaveLoad.savedDecks); // Serializing our list to our file
        file.Close(); // Closing this file cause we didn't grow up in a barn
    }
	
    public static void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/savedDecks.dd")) // Check to see if decks have been saved before
        {
            BinaryFormatter bf = new BinaryFormatter(); // To serialize something we need to create this to handle the work
            FileStream file = File.Open(Application.persistentDataPath + "/savedDecks.dd", FileMode.Open); // Same as before except we are taking data so its File.Open
            SaveLoad.savedDecks = (List<Deck>)bf.Deserialize(file); // Going backwards: We deserialize the data as a list type and save it as "savedDecks".
            file.Close(); // Closing the file again... it's the right thing to do
        }
    }
}
