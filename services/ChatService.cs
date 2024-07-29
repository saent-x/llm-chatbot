using llm_chatbot.interfaces;
using llm_chatbot.view;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors;
using Microsoft.SemanticKernel.Connectors.OpenAI;

namespace llm_chatbot.services;

public class ChatService : IChatService {
    public string? Username { get; set; }
    public string? Question { get; set; }
    public List<ChatMessage> chatMessages { get; set; }
    
    private Kernel _kernel;
    private ChatHistory _chatHistory;
    private OpenAIPromptExecutionSettings _openAIPromptExecutionSettings;
    private IChatCompletionService _chatCompletionService;

    public ChatService(){
        chatMessages =
        [
            new ChatMessage{message = "Hello", timestamp = DateTime.Now, sender = Username!},
            new ChatMessage{message = $"Hi {Username}, how are you doing today", timestamp = DateTime.Now, sender = "llm-chatbot"},
            new ChatMessage{message = "I am doing okay, write a joke for me", timestamp = DateTime.Now, sender = Username!},
            new ChatMessage{message = "Sure, here is, here is one...", timestamp = DateTime.Now, sender = "llm-chatbot"},
            new ChatMessage{message = "Why don't scientists trust atoms?\n\nBecause they make up everything!\n\nAnd why did the scarecrow get promoted?\n\nHe was outstanding in his field!", timestamp = DateTime.Now, sender = "llm-chatbot"}
        ];
        
        InitializeSkOllama();
    }
 
    private void InitializeSkOllama()
    {
        var ollama_endpoint = new Uri(Environment.GetEnvironmentVariable("OLLAMA_URL")!);
        var model_id = Environment.GetEnvironmentVariable("MODEL_ID");

        # pragma warning disable SKEXP0010
        var kernel_builder = Kernel.CreateBuilder()
            .AddOpenAIChatCompletion(modelId: model_id!, apiKey: null, endpoint: ollama_endpoint);

        _kernel = kernel_builder.Build();
        
        _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
        
        _openAIPromptExecutionSettings = new() 
        {
            ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
        };

        _chatHistory = new ChatHistory();
    }


    public void SetUsername(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            Username = value;
        }
    }

    public async Task<string> GenerateResponse(string question){
        _chatHistory.AddUserMessage(question);
        
        var result = await _chatCompletionService.GetChatMessageContentAsync(
            _chatHistory,
            executionSettings: _openAIPromptExecutionSettings,
            kernel: _kernel);
        
        _chatHistory.AddMessage(result.Role, result.Content ?? string.Empty);

        return result.Content!;
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