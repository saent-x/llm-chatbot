using llm_chatbot.interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace llm_chatbot.view.Pages;


public class HomeBase : ComponentBase
{
    protected string? Username { get; set; }
    [Inject] protected IChatService _chatService { get; set; }
    [Inject] private NavigationManager navigation {get; set;}
    protected bool startLoading {get; set;} = false;

    protected async Task GotoChatPage(KeyboardEventArgs e){
        if(e.Key == "Enter")
        {
            startLoading = true;
            await Task.Delay(3000);
            
            navigation.NavigateTo("/chat");
            startLoading = false;
            
            _chatService.SetUsername(Username!);
        }
    }
}

