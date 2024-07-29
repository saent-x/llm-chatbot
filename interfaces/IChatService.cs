
using llm_chatbot.view;

namespace llm_chatbot.interfaces;

public interface IChatService{
    string? Username { get; set; }
    List<ChatMessage> chatMessages { get; set; }
    void SetUsername(string value);
    Task<string> GenerateResponse(string question);
    void StopResponse();
    void DeleteMessage(int id);
    void ClearScreen();
    void ClearMessages();
}