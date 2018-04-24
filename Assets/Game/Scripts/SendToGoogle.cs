using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendToGoogle : MonoBehaviour {

    public GameObject username;
    public GameObject animal;
    public GameObject movie;

    private string usernameString;
    private string animalString;
    private string movieString;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfBUvoq3w3W4lwLjOGMCTqxIDL22MTLpOqkE4iTzYy3GUB7Ng/formResponse";

    // Creating a coroutine that creates a WWWForm and adds fields that will then wrap into the google form
    IEnumerator Post(string name, string animal, string movie)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1376764974", name);
        form.AddField("entry.100258981", animal);
        form.AddField("entry.215924528", movie);

        // Converts the form data in byte data, and sends the byte data as a WWW request to a specific URL
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;

    }

    // Create a send function to get the text from the input fields and put it into the google forms via Post
    public void Send()
    {
        usernameString = username.GetComponent<InputField>().text;
        animalString = animal.GetComponent<InputField>().text;
        movieString = movie.GetComponent<InputField>().text;

        StartCoroutine(Post(usernameString, animalString, movieString));
    }
}
