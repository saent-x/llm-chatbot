using Microsoft.AspNetCore.Components;

namespace llm_chatbot.Components.Pages;

public record struct ChatMessage(string from, string to, string message, DateTime timestamp);

public class ChatBase: ComponentBase{

    protected ChatMessage[] chatMessages { get; set; }

    protected void GenerateResponse(){

    }

    protected void StopResponse(){

    }

    protected void DeleteMessage(int id){

    }

    protected void ClearScreen(){

    }

    protected void ClearMessages(){
        
    }
}