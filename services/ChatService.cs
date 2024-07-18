namespace llm_chatbot.services;

public class ChatService{
    public string Username { get; private set; }

    public void SetUsername(string value)
    {
        if (!String.IsNullOrEmpty(value))
        {
            Username = value;
        }
    }
}