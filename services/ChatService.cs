using llm_chatbot.interfaces;
using llm_chatbot.view;

namespace llm_chatbot.services;

public class ChatService : IChatService {
    public string? Username { get; set; }
    public string? Question { get; set; }
    public List<ChatMessage> chatMessages { get; set; }

    public ChatService(){
        chatMessages =
        [
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, sender = Username!},
            new ChatMessage{message = $"Hi {Username}, how are you doing today", timestamp = DateTime.Now, sender = "llm-chatbot"},
            new ChatMessage{message = "I am doing okay, write a joke for me", timestamp = DateTime.Now, sender = Username!},
            new ChatMessage{message = "Sure, here is, here is one...", timestamp = DateTime.Now, sender = "llm-chatbot"},
            new ChatMessage{message = "Why don't scientists trust atoms?\n\nBecause they make up everything!\n\nAnd why did the scarecrow get promoted?\n\nHe was outstanding in his field!", timestamp = DateTime.Now, sender = "llm-chatbot"}
        ];
    }


    public void SetUsername(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            Username = value;
        }
    }

    public void GenerateResponse(){

    }

    public void StopResponse(){

    }

    public void DeleteMessage(int id){

    }

    public void ClearScreen(){

    }

    public void ClearMessages(){
        
    }
}