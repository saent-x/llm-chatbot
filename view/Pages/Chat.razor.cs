using llm_chatbot.services;
using Microsoft.AspNetCore.Components;

namespace llm_chatbot.view.Pages;

public class ChatBase: ComponentBase{

    protected ChatMessage[] chatMessages { get; set; }
    [Inject] protected ChatService _chatService { get; set; }

    protected override void OnInitialized()
    {
        chatMessages =
        [
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username},
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, to = "llm-chatbot", from = _chatService.Username}
        ];
    }

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