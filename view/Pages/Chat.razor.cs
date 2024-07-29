using llm_chatbot.interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace llm_chatbot.view.Pages;

public class ChatBase: ComponentBase{

    [Inject] protected IChatService? _chatService { get; set; }
    [Inject] protected ILogger<Chat>? Logger { get; set; }
    [Inject] protected IJSRuntime JS { get; set; }
    protected string? Message { get; set; }

    protected async Task SendAsync()
    {
        if(string.IsNullOrEmpty(Message) || string.IsNullOrWhiteSpace(Message)) return;
        
        _chatService?.chatMessages.Add(new ChatMessage
        {
            id = Guid.NewGuid().ToString(),
            message = Message,
            sender = _chatService.Username!,
            timestamp = DateTime.Now
        });
        
        Message = "";

        await ScrollToBottom();
        var ollama_response = await _chatService?.GenerateResponse(Message)!;
        
        _chatService.chatMessages.Add(new ChatMessage
        {
            id = Guid.NewGuid().ToString(),
            message = ollama_response,  
            sender = "llm_chatbot",
            timestamp = DateTime.Now
        });
        
        Logger?.LogInformation("response generated.");
    }
    
    private async Task ScrollToBottom() => 
        await JS.InvokeVoidAsync("scrollToBottom", "chatMessages");
}