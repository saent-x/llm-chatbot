using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace llm_chatbot.view.Pages;


public class HomeBase : ComponentBase
{
    protected string? Username { get; set; }

    [Inject] private NavigationManager navigation {get; set;}
    protected bool startLoading {get; set;} = false;

    protected void GotoChatPage(KeyboardEventArgs e){
        if(e.Key == "Enter"){
            navigation.NavigateTo("/chat");
        }
    }
}

